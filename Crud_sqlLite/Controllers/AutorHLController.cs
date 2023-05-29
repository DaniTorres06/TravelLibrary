using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TravelLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorHLController : ControllerBase
    {

        #region Propierties
        private readonly IAutorHLServices Service;
        private readonly ILogger<AutorHLController> _logger;
        #endregion

        #region Constructor
        public AutorHLController(IAutorHLServices service, ILogger<AutorHLController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion        
        
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<AutorHasLibroDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<AutorHasLibroDto>>> Get()
        {
            Response<List<AutorHasLibroDto>> response;
            try
            {
                response = await Service.GetAutoresHasLibro();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<AutorHasLibroDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// obtener autores has AutorHL by id
        /// </summary>
        /// <returns>Response studentdto</returns>

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<AutorHasLibroDto>), StatusCodes.Status200OK)]
        public async Task<Response<AutorHasLibroDto>> GetById(int id)
        {
            Response<AutorHasLibroDto> response;
            try
            {
                response = await Service.GetByIdAutorHL(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<AutorHasLibroDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        /// <summary>
        /// crear AutorHL
        /// </summary>
        /// <returns>Response bool</returns>


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(AutorHasLibroDto autorHl)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateAutorHL(autorHl);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        /// <summary>
        /// actualizar AutorHL
        /// </summary>
        /// <returns>Response bool</returns>

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(AutorHasLibroDto vAutorHL)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateAutorHL(vAutorHL);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }



        /// <summary>
        /// eliminar AutorHL by id
        /// </summary>
        /// <returns>Response bool</returns>

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response;
            try
            {
                response = await Service.DeleteByIdAutorHL(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
    }
}
