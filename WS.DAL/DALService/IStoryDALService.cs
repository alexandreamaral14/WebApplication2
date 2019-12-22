using System;
using System.Collections.Generic;
using System.Text;
using WS.DAL.Entities;

namespace WS.DAL.DALService
{
    public interface IStoryDALService
    {
        IEnumerable<StoryEntity> ListBestStories(int numberStories);
    }
}
