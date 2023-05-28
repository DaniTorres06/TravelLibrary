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
    public class LibroServices: ILibroServices
    {
        #region Propierties
        private readonly ILibroRepository _LibroRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public LibroServices(ILibroRepository LibroRepository, IMapper mapper)
        {
            _LibroRepository = LibroRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<LibroDto>>> GetLibros()
        {
            var result = await _LibroRepository.GetLibros();

            Response<List<LibroDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<LibroDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }

        public async Task<Response<LibroDto>> GetByIdLibros(int id)
        {
            var result = await _LibroRepository.GetByIdLibros(id);
            return result;
        }

        public async Task<Response<bool>> CreateLibros(LibroDto editorial)
        {
            var result = await _LibroRepository.CreateLibros(editorial);
            return result;
        }

        public async Task<Response<bool>> UpdateLibros(LibroDto editorial)
        {
            var result = await _LibroRepository.UpdateLibros(editorial);
            return result;
        }
        public async Task<Response<bool>> DeleteByIdLibros(int id)
        {
            var result = await _LibroRepository.DeleteByIdLibros(id);
            return result;
        }
    }
}
