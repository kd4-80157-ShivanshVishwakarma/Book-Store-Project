using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityLib
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BookId { get; set; }

        [BsonElement("isbn")]
        public string Isbn { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("authors")]
        public List<string> Authors { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("publisher")]
        public string? Publisher { get; set; }

        [BsonElement("publishDate")]
        public DateTime PublishDate { get; set; }
    }
}