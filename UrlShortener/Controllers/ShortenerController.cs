using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Controllers
{
    [ApiController]
    public class ShortenerController : ControllerBase
    {
        private ShortenerService ShortenerService => new ShortenerService();
        
        [HttpGet]
        [Route("/short")]
        public string GetShortenUrl(string sourceUrl)
        {
            return ShortenerService.GetShortenUrl(sourceUrl);
        }

        [HttpGet]
        [Route("/source")]
        public string GetSourceUrlByShortenUrl(string shortenUrl)
        {
            return ShortenerService.GetSourceUrlByShortenUrl(shortenUrl);
        }
    }
}