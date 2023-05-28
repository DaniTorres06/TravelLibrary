using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IEditorialServices
    {
        Task<Response<List<EditorialDto>>> GetEditoriales();
        Task<Response<EditorialDto>> GetByIdEditorial(int id);
        Task<Response<bool>> CreateEditorial(EditorialDto editorial);
        Task<Response<bool>> UpdateEditorial(EditorialDto autor);
        Task<Response<bool>> DeleteByIdEditorial(int id);
        
    }
}
