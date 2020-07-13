using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Application.Domain;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class StatisticController : ControllerBase
    {
        private readonly StatisticService statisticService;

        public StatisticController(StatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        
        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<ShortLinkData> GetShortUrlsDataAllAsync()
        {
            var documents = statisticService.GetShortUrlsDataAllAsync();
            await foreach (var document in documents)
            {
                yield return document;
            }
        }

        [HttpGet]
        [Route("user")]
        public async IAsyncEnumerable<ShortLinkData> GetShortUrlsDataByUserAsync()
        {
            var userId = Guid.Parse(HttpContext.Request.Cookies[Definitions.UserIdCookieKey]);
            
            var documents = statisticService.GetShortUrlsDataByUserAsync(userId);
            await foreach (var document in documents)
            {
                yield return document;
            }
        }
    }
}