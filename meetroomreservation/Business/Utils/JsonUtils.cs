using System.Text.Encodings.Web;
using System.Text.Json;

namespace meetroomreservation.Business.Utils
{
    public class JsonUtils
    {
        public static string ObjectToStringFormat<T>(T model)
        {
            if (model is null)
            {
                return "";
            }
            return JsonSerializer.Serialize(model, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            });
        }

        public static T DataToObject<T>(T data)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(data));
        }
    }
}