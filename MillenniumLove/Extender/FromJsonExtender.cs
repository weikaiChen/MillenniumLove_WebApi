using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace MillenniumLove
{
    public static class FromJsonExtender
    {
        /// <summary>
        /// 將json字串轉成相對應的class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string value)
        {
            T result = default(T); ;
            var t = typeof(T);
            if (!t.IsPrimitive
                && !t.Is<string>()
                && !t.Is<byte[]>())
            {
                try
                {
                    result = JsonConvert
                        .DeserializeObject<T>(value);
                    return result;
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

        private static bool IsJson(string json)
        {
            if (json.NullOrEmpty()) { return false; }
            json = json.Trim();

            if (
                (json.StartsWith("{") && json.EndsWith("}"))
                ||
                (json.StartsWith("[") && json.EndsWith("]")))
            {
                // go on
            }
            else
            {
                return false;
            }

            try
            {
                var obj = JToken.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
