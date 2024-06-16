using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityLib
{
    public class OrderItem
    {
        [BsonElement("bookId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BookId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}