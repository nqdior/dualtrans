using System;
using System.Windows.Forms;

namespace DualDeepL.Utils
{
    public static class ErrorHandler
    {
        public static void ShowUserFriendlyError(string operation, Exception ex)
        {
            string userMessage = GetUserFriendlyMessage(operation, ex);
            MessageBox.Show(userMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static string GetUserFriendlyMessage(string operation, Exception ex)
        {
            return operation switch
            {
                "Translation" => "翻訳に失敗しました。APIキーの設定とネットワーク接続を確認してください。",
                "Settings" => "設定の保存に失敗しました。",
                "Clipboard" => "クリップボードの読み取りに失敗しました。",
                _ => $"操作「{operation}」でエラーが発生しました。しばらく時間を置いてから再試行してください。"
            };
        }

        public static bool ValidateApiKeys()
        {
            bool hasOpenAIKey = !string.IsNullOrWhiteSpace(Properties.Settings.Default.APIKey);
            bool hasDeepLKey = !string.IsNullOrWhiteSpace(Properties.Settings.Default.DeepLKey);

            if (!hasOpenAIKey && !hasDeepLKey)
            {
                MessageBox.Show("OpenAI または DeepL のAPIキーが設定されていません。設定を確認してください。", 
                    "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}