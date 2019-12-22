using System;
using System.Collections.Generic;
using System.Text;
using WS.DTO.DTOs;

namespace WS.Service.Services.Stories
{
    public interface IStoriesService
    {
       IEnumerable<StorieDTO> ListBestStories(int numberStories);
    }
}
