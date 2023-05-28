using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class EditorialServices: IEditorialServices
    {
        #region Propierties
        private readonly IEditorialRepository _EditorialRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EditorialServices(IEditorialRepository EditorialRepository, IMapper mapper)
        {
            _EditorialRepository = EditorialRepository;
            _mapper = mapper;
        }
        #endregion

        public async  Task<Response<List<EditorialDto>>> GetEditoriales()
        {
            var result = await _EditorialRepository.GetEditoriales();

            Response<List<EditorialDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<EditorialDto>>(result.ObjectResponse): null
            };

            return response;
        }

        public async Task<Response<EditorialDto>> GetByIdEditorial(int id)
        {
            var result = await _EditorialRepository.GetByIdEditorial(id);
            return result;
        }

        public async Task<Response<bool>> CreateEditorial(EditorialDto editorial)
        {
            var result = await _EditorialRepository.CreateEditorial(editorial);
            return result;
        }

        public async Task<Response<bool>> UpdateEditorial(EditorialDto editorial)
        {
            var result = await _EditorialRepository.UpdateEditorial(editorial);
            return result;
        }
        public async Task<Response<bool>> DeleteByIdEditorial(int id)
        {
            var result = await _EditorialRepository.DeleteByIdEditorial(id);
            return result;
        }
        /*
         * 
        
        
        public async Task<Response<bool>> UpdateAutor(AutorDto autor)
        {
            var result = await _AutorRepository.UpdateAutor(autor);
            return result;
        }
        public async Task<Response<bool>> DeleteByIdAutor(int id)
        {
            var result = await _AutorRepository.DeleteByIdAutor(id);
            return result;
        }
        */



    }
}
