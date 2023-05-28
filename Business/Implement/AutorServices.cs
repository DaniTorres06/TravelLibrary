using AutoMapper;
using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class AutorServices : IAutorServices
    {
        #region Propierties
        private readonly IAutorRepository _AutorRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AutorServices(IAutorRepository autorRepository, IMapper mapper)
        {
            _AutorRepository = autorRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<AutorDto>>> GetAutores()
        {
            var result = await _AutorRepository.GetAutores();

            Response<List<AutorDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<AutorDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }
        public async Task<Response<AutorDto>> GetByIdAutor(int id)
        {
            var result = await _AutorRepository.GetByIdAutor(id);
            return result;
        }
        public async Task<Response<bool>> CreateAutor(AutorDto autor)
        {
            var result = await _AutorRepository.CreateAutor(autor);
            return result;
        }
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

        /*
        

        public async Task<Response<bool>> CreateStudent(StudentDto student)
        {
            var result = await _studentRepository.CreateStudent(student);
            return result;
        }

        

       
        */
    }
}
