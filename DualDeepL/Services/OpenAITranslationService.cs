using System;
using System.Linq;
using System.Threading.Tasks;
using DualDeepL.Models;
using DualDeepL.Properties;

namespace DualDeepL.Services
{
    public class OpenAITranslationService : ITranslationService
    {
        public async Task<string> TranslateAsync(string sourceLang, string targetLang, string text, string instruction = "")
        {
            try
            {
                var api = new OpenAI_API.OpenAIAPI(Settings.Default.APIKey);
                var chat = api.Chat.CreateConversation();
                chat.Model.ModelID = "gpt-4o-2024-05-13";

                var languages = LanguageManager.GetLanguages();
                var sourceLangCaption = languages.First(r => r.LangCode.Equals(sourceLang)).Display;
                var targetLangCaption = languages.First(r => r.LangCode.Equals(targetLang)).Display;

                var prompt = BuildPrompt(sourceLangCaption, targetLangCaption, text, instruction);
                chat.AppendUserInput(prompt);

                string response = await chat.GetResponseFromChatbotAsync();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string BuildPrompt(string sourceLangCaption, string targetLangCaption, string text, string instruction)
        {
            if (string.IsNullOrEmpty(instruction))
            {
                return $@"以下の文章を、{sourceLangCaption}から{targetLangCaption}へ翻訳してください:" + Environment.NewLine + text;
            }

            return $@"#原文 に書かれた{sourceLangCaption}の文章を{targetLangCaption}へ翻訳してください。
翻訳の表記は #表記ルール に書かれた指示に従ってください。

#原文
{text}

#表記ルール 
{instruction}

#出力
    ";
        }
    }
}