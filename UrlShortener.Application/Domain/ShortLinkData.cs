namespace UrlShortener.Application.Domain
{
    public class ShortLinkData
    {
        public ShortLinkData(string sourceUrl, string shortUrl, int receiveCounter)
        {
            SourceUrl = sourceUrl;
            ShortUrl = shortUrl;
            ReceiveCounter = receiveCounter;
        }

        public string SourceUrl { get; }
        public string ShortUrl { get; }
        public int ReceiveCounter { get; }
    }
}