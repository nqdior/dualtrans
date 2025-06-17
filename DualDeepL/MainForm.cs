using DualDeepL.Properties;
using DualDeepL.Models;
using DualDeepL.Services;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DualDeepL
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer typingTimer;
        private readonly ITranslationService openAITranslationService;
        private readonly ITranslationService deepLTranslationService;

        // キーボードフックに関する宣言
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr KeyboardProc(int nCode, int wParam, IntPtr lParam);
        private KeyboardProc keyboardProc;
        private IntPtr hookId = IntPtr.Zero;

        // キー処理用変数
        private bool isCPressedOnce = false;
        private DateTime lastCPressTime;

        // タスクトレイアイコン
        private ContextMenuStrip trayMenu;

        public MainForm()
        {
            InitializeComponent();

            // Initialize translation services
            openAITranslationService = new OpenAITranslationService();
            deepLTranslationService = new DeepLTranslationService();

            // Setup language combo boxes
            var languages1 = LanguageManager.GetLanguages();
            var languages2 = LanguageManager.GetLanguages();
            var languages3 = LanguageManager.GetLanguages();

            combo_orig.DataSource = languages1;
            combo_orig.DisplayMember = "Display";
            combo_orig.ValueMember = "LangCode";

            combo_first.DataSource = languages2;
            combo_first.DisplayMember = "Display";
            combo_first.ValueMember = "LangCode";

            combo_second.DataSource = languages3;
            combo_second.DisplayMember = "Display";
            combo_second.ValueMember = "LangCode";

            combo_orig.SelectedIndex = Settings.Default.OriginalLanguage;
            combo_first.SelectedIndex = Settings.Default.FirstLanguage;
            combo_second.SelectedIndex = Settings.Default.SecondLanguage;
            combo_orig.SelectedValueChanged += combo_orig_SelectedIndexChanged;
            combo_first.SelectedIndexChanged += combo_first_SelectedIndexChanged;
            combo_second.SelectedIndexChanged += combo_second_SelectedIndexChanged;

            // タイマーの初期化
            typingTimer = new System.Windows.Forms.Timer();
            typingTimer.Interval = 1000; // タイマーを1秒に設定
            typingTimer.Tick += TypingTimer_Tick; // タイマーのイベントハンドラを追加

            ActiveControl = textbox_orig;

            // キーボードフックの設定
            keyboardProc = new KeyboardProc(KeyboardHookProc);
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                hookId = SetWindowsHookEx(13, keyboardProc, LoadLibrary(curModule.ModuleName), 0);
            }

            // タスクトレイアイコンの初期化
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("DualDeepLを終了する", null, OnTrayExitClicked);
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
            trayIcon.Click += (sender, args) => ShowWindow();

            // FormClosingイベントにハンドラを追加
            FormClosing += MainForm_FormClosing;
        }

        private IntPtr KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == 0x100) // WM_KEYDOWN
            {
                var key = (Keys)Marshal.ReadInt32(lParam);
                if (key == Keys.C)
                {
                    if (isCPressedOnce && (DateTime.Now - lastCPressTime).TotalMilliseconds < 500)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            Show();
                            WindowState = FormWindowState.Normal;
                            TopMost = true;
                            TopMost = false;
                            textbox_orig.Text = Clipboard.GetText();
                        }));
                    }
                    else
                    {
                        isCPressedOnce = true;
                        lastCPressTime = DateTime.Now;
                    }
                }
            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        private async void Translate()
        {
            if (textbox_orig.Text == string.Empty) return;

            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try
            {
                var translateTask1 = TranslateAsync(orig, first, textbox_orig.Text, Settings.Default.Instruct1, textbox_first);
                var translateTask2 = TranslateAsync(orig, second, textbox_orig.Text, Settings.Default.Instruct2, textbox_second);
                await Task.WhenAll(translateTask1, translateTask2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async void Orig_textbox_Leave(object sender, EventArgs e)
        {
            // Translate();
        }

        private void textbox_orig_TextChanged(object sender, EventArgs e)
        {
            // テキストが変更される度にタイマーをリセット
            typingTimer.Stop();
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            // タイマーが作動したら、タイピングが終了したとみなす
            typingTimer.Stop();
            Console.WriteLine("Typing finished.");
            // タイピング終了の処理をここに記述
            Translate();
        }

        private async void First_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            try
            {
                var result = await deepLTranslationService.TranslateAsync(first, orig, textbox_first.Text);
                textbox_re_first.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async void Second_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try
            {
                var result = await deepLTranslationService.TranslateAsync(second, orig, textbox_second.Text);
                textbox_re_second.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async Task TranslateAsync(string sourceLang, string targetLang, string text, string instruction, RichTextBox outputTextBox)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var result = await openAITranslationService.TranslateAsync(sourceLang, targetLang, text, instruction);
                outputTextBox.Text = result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = !checkBox1.Checked;
            button2.Enabled = !checkBox1.Checked;
            TopMost = checkBox1.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // アプリケーションの終了をキャンセル
                e.Cancel = true;
                // フォームを非表示にしてタスクトレイに格納
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new InstructionForm().ShowDialog(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new InstructionForm().ShowDialog(2);
        }

        private void combo_orig_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.OriginalLanguage = combo_orig.SelectedIndex;
            Settings.Default.Save();
        }

        private void combo_first_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.FirstLanguage = combo_first.SelectedIndex;
            Settings.Default.Save();
        }

        private void combo_second_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SecondLanguage = combo_second.SelectedIndex;
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;
            TopMost = false;
        }

        private void OnTrayExitClicked(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}