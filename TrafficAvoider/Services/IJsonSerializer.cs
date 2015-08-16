namespace TrafficAvoider.Services
{
    public interface IJsonSerializer
    {
        T Deserialize<T>(string serializedObject);
        string Serialize(object objectToSerialize);
    }
}
