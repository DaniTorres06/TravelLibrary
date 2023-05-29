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
    public class AutorRepository : IAutorRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<AutorRepository> _logger;
        #endregion

        #region Contructor
        public AutorRepository(DbCrudContext context)
        {
            this.context = context;
            
        }        
        #endregion

        #region Method
        public async Task<Response<Object>> GetAutores()
        {
            Response<Object> response = new();
            try
            {
                List<Models.Autor> query = await context.Autor.ToListAsync();

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
        public async Task<Response<AutorDto>> GetByIdAutor(int id)
        {
            Response<AutorDto> response = new();
            try
            {
                var autor = context.Autor.Where(x => x.Id == id).FirstOrDefault();
                AutorDto autorDto = new()
                {
                    Id = autor.Id,
                    Nombre = autor.Nombre,
                    Apellidos = autor.Apellidos
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = autorDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<AutorDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }

        public async Task<Response<bool>> CreateAutor(AutorDto _autor)
        {
            Response<bool> response = new();
            try
            {
                Autor autor = new();

                //autor.Id = _autor.Id;
                autor.Nombre = _autor.Nombre;
                autor.Apellidos = _autor.Apellidos;
                
                context.Add(autor);
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
        
        public async Task<Response<bool>> UpdateAutor(AutorDto _autor)
        {
            Response<bool> response = new();
            try
            {
                var autor = context.Autor.Where(x => x.Id == _autor.Id).FirstOrDefault();

                //autor.Id = _autor.Id;
                autor.Nombre = _autor.Nombre;
                autor.Apellidos = _autor.Apellidos;
                
                context.Update(autor);
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

        public async Task<Response<bool>> DeleteByIdAutor(int id)
        {
            Response<bool> response = new();
            try
            {
                var autor = context.Autor.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(autor);
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
        
        #endregion

    }
}
