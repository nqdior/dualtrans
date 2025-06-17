using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using DualDeepL.Models;
using DualDeepL.Properties;
using DualDeepL.Utils;

namespace DualDeepL.Services
{
    public class DeepLTranslationService : ITranslationService
    {
        public async Task<string> TranslateAsync(string sourceLang, string targetLang, string text, string instruction = "")
        {
            using var httpClient = new HttpClient();
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
            {
                request.Headers.TryAddWithoutValidation("Authorization", "DeepL-Auth-Key " + Settings.Default.DeepLKey);
                var contentList = new List<string>
                {
                    "text=" + text,
                    "source_lang=" + sourceLang,
                    "target_lang=" + targetLang
                };
                request.Content = new StringContent(string.Join("&", contentList));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                var response = await httpClient.SendAsync(request);
                var resBodyStr = await response.Content.ReadAsStringAsync();
                TrnResponse trnResponse = JsonSerializer.Deserialize<TrnResponse>(resBodyStr, GlbUtil.GetJsonSerializerOptionsDefault());
                
                if (trnResponse?.Translations != null && trnResponse.Translations.Count > 0)
                {
                    return trnResponse.Translations[0].Text;
                }
                
                return "translation error.";
            }
        }
    }
}