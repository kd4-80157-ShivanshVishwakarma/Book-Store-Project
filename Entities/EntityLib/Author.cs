using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Net.Sockets;
namespace EntityLib
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AuthorId { get; set; }

        [BsonElement("authorName")]
        public string AuthorName { get; set; }

        [BsonElement("authorAddress")]
        public Address AuthorAddress { get; set; }


    }
}