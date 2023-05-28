using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IAutorServices
    {
        Task<Response<List<AutorDto>>> GetAutores();
        Task<Response<AutorDto>> GetByIdAutor(int id);
        Task<Response<bool>> CreateAutor(AutorDto autor);
        Task<Response<bool>> UpdateAutor(AutorDto autor);
        Task<Response<bool>> DeleteByIdAutor(int id);
        
    }
}
