using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WS.DTO.DTOs;
using WS.Service.Services.Stories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IStoriesService storiesService;
        private IMapper mapper;
        public NewsController(IStoriesService storiesService, IMapper mapper)
        {
            this.storiesService = storiesService;
            this.mapper = mapper;
        }


        /// <summary>
        /// List stories of WS
        /// </summary>
        /// <param name="numberstories">any number => 0</param>
        /// <returns></returns>
        [HttpGet("{numberstories}")]
        public ActionResult<IEnumerable<NewsModel>> Get(int numberstories)
        {
            if (numberstories == default(int) || numberstories <= 0)
                return BadRequest();

            return Ok(mapper.Map<IEnumerable<StorieDTO>, IEnumerable<NewsModel>>(storiesService.ListBestStories(numberstories)));
        }


    }
}
