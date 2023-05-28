using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IAutorHLServices
    {
        Task<Response<List<AutorHasLibroDto>>> GetAutoresHasLibro();
        Task<Response<AutorHasLibroDto>> GetByIdAutorHL(int id);
        Task<Response<bool>> CreateAutorHL(AutorHasLibroDto autorHl);
        Task<Response<bool>> UpdateAutorHL(AutorHasLibroDto autorHl);
        Task<Response<bool>> DeleteByIdAutorHL(int id);
        
    }
}
