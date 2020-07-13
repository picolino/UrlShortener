using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UrlShortener.DataContext.Entities
{
    public class ShortLink
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string SourceUrl { get; set; }
        public string ShortUrl { get; set; }
        public int ReceiveCounter { get; set; }
        public Guid UserId { get; set; }
    }
}