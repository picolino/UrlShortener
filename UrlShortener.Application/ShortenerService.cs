using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using UrlShortener.Application.Helpers;
using UrlShortener.DataContext;

namespace UrlShortener.Application
{
    public class ShortenerService
    {
        private readonly IDatabaseContext databaseContext;

        public ShortenerService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        
        public async Task<string> GetShortenUrlAsync(string sourceUrl, Guid userId)
        {
            var objectId = ObjectId.GenerateNewId();

            var shortenUrl = Base64IntToStringEncoder.Encode(objectId.GetHashCode());
            
            await databaseContext.SaveShortLinkAsync(objectId, userId, sourceUrl, shortenUrl);
            
            return shortenUrl;
        }

        public async Task<string> GetSourceUrlByShortenUrlAsync(string shortUrl)
        {
            var shortLink = await databaseContext.GetShortLinkByShortUrlAsync(shortUrl);

            if (shortLink is null)
            {
                return null;
            }
            
            await databaseContext.IncrementShortLinkReceiveCounter(shortLink.Id);

            return shortLink.SourceUrl;
        }
    }
}