using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface ILibroRepository
    {
        Task<Response<Object>> GetLibros();        
        Task<Response<LibroDto>> GetByIdLibros(int id);
        Task<Response<bool>> CreateLibros(LibroDto libro);
        Task<Response<bool>> UpdateLibros(LibroDto libro);
        Task<Response<bool>> DeleteByIdLibros(int id);
        /**/
    }
}
