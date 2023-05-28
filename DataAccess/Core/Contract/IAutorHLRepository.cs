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
    public interface IAutorHLRepository
    {
        Task<Response<Object>> GetAutorHasLibro();
        Task<Response<AutorHasLibroDto>> GetByIdAutorHL(int id);
        Task<Response<bool>> CreateAutorHL(AutorHasLibroDto autorHL);
        Task<Response<bool>> UpdateAutorHL(AutorHasLibroDto autorHL);
        Task<Response<bool>> DeleteByIdAutorHL(int id);
        
    }
}
