using System;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("/statistics/")]
    public class StatisticController : ControllerBase
    {
        private StatisticService StatisticService => new StatisticService();
        
        [HttpGet]
        [Route("/all")]
        public string GetShortUrlsDataAll()
        {
            return StatisticService.GetShortUrlsDataAll();
        }

        [HttpPost]
        [Route("/user")]
        public string GetShortUrlsDataByUser(Guid userId)
        {
            return StatisticService.GetShortUrlsDataByUser(userId);
        }
    }
}