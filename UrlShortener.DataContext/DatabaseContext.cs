using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.DataContext
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoCollection<ShortLink> shortLinksCollection;
        
        public DatabaseContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("url-shortener");
            shortLinksCollection = database.GetCollection<ShortLink>("short-links");
        }

        public async Task SaveShortLinkAsync(Guid userId, string sourceUrl, string shortUrl)
        {
            await shortLinksCollection.InsertOneAsync(new ShortLink
                                                      {
                                                          SourceUrl = sourceUrl,
                                                          ShortUrl = shortUrl,
                                                          UserId = userId
                                                      });
        }

        public async Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl)
        {
            return await shortLinksCollection.Find(o => o.ShortUrl == shortUrl).FirstAsync();
        }

        public async Task IncrementShortLinkReceiveCounter(Guid shortLinkId)
        {
            await shortLinksCollection.UpdateOneAsync(o => o.Id == shortLinkId, Builders<ShortLink>.Update.Inc(o => o.ReceiveCounter, 1));
        }

        public async Task<IEnumerable<ShortLink>> GetAllShortLinksAsync()
        {
            return await GetShortLinksInternalAsync(o => true);
        }
        
        public async Task<IEnumerable<ShortLink>> GetAllShortLinksByUserIdAsync(Guid userId)
        {
            return await GetShortLinksInternalAsync(o => o.UserId == userId);
        }
        
        private async Task<IEnumerable<ShortLink>> GetShortLinksInternalAsync(Expression<Func<ShortLink, bool>> filter)
        {
            var documents = await shortLinksCollection.Find(filter).ToCursorAsync();
            return documents.ToEnumerable();
        }
    }
}