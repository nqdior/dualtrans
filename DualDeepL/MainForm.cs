using DualDeepL.Properties;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace DualDeepL
{
    public partial class MainForm : Form
    {

        // キーボードフックに関する定義
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

        // キー監視用変数
        private bool isCPressedOnce = false;
        private DateTime lastCPressTime;

        // タスクトレイアイコン
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;


        readonly List<ItemSet> src = new()
        {
                new ItemSet("BG", "ブルガリア語"),
                new ItemSet("CS", "チェコ語"),
                new ItemSet("DA", "デンマーク語"),
                new ItemSet("DE", "ドイツ語"),
                new ItemSet("EL", "ギリシャ語"),
                new ItemSet("EN", "英語"),
                new ItemSet("EN-GB", "英語 (イギリス)"),
                new ItemSet("EN-US", "英語 (アメリカ)"),
                new ItemSet("ES", "スペイン語"),
                new ItemSet("ET", "エストニア語"),
                new ItemSet("FI", "フィンランド語"),
                new ItemSet("FR", "フランス語"),
                new ItemSet("HU", "ハンガリー語"),
                new ItemSet("ID", "インドネシア語"),
                new ItemSet("IT", "イタリア語"),
                new ItemSet("JA", "日本語"),
                new ItemSet("KO", "韓国語"),
                new ItemSet("LT", "リトアニア語"),
                new ItemSet("LV", "ラトビア語"),
                new ItemSet("NB", "ノルウェー語"),
                new ItemSet("NL", "オランダの"),
                new ItemSet("PL", "ポーランド語"),
                new ItemSet("PT-BR", "ポルトガル語 (ブラジル)"),
                new ItemSet("PT-PT", "ポルトガル語"),
                new ItemSet("RO", "ルーマニア語"),
                new ItemSet("RU", "ロシア語"),
                new ItemSet("SK", "スロバキア語"),
                new ItemSet("SL", "スロベニア語"),
                new ItemSet("SV", "スウェーデン語"),
                new ItemSet("TR", "トルコ語"),
                new ItemSet("UK", "ウクライナ語"),
                new ItemSet("ZH", "中国語（簡体字）")
            };

        public MainForm()
        {
            InitializeComponent();

            List<ItemSet> src2 = new(src);
            List<ItemSet> src3 = new(src);

            combo_orig.DataSource = src;
            combo_orig.DisplayMember = "Display";
            combo_orig.ValueMember = "LangCode";

            combo_first.DataSource = src2;
            combo_first.DisplayMember = "Display";
            combo_first.ValueMember = "LangCode";

            combo_second.DataSource = src3;
            combo_second.DisplayMember = "Display";
            combo_second.ValueMember = "LangCode";

            combo_orig.SelectedIndex = Settings.Default.OriginalLanguage;
            combo_first.SelectedIndex = Settings.Default.FirstLanguage;
            combo_second.SelectedIndex = Settings.Default.SecondLanguage;
            combo_orig.SelectedValueChanged += combo_orig_SelectedIndexChanged;
            combo_first.SelectedIndexChanged += combo_first_SelectedIndexChanged;
            combo_second.SelectedIndexChanged += combo_second_SelectedIndexChanged;


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
            trayMenu.Items.Add("Exit", null, OnTrayExitClicked);
            trayIcon = new NotifyIcon()
            {
                Icon = SystemIcons.Application,
                ContextMenuStrip = trayMenu,
                Visible = true
            };
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            trayIcon.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            trayIcon.DoubleClick += (sender, args) => ShowWindow();

            // FormClosingイベントにハンドラを追加
            this.FormClosing += MainForm_FormClosing;
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
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.Show();
                            this.WindowState = FormWindowState.Normal;
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
                var translateTask1 = Translate(orig, first, textbox_orig, textbox_first, Settings.Default.Instruct1);
                var translateTask2 = Translate(orig, second, textbox_orig, textbox_second, Settings.Default.Instruct2);
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
            Translate();
        }

        private async void First_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            try
            {
                await Translate_DeepL(first, orig, textbox_first, textbox_re_first);
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
                await Translate_DeepL(second, orig, textbox_second, textbox_re_second);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }


        #region gpt engine

        public async Task Translate(string sourceLang, string targetLang, RichTextBox input_textbox, RichTextBox output_textbox, string instruct_text = "")
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var api = new OpenAI_API.OpenAIAPI(Settings.Default.APIKey);
                var chat = api.Chat.CreateConversation();
                chat.Model.ModelID = "gpt-3.5-turbo-1106";

                var sourceLangCaption = src.First(r => r.LangCode.Equals(sourceLang)).Display;
                var targetLangCaption = src.First(r => r.LangCode.Equals(targetLang)).Display;

                var prompt = $@"以下の文章を、{sourceLangCaption}から{targetLangCaption}へ翻訳してください。:" + Environment.NewLine;
                prompt += $"{input_textbox.Text}";

                if (instruct_text != "")
                {
                    prompt = $@"#原文 にある{sourceLangCaption}の文章を{targetLangCaption}へ翻訳してください。
訳文の表記は #表記ルール に書かれた指示に従ってください。

#原文
{input_textbox.Text}

#表記ルール 
{instruct_text}

#出力
    ";
                }
                Console.WriteLine(prompt);
                chat.AppendUserInput(prompt);

                string response = await chat.GetResponseFromChatbotAsync();
                output_textbox.Text = response;
                Console.WriteLine(output_textbox.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion


        private static async Task Translate_DeepL(string sourceLang, string targetLang, RichTextBox input_textbox, RichTextBox output_textbox)
        {
            using var httpClient = new HttpClient();
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
            {
                request.Headers.TryAddWithoutValidation("Authorization", "DeepL-Auth-Key " + Settings.Default.DeepLKey);
                Console.WriteLine("DeepL-Auth-Key " + Settings.Default.DeepLKey);
                var contentList = new List<string>
                    {
                        "text=" + input_textbox.Text,
                        "source_lang=" + sourceLang,
                        "target_lang=" + targetLang
                    };
                request.Content = new StringContent(string.Join("&", contentList));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                var response = await httpClient.SendAsync(request);
                var resBodyStr = response.Content.ReadAsStringAsync().Result;

                TrnResponse trnResponse = JsonSerializer.Deserialize<TrnResponse>(resBodyStr, GlbUtil.GetJsonSerializerOptionsDefault());
                GlbResponseBody glbResponseBody = new()
                {
                    Text = trnResponse.Translations.Count > 0 ? trnResponse.Translations[0].Text : "translation error."
                };

                output_textbox.Text = glbResponseBody.Text;
                Console.WriteLine(output_textbox.Text);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) => TopMost = checkBox1.Checked;

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
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void OnTrayExitClicked(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            this.Close(); // アプリケーションを終了
        }
    }


    public class ItemSet
    {
        public string Display { get; set; }
        public string LangCode { get; set; }

        public ItemSet(string v, string s)
        {
            LangCode = v;
            Display = s;
        }
    }

    #region utils

    public static class GlbUtil
    {
        #region result code

        public const string RESULT_CODE_SUCCESS = "0000";
        public const string RESULT_CODE_ERROR = "9999";
        public const string RESULT_MESSAGE_SUCCESS = "SUCCESS";
        public const string RESULT_MESSAGE_ERROR = "ERROR OCCURED";

        public static ReadOnlyDictionary<string, string> GetResultCodeDictionary()
        {
            try
            {
                var resultCodeDictionary = new Dictionary<string, string>
                {
                    { RESULT_CODE_SUCCESS, RESULT_MESSAGE_SUCCESS },
                    { RESULT_CODE_ERROR,   RESULT_MESSAGE_ERROR },
                };

                var resultCodeDictionaryRo = new ReadOnlyDictionary<string, string>(resultCodeDictionary);

                return resultCodeDictionaryRo;
            }
            catch
            {
                throw;
            }
        }

        #endregion result code  

        #region serializer

        public static JsonSerializerOptions GetJsonSerializerOptionsDefault()
        {
            try
            {
                return new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                };
            }
            catch
            {
                throw;
            }
        }

        #endregion serializer
    }

    #endregion utils

    #region glb response

    public class GlbResponse
    {
        [JsonPropertyName("header")]
        public string Header { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }

    public class GlbResponseHeader
    {
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }

        [JsonPropertyName("result_message")]
        public string ResultMessage { get; set; }
    }

    public class GlbResponseBody
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    #endregion glb response

    #region translate response

    public class TrnResponse
    {
        [JsonPropertyName("translations")]
        public List<TrnResponseBody> Translations { get; set; }
    }

    public class TrnResponseBody
    {
        [JsonPropertyName("detected_source_language")]
        public string DetectedSourceLanguage { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    #endregion translate response

}