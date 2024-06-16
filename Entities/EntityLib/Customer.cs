using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityLib
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CustomerId { get; set; }

        [BsonElement("custName")]
        public string CustomerName { get; set; }

        [BsonElement("emailId")]
        public string EmailId { get; set; }

        [BsonElement("mobileNo")]
        public string? MobileNo { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }
    }
}