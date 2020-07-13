﻿using System.Threading.Tasks;
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
            return await shortenerService.GetShortenUrlAsync(url);
        }

        [HttpGet]
        [Route("{shortenUrl}")]
        public async Task<string> GetSourceUrlByShortenUrlAsync(string shortenUrl)
        {
            return await shortenerService.GetSourceUrlByShortenUrlAsync(shortenUrl);
        }
    }
}