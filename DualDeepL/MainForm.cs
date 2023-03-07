using DualDeepL.Properties;
using Syncfusion.WinForms.ListView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.AxHost;

namespace DualDeepL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

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

            this.ActiveControl = this.textbox_orig;
        }

        private void orig_textbox_Leave(object sender, EventArgs e)
        {
            textbox_first.Text = string.Empty;
            textbox_re_first.Text = string.Empty;
            textbox_second.Text = string.Empty;
            textbox_re_second.Text = string.Empty;

            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            try
            {
                Translate(orig, first, textbox_orig, textbox_first);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private void first_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try
            {
                Translate(first, orig, textbox_first, textbox_re_first);
                Translate(first, second, textbox_first, textbox_second);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
}

        private void second_textbox_TextChanged(object sender, EventArgs e)
        {
            string orig = combo_orig.SelectedValue.ToString();
            string first = combo_first.SelectedValue.ToString();
            string second = combo_second.SelectedValue.ToString();
            try 
            { 
            Translate(second, orig, textbox_second, textbox_re_second);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.InnerException
                    + Environment.NewLine + ex.Message
                    + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + ex.HelpLink);
            }
        }

        private async void Translate(String sourceLang, String targetLang, RichTextBox input_textbox, RichTextBox output_textbox)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "DeepL-Auth-Key " + Settings.Default.APIKey);

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
                    GlbResponseBody glbResponseBody = new GlbResponseBody();
                    glbResponseBody.Text = trnResponse.Translations.Count > 0 ? trnResponse.Translations[0].Text : "translation error.";

                    output_textbox.Text = glbResponseBody.Text;
                }
            }
        }

    }

    public class ItemSet
    {
        // DisplayMemberとValueMemberにはプロパティで指定する仕組み
        public String Display { get; set; }
        public String LangCode { get; set; }

        // プロパティをコンストラクタでセット
        public ItemSet(String v, String s)
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