using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class AutorProfileMap : Profile
    {
        public AutorProfileMap()
        {
            CreateMap<Autor, AutorDto>().ReverseMap();
        }
    }
}
