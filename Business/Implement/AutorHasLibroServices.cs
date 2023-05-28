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
    public class AutorHasLibroServices: IAutorHLServices
    {
        #region Propierties
        private readonly IAutorHLRepository _AutorHLRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AutorHasLibroServices(IAutorHLRepository AutorHLRepository, IMapper mapper)
        {
            _AutorHLRepository = AutorHLRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<AutorHasLibroDto>>> GetAutoresHasLibro()
        {
            var result = await _AutorHLRepository.GetAutorHasLibro();

            Response<List<AutorHasLibroDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<AutorHasLibroDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }        
        public async Task<Response<AutorHasLibroDto>> GetByIdAutorHL(int id)
        {
            var result = await _AutorHLRepository.GetByIdAutorHL(id);
            return result;
        }
        public async Task<Response<bool>> CreateAutorHL(AutorHasLibroDto autorHl)
        {
            var result = await _AutorHLRepository.CreateAutorHL(autorHl);
            return result;
        }           
        public async Task<Response<bool>> UpdateAutorHL(AutorHasLibroDto autorHl)
        {
            var result = await _AutorHLRepository.UpdateAutorHL(autorHl);
            return result;
        }
        public async Task<Response<bool>> DeleteByIdAutorHL(int id)
        {
            var result = await _AutorHLRepository.DeleteByIdAutorHL(id);
            return result;
        }
        
    }
}
