using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace backend.Models
{
    public enum PhoneType
    {
        COMMERCIAL,
        RESIDENTIAL
    }

    public class Phone
    {
        public string Number { get; set; }

        [BsonRepresentation(BsonType.String)]

        public PhoneType Type { get; set; }
    }
}