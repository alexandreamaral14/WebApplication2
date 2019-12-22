using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WS.DAL.DALService;
using WS.DAL.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class StoriesDALUT
    {
        private IStoryDALService storyDALService;
        [TestInitialize]
        public void Init()
        {
            storyDALService = new StoryDALService();
        }
       
        [TestMethod]
        public void TopStories()
        {
            var result = storyDALService.ListBestStories(20).Count();

            Assert.IsNotNull(result);
            Assert.IsTrue(storyDALService.ListBestStories(20).Count() == 20);
        }

        [TestMethod]
        public void ReadTopStories()
        {
            var resultIndex = storyDALService.ListBestStories(20);
          
            Assert.IsNotNull(resultIndex);
            Assert.IsTrue(resultIndex.Count() == 20);

            foreach(var news in resultIndex)
            {
                Assert.IsNotNull(news);
            }
        }
    }
}
