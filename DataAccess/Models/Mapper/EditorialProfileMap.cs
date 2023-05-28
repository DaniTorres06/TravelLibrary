using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class EditorialProfileMap: Profile
    {
        public EditorialProfileMap()
        {
            CreateMap<Editorial, EditorialDto>().ReverseMap();
        }
    }
}
