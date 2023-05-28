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
    public class EditorialController : ControllerBase
    {
        #region Propierties
        private readonly IEditorialServices Service;
        private readonly ILogger<EditorialController> _logger;
        #endregion

        #region Constructor
        public EditorialController(IEditorialServices service, ILogger<EditorialController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtener editoriales
        /// </summary>
        /// <returns>Response model StudentDto</returns>        
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<EditorialDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<EditorialDto>>> Get()
        {
            Response<List<EditorialDto>> response;
            try
            {
                response = await Service.GetEditoriales();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<EditorialDto>>
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
        [ProducesResponseType(typeof(Response<EditorialDto>), StatusCodes.Status200OK)]
        public async Task<Response<EditorialDto>> GetById(int id)
        {
            Response<EditorialDto> response;
            try
            {
                response = await Service.GetByIdEditorial(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<EditorialDto>
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
        public async Task<Response<bool>> Post(EditorialDto editorial)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateEditorial(editorial);
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
        public async Task<Response<bool>> Update(EditorialDto editorial)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateEditorial(editorial);
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
                response = await Service.DeleteByIdEditorial(id);
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



        /*

        /// <summary>
        /// actualizar estudiantes
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


        */
    }
}
