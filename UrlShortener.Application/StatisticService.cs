using System;
using System.Collections.Generic;
using UrlShortener.Application.Converters;
using UrlShortener.Application.Domain;
using UrlShortener.DataContext;

namespace UrlShortener.Application
{
    public class StatisticService
    {
        private readonly IDatabaseContext databaseContext;

        public StatisticService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        
        public async IAsyncEnumerable<ShortLinkData> GetShortUrlsDataAllAsync()
        {
            var documents = await databaseContext.GetAllShortLinksAsync();

            foreach (var shortLink in documents)
            {
                yield return ShortLinkConverter.ToDomain(shortLink);
            }
        }

        public async IAsyncEnumerable<ShortLinkData> GetShortUrlsDataByUserAsync(Guid userId)
        {
            var documents = await databaseContext.GetAllShortLinksByUserIdAsync(userId);

            foreach (var shortLink in documents)
            {
                yield return ShortLinkConverter.ToDomain(shortLink);
            }
        }
    }
}