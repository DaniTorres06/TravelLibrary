using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IAutorRepository
    {
        Task<Response<Object>> GetAutores();
        Task<Response<AutorDto>> GetByIdAutor(int id);
        Task<Response<bool>> CreateAutor(AutorDto autor);
        Task<Response<bool>> UpdateAutor(AutorDto autor);
        Task<Response<bool>> DeleteByIdAutor(int id);
        
    }
}
