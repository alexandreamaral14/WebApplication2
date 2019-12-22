using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WS.DAL.Entities;
using WS.DTO.DTOs;

namespace WebApplication2.Mapper
{
    public class StoriesProfile : Profile
    {
        public StoriesProfile()
        {
            CreateMap<StorieDTO, StoryEntity>().ReverseMap().ForMember(x => x.Title, cd => cd.MapFrom(map => map.Title))
                .ForMember(x => x.Date, cd => cd.MapFrom(map => map.Date))
                .ForMember(x => x.ID, cd => cd.MapFrom(map => map.ID))
                .ForMember(x => x.NumberComments, cd => cd.MapFrom(map => map.CommentsID.Count()))
                .ForMember(x => x.uri, cd => cd.MapFrom(map => map.uri))
                .ForMember(x => x.PostedBy, cd => cd.MapFrom(map => map.PostedBy));

            CreateMap<NewsModel, StorieDTO>().ReverseMap().ForMember(x => x.title, cd => cd.MapFrom(map => map.Title))
                .ForMember(x => x.uri, cd => cd.MapFrom(map => map.uri))
                .ForMember(x => x.postedBy, cd => cd.MapFrom(map => map.PostedBy))
                .ForMember(x => x.time, cd => cd.MapFrom(map => map.Date))
                .ForMember(x => x.score, cd => cd.MapFrom(map => map.Score))
                .ForMember(x => x.commentCount, cd => cd.MapFrom(map => map.NumberComments));
        }
    }
}
