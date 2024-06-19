using MongoDB.Bson.Serialization.Attributes;

namespace EntityLib
{
    public class Address
    {
        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }



    }
}