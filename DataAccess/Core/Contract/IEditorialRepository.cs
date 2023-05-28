using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IEditorialRepository
    {
        Task<Response<Object>> GetEditoriales();
        Task<Response<EditorialDto>> GetByIdEditorial(int id);
        Task<Response<bool>> CreateEditorial(EditorialDto editrial);
        Task<Response<bool>> UpdateEditorial(EditorialDto editorial);
        Task<Response<bool>> DeleteByIdEditorial(int id);
        
    }
}
