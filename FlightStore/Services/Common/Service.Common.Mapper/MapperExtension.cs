using System.Text.Json;

namespace Service.Common.Mapper
{
    public static class MapperExtension
    {
        public static T MapTo<T>(this object valueObject)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(valueObject));
        }
    }
}
