using System.Threading.Tasks;

namespace DualDeepL.Services
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string sourceLang, string targetLang, string text, string instruction = "");
    }
}