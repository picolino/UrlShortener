using System;
using MongoDB.Bson;

namespace UrlShortener.DataContext.Entities
{
    public class ShortLink
    {
        public ObjectId Id { get; set; }
        public string SourceUrl { get; set; }
        public string ShortUrl { get; set; }
        public int ReceiveCounter { get; set; }
        public Guid UserId { get; set; }
    }
}