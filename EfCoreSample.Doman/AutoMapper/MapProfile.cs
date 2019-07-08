using AutoMapper;
using EfCoreSample.Doman.DTO;
using EfCoreSample.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreSample.Doman.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProjectDTO, Project>()
                    .ForMember(dest => dest.Status,
                        src => src.MapFrom(s => s.ToDescriptionString()));

        }
    }
}
