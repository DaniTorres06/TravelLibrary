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
    public class EditorialRepository : IEditorialRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<EditorialRepository> _logger;
        #endregion

        #region Contructor
        public EditorialRepository(DbCrudContext context, ILogger<EditorialRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        #endregion

        public async Task<Response<object>> GetEditoriales()
        {
            Response<Object> response = new();
            try
            {
                List<Models.Editorial> query = await context.Editorial.ToListAsync();

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

        public async Task<Response<EditorialDto>> GetByIdEditorial(int id)
        {
            Response<EditorialDto> response = new();
            try
            {
                var editorial = context.Editorial.Where(x => x.Id == id).FirstOrDefault();
                EditorialDto edtirialDto = new()
                {
                    Id = editorial.Id,
                    Nombre = editorial.Nombre,
                    Sede = editorial.Sede
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = edtirialDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<EditorialDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }

        public async Task<Response<bool>> CreateEditorial(EditorialDto _editoral)
        {
            Response<bool> response = new();
            try
            {
                Editorial vObjEditorial = new();

                //autor.Id = _autor.Id;
                vObjEditorial.Nombre = _editoral.Nombre;
                vObjEditorial.Sede = _editoral.Sede;

                context.Add(vObjEditorial);
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


        public async Task<Response<bool>> UpdateEditorial(EditorialDto _editoral)
        {
            Response<bool> response = new();
            try
            {
                var editorial = context.Editorial.Where(x => x.Id == _editoral.Id).FirstOrDefault();

                //autor.Id = _autor.Id;
                editorial.Nombre = _editoral.Nombre;
                editorial.Sede = _editoral.Sede;

                context.Update(editorial);
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

        public async Task<Response<bool>> DeleteByIdEditorial(int id)
        {
            Response<bool> response = new();
            try
            {
                var editorial = context.Editorial.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(editorial);
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
