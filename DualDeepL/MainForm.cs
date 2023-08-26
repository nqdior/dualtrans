using DualDeepL.Properties;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DualDeepL
{
    public partial class MainForm : Form
    {

        List<ItemSet> src = new List<ItemSet>
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

            Console.WriteLine(Properties.Resources.ResourceManager);
            List<ItemSet> src2 = new List<ItemSet>(src);
            List<ItemSet> src3 = new List<ItemSet>(src);

            combo_orig.DataSource = src;
            combo_orig.DisplayMember = "Display";
            combo_orig.ValueMember = "LangCode";
            combo_orig.SelectedIndex = 15;

            combo_first.DataSource = src2;
            combo_first.DisplayMember = "Display";
            combo_first.ValueMember = "LangCode";
            combo_first.SelectedIndex = 5;

            combo_second.DataSource = src3;
            combo_second.DisplayMember = "Display";
            combo_second.ValueMember = "LangCode";
            combo_second.SelectedIndex = 31;

            instruct_first.Text = Settings.Default.Instruct1;
            instruct_second.Text = Settings.Default.Instruct2;

            this.ActiveControl = this.textbox_orig;
        }

        private async void orig_textbox_Leave(object sender, EventArgs e)
        {
            if (textbox_orig.Text == string.Empty) return;

            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            try
            {
                await Translate(orig, first, textbox_orig, textbox_first, instruct_first);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async void first_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try
            {
                await Translate(first, orig, textbox_first, textbox_re_first);
                await Translate(orig, second, textbox_orig, textbox_second, instruct_second);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async void second_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try
            {
                await Translate(second, orig, textbox_second, textbox_re_second);
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

        public async Task Translate(string sourceLang, string targetLang, RichTextBox input_textbox, RichTextBox output_textbox, RichTextBox instruct_box = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var api = new OpenAI_API.OpenAIAPI(Settings.Default.APIKey);
                var chat = api.Chat.CreateConversation();
                chat.Model.ModelID = "gpt-3.5-turbo-0613-16k";

                var sourceLangCaption = src.First(r => r.LangCode.Equals(sourceLang)).Display;
                var targetLangCaption = src.First(r => r.LangCode.Equals(targetLang)).Display;

                var prompt = $@"以下の文章を、{sourceLangCaption}から、{targetLangCaption}に翻訳してください。:";
                prompt += $"{input_textbox.Text}";

                if (instruct_box != null)
                {
                    if (instruct_box.Text != string.Empty)
                    {
                        prompt = $@"#原文 にある{sourceLangCaption}の文章を{targetLangCaption}に翻訳してください。
訳文の表記は #表記ルール に書かれた指示に従ってください。
#表記ルール 
{instruct_box.Text}

#原文
{input_textbox.Text}
    ";
                    }
                }
                chat.AppendUserInput(prompt);

                // ChatGPTの回答
                string response = await chat.GetResponseFromChatbotAsync();
                output_textbox.Text = response;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Instruct1 = instruct_first.Text;
            Settings.Default.Instruct2 = instruct_second.Text;
            Settings.Default.Save();
        }
    }

    public class ItemSet
    {
        public String Display { get; set; }
        public String LangCode { get; set; }

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
            catch (System.Exception e)
            {
                throw e;
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
            catch (System.Exception e)
            {
                throw e;
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