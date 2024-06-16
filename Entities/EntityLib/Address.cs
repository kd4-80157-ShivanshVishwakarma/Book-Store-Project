using MongoDB.Bson.Serialization.Attributes;

namespace EntityLib
{
    public class Address
    {
        [BsonElement("country")]
        public string country { get; set; }

        [BsonElement("state")]
        public string state { get; set; }

    }
}