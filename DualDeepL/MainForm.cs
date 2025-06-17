using DualDeepL.Properties;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Net.Http; // Translate_DeepL でHttpClient使用
using System;
using System.Linq;
using System.Collections.Generic;

namespace DualDeepL
{
    /// <summary>
    /// メインフォームクラス
    /// </summary>
    public partial class MainForm : Form
    {
        // 入力停止検知用タイマー
        private readonly System.Windows.Forms.Timer typingTimer;

        // キーボードフック関連
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr KeyboardProc(int nCode, int wParam, IntPtr lParam);
        private readonly KeyboardProc keyboardProc;
        private IntPtr hookId = IntPtr.Zero;

        // ダブルクリック判定用
        private bool isCPressedOnce = false;
        private DateTime lastCPressTime;

        // タスクトレイ用
        private ContextMenuStrip trayMenu;

        // 言語リスト
        private readonly List<ItemSet> src = new()
        {
            new ItemSet("BG", "ブルガリア語"),
            new ItemSet("CS", "チェコ語"),
            new ItemSet("DA", "デンマーク語"),
            new ItemSet("DE", "ドイツ語"),
            new ItemSet("EL", "ギリシャ語"),
            new ItemSet("EN", "英語"),
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

        /// <summary>
        /// コンストラクタ：コントロールやイベント初期化
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // ComboBox データソース設定
            var src2 = new List<ItemSet>(src);
            var src3 = new List<ItemSet>(src);

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

            combo_orig.SelectedValueChanged += (s, e) =>
            {
                Settings.Default.OriginalLanguage = combo_orig.SelectedIndex;
                Settings.Default.Save();
            };
            combo_first.SelectedIndexChanged += (s, e) =>
            {
                Settings.Default.FirstLanguage = combo_first.SelectedIndex;
                Settings.Default.Save();
            };
            combo_second.SelectedIndexChanged += (s, e) =>
            {
                Settings.Default.SecondLanguage = combo_second.SelectedIndex;
                Settings.Default.Save();
            };

            // タイマー設定
            typingTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            typingTimer.Tick += (s, e) =>
            {
                typingTimer.Stop();
                Console.WriteLine("Typing finished.");
                ConvertText();
            };

            ActiveControl = textbox_orig;

            // キーボードフックの設定
            keyboardProc = KeyboardHookProc;
            using var curProcess = System.Diagnostics.Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule;
            hookId = SetWindowsHookEx(13, keyboardProc, LoadLibrary(curModule.ModuleName), 0);

            // タスクトレイアイコンの初期化
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("DualDeepLを終了する", null, OnTrayExitClicked);
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
            trayIcon.Click += (sender, args) => ShowWindow();

            FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// キーボードフック：Cキーが素早く2回押されたときフォームを表示
        /// </summary>
        private IntPtr KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            // ガード節により、条件を満たさない場合は即時リターン
            if (nCode < 0 || wParam != 0x100)
                return CallNextHookEx(hookId, nCode, wParam, lParam);

            var key = (Keys)Marshal.ReadInt32(lParam);
            if (key != Keys.C)
                return CallNextHookEx(hookId, nCode, wParam, lParam);

            // ここでCキーが押された。ダブルクリックチェック
            var elapsed = (DateTime.Now - lastCPressTime).TotalMilliseconds;
            if (!isCPressedOnce || elapsed >= 500)
            {
                isCPressedOnce = true;
                lastCPressTime = DateTime.Now;
                return CallNextHookEx(hookId, nCode, wParam, lParam);
            }

            // ダブルクリック判定成立
            Invoke(new MethodInvoker(() =>
            {
                Show();
                int y = Height;
                int x = Width;
                WindowState = FormWindowState.Normal;
                Height = y;
                Width = x;
                TopMost = true; // ウィンドウ最前面→戻す
                TopMost = false;
                textbox_orig.Text = Clipboard.GetText();
            }));
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        /// <summary>
        /// ユーザが入力を終えたタイミングで実行。翻訳処理を呼び出す。
        /// </summary>
        private async void ConvertText()
        {
            if (string.IsNullOrEmpty(textbox_orig.Text)) return;

            try
            {
                // 入力が確定したらGPT翻訳へ
                Translate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        /// <summary>
        /// テキストボックスの変更を監視して、一定時間入力がなければ翻訳呼び出し
        /// </summary>
        private void textbox_orig_TextChanged(object sender, EventArgs e)
        {
            typingTimer.Stop();
            typingTimer.Start();
        }

        /// <summary>
        /// GPT翻訳
        /// </summary>
        private async void Translate()
        {
            if (string.IsNullOrEmpty(textbox_convert.Text)) return;

            var orig = combo_orig.SelectedValue.ToString();
            var first = combo_first.SelectedValue.ToString();
            var second = combo_second.SelectedValue.ToString();

            try
            {
                var task1 = TranslateWithGPT(orig, first, textbox_orig, textbox_first, Settings.Default.Instruct1);
                var task2 = TranslateWithGPT(orig, second, textbox_orig, textbox_second, Settings.Default.Instruct2);
                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        /// <summary>
        /// 最初の翻訳ボックスが変わったらDeepLで逆翻訳
        /// </summary>
        private async void textbox_first_TextChanged(object sender, EventArgs e)
        {
            var orig = combo_orig.SelectedValue.ToString();
            var first = combo_first.SelectedValue.ToString();
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

        /// <summary>
        /// 2番目の翻訳ボックスが変わったらDeepLで逆翻訳
        /// </summary>
        private async void textbox_second_TextChanged(object sender, EventArgs e)
        {
            var orig = combo_orig.SelectedValue.ToString();
            var second = combo_second.SelectedValue.ToString();
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

        #region GPTエンジン

        /// <summary>
        /// ChatGPT で翻訳
        /// </summary>
        /// <param name="sourceLang"></param>
        /// <param name="targetLang"></param>
        /// <param name="input_textbox"></param>
        /// <param name="output_textbox"></param>
        /// <param name="instruct_text"></param>
        /// <returns></returns>
        private async Task TranslateWithGPT(string sourceLang, string targetLang,
                                            RichTextBox input_textbox, RichTextBox output_textbox,
                                            string instruct_text = "")
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Conversation chat = new OpenAIAPI(Settings.Default.APIKey).Chat.CreateConversation();
                chat.Model.ModelID = "chatgpt-4o-latest";

                var sourceLangCaption = src.First(r => r.LangCode.Equals(sourceLang)).Display;
                var targetLangCaption = src.First(r => r.LangCode.Equals(targetLang)).Display;

                // プロンプト生成
                var prompt = textbox_convert.Text
                    .Replace("{source}", sourceLangCaption)
                    .Replace("{target}", targetLangCaption)
                    + Environment.NewLine;

                if (string.IsNullOrWhiteSpace(instruct_text))
                {
                    prompt += input_textbox.Text;
                }
                else
                {
                    prompt += $@"
#原文
{input_textbox.Text}

#固有名詞
{instruct_text}

#出力
    ";
                }

                chat.AppendUserInput(prompt);
                var response = await chat.GetResponseFromChatbotAsync();
                output_textbox.Text = response;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region DeepL逆翻訳
        /// <summary>
        /// DeepLで逆翻訳するサンプルメソッド
        /// </summary>
        /// <param name="sourceLang">翻訳元言語</param>
        /// <param name="targetLang">翻訳先言語</param>
        /// <param name="input_textbox">翻訳元テキスト</param>
        /// <param name="output_textbox">翻訳結果表示</param>
        /// <returns></returns>
        private async Task Translate_DeepL(string sourceLang, string targetLang,
                                                 RichTextBox input_textbox, RichTextBox output_textbox)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ChatGPTにリクエストを送って翻訳する(DeepLの代わりにGPT利用サンプル)
                Conversation chat = new OpenAIAPI(Settings.Default.APIKey).Chat.CreateConversation();
                chat.Model.ModelID = "chatgpt-4o-latest";

                // DeepLライクに翻訳依頼するプロンプトの例

                var sourceLangCaption = src.First(r => r.LangCode.Equals(sourceLang)).Display;
                var targetLangCaption = src.First(r => r.LangCode.Equals(targetLang)).Display;
                /*
                var prompt = @"与えられた{source}の文章を、自然な話し言葉として、ニュアンスに忠実に{target}へ翻訳すると、どんな文章になりますか？
{source}を常用する人が抱くイメージをそのまま理解できるように、自然な表現の**{target}へ**翻訳した結果を出力して。翻訳後の{target}のみ出力してください。ダブルクォートや説明は不要です。"
                    .Replace("{source}", sourceLangCaption)
                    .Replace("{target}", targetLangCaption)
                    + Environment.NewLine
                    + input_textbox.Text;
                */
                var prompt = @"与えられた{source}の文章を、自然な話し言葉として、ニュアンスに忠実に{target}へ翻訳すると、どんな文章になりますか？
{source}を常用する人が抱くイメージをそのまま理解できるように、自然な表現の**{target}へ**翻訳した結果を出力してください。
翻訳結果を出力した後、翻訳元の文章の理解を深めるために、以下の４点を併記してください。
- 元の文章の翻訳結果
- 元の文章の説明
- 元の文章の背景や場面など
- それぞれの言葉のニュアンス"
    .Replace("{source}", sourceLangCaption)
    .Replace("{target}", targetLangCaption)
    + Environment.NewLine
    + input_textbox.Text;
                chat.AppendUserInput(prompt);
                var response = await chat.GetResponseFromChatbotAsync();
                output_textbox.Text = response;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region イベント・その他

        private void button1_Click(object sender, EventArgs e)
        {
            new InstructionForm().ShowDialog(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new InstructionForm().ShowDialog(2);
        }

        /// <summary>
        /// チェックボックスでトップ表示固定
        /// </summary>
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // if文のみ、else不要
            button1.Enabled = !checkBox1.Checked;
            button2.Enabled = !checkBox1.Checked;
            TopMost = checkBox1.Checked;
        }

        /// <summary>
        /// フォームを閉じる前のイベント
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 常にプロンプトをセーブ
            Settings.Default["Prompt"] = textbox_convert.Text;
            Settings.Default.Save();

            // ユーザークローズのときのみトレイに格納
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// タスクトレイからフォームを表示
        /// </summary>
        private void ShowWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;
            TopMost = false;
        }

        /// <summary>
        /// タスクトレイで終了クリックされたときの処理
        /// </summary>
        private void OnTrayExitClicked(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// フォームロード時の初期処理
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Settings.Default["Prompt"].ToString()))
            {
                textbox_convert.Text =
@"マンガのキャラクターのセリフを翻訳したい。以下の文章を、可能な限り原文のニュアンスを踏まえて{source}から{target}へ翻訳してください。
ただし、#固有名詞 に記載された特定用語・固有名詞は英語表記を優先し、示すとおりに訳してください。:";
            }
            else
            {
                textbox_convert.Text = Settings.Default["Prompt"].ToString();
            }
        }
        #endregion
    }

    /// <summary>
    /// 言語用のDisplayとコードをペアにするクラス
    /// </summary>
    public class ItemSet
    {
        public string Display { get; set; }
        public string LangCode { get; set; }

        public ItemSet(string langCode, string display)
        {
            LangCode = langCode;
            Display = display;
        }
    }

    #region 共通ユーティリティクラス
    /// <summary>
    /// グローバルユーティリティ
    /// </summary>
    public static class GlbUtil
    {
        // JSON Serializer設定
        public static JsonSerializerOptions GetJsonSerializerOptionsDefault() =>
            new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNameCaseInsensitive = true
            };
    }
    #endregion

    #region DeepLレスポンスクラス
    /// <summary>
    /// DeepL翻訳APIからのレスポンス例
    /// </summary>
    public class TrnResponse
    {
        [JsonPropertyName("translations")]
        public List<TrnResponseBody> Translations { get; set; }
    }

    /// <summary>
    /// DeepL翻訳APIからの個別翻訳結果
    /// </summary>
    public class TrnResponseBody
    {
        [JsonPropertyName("detected_source_language")]
        public string DetectedSourceLanguage { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
    #endregion
}