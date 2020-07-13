using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UrlShortener.Tests.UnitTests.ShortenerService
{
    public class WhenGetShortenUrl : ShortenerServiceTestBase
    {
        [Test]
        [Repeat(50)]
        public async Task ShortUrlMustBeNonEmpty()
        {
            var sourceUrl = "https://google.com/";
            
            var url = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(url, Is.Not.Empty);
        }
        
        [Test]
        public async Task EqualSourceUrlsMustHaveDifferentShortUrls()
        {
            var sourceUrl = "https://google.com/";
            
            var url1 = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            var url2 = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(url1, Is.Not.EqualTo(url2));
        }
    }
}