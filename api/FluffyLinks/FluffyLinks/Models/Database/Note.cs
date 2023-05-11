using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FluffyLinks.Models.Database
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string HighlightedText { get; set; }    

        public string UserId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
