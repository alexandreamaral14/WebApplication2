using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication2.Mapper;
using WS.DAL.DALService;
using WS.Service.Services.Stories;

namespace UnitTestProject1
{
    [TestClass]
    public class StoriesServiceUT
    {
        private IStoriesService storyService;
        [TestInitialize]
        public void Init()
        {
            IStoryDALService storyDALService = new StoryDALService();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<StoriesProfile>();
            });
            IMapper mapper = config.CreateMapper();

            storyService = new StoriesService(storyDALService, mapper);
        }


        [TestMethod]
        public void ReadTopStories()
        {
            var result = storyService.ListBestStories(20);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count() == 20);
        }
    }
}
