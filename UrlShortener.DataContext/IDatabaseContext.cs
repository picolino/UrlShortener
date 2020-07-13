using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.DataContext
{
    public interface IDatabaseContext
    {
        Task SaveShortLinkAsync(Guid userId, string sourceUrl, string shortUrl);
        Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl);
        Task<IEnumerable<ShortLink>> GetAllShortLinksAsync();
        Task<IEnumerable<ShortLink>> GetAllShortLinksByUserIdAsync(Guid userId);
        Task IncrementShortLinkReceiveCounter(Guid shortLinkId);
    }
}