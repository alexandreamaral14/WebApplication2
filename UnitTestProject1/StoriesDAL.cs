using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WS.DAL.DALService;

namespace UnitTestProject1
{
    [TestClass]
    public class StoriesDAL
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
    }
}
