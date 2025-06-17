using System.Collections.Generic;
using System.Linq;

namespace DualDeepL.Models
{
    public class LanguageManager
    {
        private static readonly List<ItemSet> _languages = new()
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
            new ItemSet("NL", "オランダ語"),
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
            new ItemSet("ZH", "中国語(簡体字)")
        };

        public static List<ItemSet> GetLanguages() => new(_languages);

        public static ItemSet GetLanguageByCode(string langCode)
        {
            return _languages.First(r => r.LangCode.Equals(langCode));
        }
    }

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
}