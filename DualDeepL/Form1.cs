using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DualDeepL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void orig_textbox_Leave(object sender, EventArgs e)
        {
            first_textbox.Text = string.Empty;
            re_first_textbox.Text = string.Empty;
            second_textbox.Text = string.Empty;
            re_second_textbox.Text = string.Empty;

            Transrate("JA", "EN", orig_textbox, first_textbox);
        }

        private void first_textbox_TextChanged(object sender, EventArgs e)
        {
            Transrate("EN", "JA", first_textbox, re_first_textbox);
            Transrate("EN", "ZH", first_textbox, second_textbox);
        }
        private void second_textbox_TextChanged(object sender, EventArgs e)
        {
            Transrate("ZH", "JA", second_textbox, re_second_textbox);
        }

        private async void Transrate(String sourceLang, String targetLang, RichTextBox input_textbox, RichTextBox output_textbox)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "DeepL-Auth-Key xxxxxxxxxxxxxxxxxxxxx:fx");

                    var contentList = new List<string>();
                    contentList.Add("text=" + input_textbox.Text);
                    contentList.Add("source_lang=" + sourceLang);
                    contentList.Add("target_lang=" + targetLang);
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