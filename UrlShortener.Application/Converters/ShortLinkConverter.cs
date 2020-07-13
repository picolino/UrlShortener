using UrlShortener.Application.Domain;
using UrlShortener.DataContext.Entities;

namespace UrlShortener.Application.Converters
{
    public static class ShortLinkConverter
    {
        public static ShortLinkData ToDomain(ShortLink shortLink)
        {
            return new ShortLinkData(shortLink.SourceUrl, shortLink.ShortUrl, shortLink.ReceiveCounter);
        }
    }
}