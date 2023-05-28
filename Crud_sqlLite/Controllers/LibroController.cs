using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using TravelLibrary.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace TravelLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        #region Propierties
        private readonly ILibroServices Service;
        private readonly ILogger<LibroController> _logger;
        #endregion

        #region Constructor
        public LibroController(ILibroServices service, ILogger<LibroController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion
               
         
        /// <summary>
        /// Obtener Libros
        /// </summary>
        /// <returns>Response model StudentDto</returns>        
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<LibroDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<LibroDto>>> Get()
        {
            Response<List<LibroDto>> response;
            try
            {
                response = await Service.GetLibros();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<LibroDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
        
        /// <summary>
        /// obtener edtitorial by id
        /// </summary>
        /// <returns>Response studentdto</returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<LibroDto>), StatusCodes.Status200OK)]
        public async Task<Response<LibroDto>> GetById(int id)
        {
            Response<LibroDto> response;
            try
            {
                response = await Service.GetByIdLibros(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<LibroDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        
       /// <summary>
       /// crear editorial
       /// </summary>
       /// <returns>Response bool</returns>
       [HttpPost]
       [Route("Create")]
       [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
       public async Task<Response<bool>> Post(LibroDto libro)
       {
           Response<bool> response;
           try
           {
               response = await Service.CreateLibros(libro);
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
       /// actualizar editorial
       /// </summary>
       /// <returns>Response bool</returns>
       [HttpPut]
       [Route("Update")]
       [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
       public async Task<Response<bool>> Update(LibroDto libro)
       {
           Response<bool> response;
           try
           {
               response = await Service.UpdateLibros(libro);
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
       /// eliminar by id
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
               response = await Service.DeleteByIdLibros(id);
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

        /**/
    }
}
