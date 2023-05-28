using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class AutorHasLibroRepository : IAutorHLRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<AutorHasLibroRepository> _logger;
        #endregion

        #region Contructor
        public AutorHasLibroRepository(DbCrudContext context, ILogger<AutorHasLibroRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        #endregion

        public async Task<Response<Object>> GetAutorHasLibro()
        {
            Response<Object> response = new();
            try
            {
                List<Models.AutorHasLibro> query = await context.AutorHasLibro.ToListAsync();

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<Object>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        public async Task<Response<AutorHasLibroDto>> GetByIdAutorHL(int id)
        {
            Response<AutorHasLibroDto> response = new();
            try
            {
                var autorHL = context.AutorHasLibro.Where(x => x.AutorId == id).FirstOrDefault();
                AutorHasLibroDto autorHLDto = new()
                {
                    AutorId = autorHL.AutorId,
                    LibroISBN = autorHL.LibroISBN
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = autorHLDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<AutorHasLibroDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }

        public async Task<Response<bool>> CreateAutorHL(AutorHasLibroDto _autorHL)
        {
            Response<bool> response = new();
            try
            {
                AutorHasLibro vObjAutorHL = new();

                //autor.Id = _autor.Id;
                vObjAutorHL.AutorId = _autorHL.AutorId;
                vObjAutorHL.LibroISBN = _autorHL.LibroISBN;

                context.Add(vObjAutorHL);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }         
        
        public async Task<Response<bool>> UpdateAutorHL(AutorHasLibroDto _autorHL)
        {
            Response<bool> response = new();
            try
            {
                var vAutorHL = context.AutorHasLibro.Where(x => x.AutorId == _autorHL.AutorId).FirstOrDefault();

                //autor.Id = _autor.Id;
                vAutorHL.AutorId = _autorHL.AutorId;
                vAutorHL.LibroISBN = _autorHL.AutorId;
                
                context.Update(vAutorHL);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateError)
                };
            }
        }

        public async Task<Response<bool>> DeleteByIdAutorHL(int id)
        {
            Response<bool> response = new();
            try
            {
                var vAutorHL = context.AutorHasLibro.Where(x => x.AutorId == id).FirstOrDefault();

                context.Remove(vAutorHL);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteError)
                };
            }
        }
         

    }
}
