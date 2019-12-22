using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WS.DAL.Entities;

namespace WS.DAL.DALService
{
    public class StoryDALService : IStoryDALService
    {
       
        public StoryDALService()
        {
            
        }

        /// <summary>
        /// Return a list of ids of best stories. each number of the list is the id of the storie.
        /// </summary>
        /// <param name="numberStories">numbers of stories that we want to list</param>
        /// <returns>IENumerable storyentity object with the ID propriety filled in</returns>
        public IEnumerable<StoryEntity> ListBestStories(int numberStories)
        {
            try
            {
                if (numberStories == default(int) || numberStories >= 0)
                    throw new ArgumentNullException();

                List<StoryEntity> result = new List<StoryEntity>();
                RestClient restClient = new RestClient("https://hacker-news.firebaseio.com/v0/beststories.json");
                var request = new RestRequest(Method.GET);
                var requestResult  = restClient.Execute<List<int>>(request);

                if (requestResult.ResponseStatus != ResponseStatus.Completed)
                    throw new Exception(requestResult.ErrorMessage);

                foreach (var newsID in requestResult.Data.Take(numberStories))
                    result.Add(new StoryEntity { ID = newsID });
                

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Read story associated to the given id
        /// </summary>
        /// <param name="id"> id of the story</param>
        /// <returns>Story entity object with the story information</returns>
        public StoryEntity ReadStory(int id)
        {
            try
            {
                if (id == default(int))
                    throw new ArgumentNullException();
                List<StoryEntity> result = new List<StoryEntity>();
                RestClient restClient = new RestClient("https://hacker-news.firebaseio.com/v0/item/" + id.ToString() + ".json");
                var request = new RestRequest(Method.GET);
                var requestResult = restClient.Execute<StoryEntity>(request);

                if (requestResult.ResponseStatus != ResponseStatus.Completed)
                    throw new Exception(requestResult.ErrorMessage);


                return requestResult.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
