using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WS.DAL.DALService;
using WS.DAL.Entities;
using WS.DTO.DTOs;

namespace WS.Service.Services.Stories
{
    public class StoriesService : IStoriesService
    {
        private IStoryDALService storyDALService;
        private IMapper mapper;
        public StoriesService(IStoryDALService storyDALService, IMapper mapper)
        {
            this.storyDALService = storyDALService;
            this.mapper = mapper;
        }

        /// <summary>
        /// List top best stories of WS by given number
        /// </summary>
        /// <param name="numberStories">number of stories to list</param>
        /// <returns>List of the stop stories </returns>
        public IEnumerable<StorieDTO> ListBestStories(int numberStories)
        {
            try
            {
                List<StorieDTO> result = new List<StorieDTO>();
                foreach(var storyID in storyDALService.ListBestStories(numberStories))
                {
                    result.Add(mapper.Map<StoryEntity, StorieDTO>(storyDALService.ReadStory(storyID.ID)));
                    System.Threading.Thread.Sleep(500); //avoid overflow request WS destination
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
