using System;
using System.Linq;
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
        [Repeat(50)]
        public async Task EqualSourceUrlsMustHaveDifferentShortUrls()
        {
            var sourceUrl = "https://google.com/";
            
            var url1 = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            var url2 = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(url1, Is.Not.EqualTo(url2));
        }

        [Test]
        public async Task LargeSourceUrlProducesLessOrEqualSixLengthShortUrl()
        {
            var largeUrl = @"https://google.com/asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq
asdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweqasdweq";
            
            var url = await ShortenerService.GetShortenUrlAsync(largeUrl, Guid.Empty);
            
            Assert.That(url.Length, Is.LessThanOrEqualTo(6));
        }

        [Test]
        public async Task DatabaseMustHaveGeneratedShortLinks()
        {
            var sourceUrl = "https://google.com/";
            
            await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(DatabaseContextStub.ShortLinks, Is.Not.Empty);
        }

        [Test]
        public async Task DatabaseMustHaveRecordWithEqualSourceUrl()
        {
            var sourceUrl = "https://google.com/";
            
            await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(DatabaseContextStub.ShortLinks.Single().SourceUrl, Is.EqualTo(sourceUrl));
        }

        [Test]
        public async Task DatabaseMustHaveRecordWithEqualShortUrl()
        {
            var sourceUrl = "https://google.com/";
            
            var url = await ShortenerService.GetShortenUrlAsync(sourceUrl, Guid.Empty);
            
            Assert.That(DatabaseContextStub.ShortLinks.Single().ShortUrl, Is.EqualTo(url));
        }

        [Test]
        public async Task DatabaseMustHaveRecordWithEqualUserId()
        {
            var sourceUrl = "https://google.com/";
            var userId = Guid.NewGuid();
            
            await ShortenerService.GetShortenUrlAsync(sourceUrl, userId);
            
            Assert.That(DatabaseContextStub.ShortLinks.Single().UserId, Is.EqualTo(userId));
        }
    }
}