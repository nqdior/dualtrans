using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DualDeepL.Utils
{
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
}