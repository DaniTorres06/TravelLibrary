using AutoMapper;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Mapper
{
    public class AutorHasLibroProfMap : Profile
    {
        public AutorHasLibroProfMap()
        {
            CreateMap<AutorHasLibro, AutorHasLibroDto>().ReverseMap();
        }
    }
}
