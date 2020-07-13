using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.Tests.UnitTests.ShortenerService
{
    public class WhenGetSourceUrl : ShortenerServiceTestBase
    {
        [Test]
        public void ExceptionMustThrowsIfNoSuchShortUrlFound()
        {
            const string shortUrl = "fh84ea";

            Assert.ThrowsAsync<InvalidOperationException>(() => ShortenerService.GetSourceUrlByShortenUrlAsync(shortUrl));
        }
        
        [Test]
        public async Task SourceUrlMustBeReturned()
        {
            const string expectedSourceUrl = "https://google.com/";
            const string shortUrl = "fh84ea";
            DatabaseContextStub.ShortLinks.Add(new ShortLink{ShortUrl = shortUrl, SourceUrl = expectedSourceUrl});

            var sourceUrl = await ShortenerService.GetSourceUrlByShortenUrlAsync(shortUrl);

            Assert.That(sourceUrl, Is.EqualTo(expectedSourceUrl));
        }

        [Test]
        public async Task ReceiveCountIncrementShouldBeApplied()
        {
            const string shortUrl = "fh84ea";
            var shortLing = new ShortLink {ShortUrl = "fh84ea", SourceUrl = "https://google.com/"};
            DatabaseContextStub.ShortLinks.Add(shortLing);

            await ShortenerService.GetSourceUrlByShortenUrlAsync(shortUrl);

            Assert.That(shortLing.ReceiveCounter, Is.EqualTo(1));
        }
    }
}