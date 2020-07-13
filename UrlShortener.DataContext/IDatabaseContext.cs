using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.DataContext
{
    public interface IDatabaseContext
    {
        Task SaveShortLinkAsync(ObjectId id, Guid userId, string sourceUrl, string shortUrl);
        Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl);
        Task IncrementShortLinkReceiveCounter(ObjectId shortLinkId);
        Task<IEnumerable<ShortLink>> GetAllShortLinksAsync();
        Task<IEnumerable<ShortLink>> GetAllShortLinksByUserIdAsync(Guid userId);
    }
}