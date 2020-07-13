using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace UrlShortener.DataContext.Entities
{
    public class ShortLink
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        public string SourceUrl { get; set; }
        public string ShortUrl { get; set; }
        public int ReceiveCounter { get; set; }
        public Guid UserId { get; set; }
    }
}