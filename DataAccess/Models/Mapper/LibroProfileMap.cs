using Models.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Mapper
{
    public class LibroProfileMap: Profile
    {
        public LibroProfileMap()
        {
            CreateMap<Libro, LibroDto>().ReverseMap();
        }
    }
}
