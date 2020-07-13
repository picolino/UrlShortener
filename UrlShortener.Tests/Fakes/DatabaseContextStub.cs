using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using UrlShortener.DataContext;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.Tests.Fakes
{
    public class DatabaseContextStub : IDatabaseContext
    {
        public List<ShortLink> ShortLinks { get; set; } = new List<ShortLink>();
        
        public Task SaveShortLinkAsync(ObjectId id, Guid userId, string sourceUrl, string shortUrl)
        {
            ShortLinks.Add(new ShortLink
                           {
                               Id = id,
                               SourceUrl = sourceUrl,
                               ShortUrl = shortUrl,
                               UserId = userId
                           });
            
            return Task.CompletedTask;
        }

        public Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl)
        {
            return Task.FromResult(ShortLinks.First(o => o.ShortUrl == shortUrl));
        }

        public Task IncrementShortLinkReceiveCounter(ObjectId shortLinkId)
        {
            var shortLink = ShortLinks.First(o => o.Id == shortLinkId);
            shortLink.ReceiveCounter++;
            
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ShortLink>> GetAllShortLinksAsync()
        {
            return Task.FromResult<IEnumerable<ShortLink>>(ShortLinks);
        }

        public Task<IEnumerable<ShortLink>> GetAllShortLinksByUserIdAsync(Guid userId)
        {
            return Task.FromResult(ShortLinks.Where(o => o.UserId == userId));
        }
    }
}