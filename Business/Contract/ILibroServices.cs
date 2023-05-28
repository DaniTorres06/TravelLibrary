using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface ILibroServices
    {
        Task<Response<List<LibroDto>>> GetLibros();        
        Task<Response<LibroDto>> GetByIdLibros(int id);
        Task<Response<bool>> CreateLibros(LibroDto editorial);
        Task<Response<bool>> UpdateLibros(LibroDto autor);
        Task<Response<bool>> DeleteByIdLibros(int id);
        
    }
}
