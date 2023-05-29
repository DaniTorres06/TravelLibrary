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
    public class AutorController : ControllerBase
    {
        #region Propierties
        private readonly IAutorServices Service;
        //private readonly ILogger<AutorController> _logger;
        #endregion

        #region Constructor
        public AutorController(IAutorServices service )
        {
            Service = service;
            //_logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtener Autor
        /// </summary>
        /// <returns>Response model StudentDto</returns>        
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<AutorDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<AutorDto>>> Get()
        {
            Response<List<AutorDto>> response;
            try
            {
                response = await Service.GetAutores();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<AutorDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// obtener Autor by id
        /// </summary>
        /// <returns>Response studentdto</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<AutorDto>), StatusCodes.Status200OK)]
        public async Task<Response<AutorDto>> GetById(int id)
        {
            Response<AutorDto> response;
            try
            {
                response = await Service.GetByIdAutor(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<AutorDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        /// <summary>
        /// crear Autor
        /// </summary>
        /// <returns>Response bool</returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(AutorDto autor)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateAutor(autor);
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
        /// actualizar Autor
        /// </summary>
        /// <returns>Response bool</returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(AutorDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateAutor(student);
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
        /// eliminar Autor by id
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
                response = await Service.DeleteByIdAutor(id);
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
