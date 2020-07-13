using System;
using System.Threading.Tasks;
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
        
        public Task<string> GetShortenUrlAsync(string sourceUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetSourceUrlByShortenUrlAsync(string shortUrl)
        {
            var shortLink = await databaseContext.GetShortLinkByShortUrlAsync(shortUrl);
            
            await databaseContext.IncrementShortLinkReceiveCounter(shortLink.Id);

            return shortLink.SourceUrl;
        }
    }
}