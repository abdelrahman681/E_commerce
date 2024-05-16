using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Entity.OrderEntity
{
    [JsonConverter(typeof(JsonStringEnumConverter))]    
    public enum PayMentStatus
    {
        pending ,Filed, Receved
    }
}
