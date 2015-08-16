using Newtonsoft.Json;

namespace TrafficAvoider.Services.Implementation
{
    public class JsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}
