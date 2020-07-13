using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Controllers
{
    [ApiController]
    public class ShortenerController : ControllerBase
    {
        private readonly ShortenerService shortenerService;

        public ShortenerController(ShortenerService shortenerService)
        {
            this.shortenerService = shortenerService;
        }
        
        [HttpGet]
        [Route("shrink")]
        public async Task<string> GetShortenUrlAsync(string url)
        {
            var hasUserId = HttpContext.Request.Cookies.ContainsKey(Definitions.UserIdCookieKey);

            Guid userId;
            
            if (hasUserId)
            {
                userId = Guid.Parse(HttpContext.Request.Cookies[Definitions.UserIdCookieKey]);
            }
            else
            {
                userId = Guid.NewGuid();
                HttpContext.Response.Cookies.Append(Definitions.UserIdCookieKey, userId.ToString());
            }
            
            return await shortenerService.GetShortenUrlAsync(url, userId);
        }

        [HttpGet]
        [Route("{shortenUrl}")]
        public async Task<IActionResult> GetSourceUrlByShortenUrlAsync(string shortenUrl)
        {
            var url = await shortenerService.GetSourceUrlByShortenUrlAsync(shortenUrl);
            return Redirect(url);
        }
    }
}