using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utilities.Resource;
using Models.Models;

namespace DataAccess.Core.Implements
{
    public class LibroRepository: ILibroRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<LibroRepository> _logger;
        #endregion

        #region Contructor
        public LibroRepository(DbCrudContext context, ILogger<LibroRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        #endregion

        public async Task<Response<object>> GetLibros()
        {
            Response<Object> response = new();
            try
            {
                List<Models.Libro> query = await context.Libro.ToListAsync();

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
                

        public async Task<Response<LibroDto>> GetByIdLibros(int id)
        {
            Response<LibroDto> response = new();
            try
            {
                var libro = context.Libro.Where(x => x.Isbn == id).FirstOrDefault();
                LibroDto vObjLibro = new()
                {
                    Isbn = libro.Isbn,
                    Editorial_id = libro.Editorial_id,
                    Titulo = libro.Titulo,
                    Sipnosis = libro.Sipnosis,
                    N_paginas = libro.N_paginas,
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = vObjLibro,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<LibroDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }

        public async Task<Response<bool>> CreateLibros(LibroDto _libro)
        {
            Response<bool> response = new();
            try
            {
                Libro vObjLibro = new();

                //autor.Id = _autor.Id;
                vObjLibro.Isbn = _libro.Isbn;
                vObjLibro.Editorial_id = _libro.Editorial_id;
                vObjLibro.Titulo = _libro.Titulo;
                vObjLibro.Sipnosis = _libro.Sipnosis;
                vObjLibro.N_paginas = _libro.N_paginas;

                context.Add(vObjLibro);
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


        public async Task<Response<bool>> UpdateLibros(LibroDto _Libro)
        {
            Response<bool> response = new();
            try
            {
                var libro = context.Libro.Where(x => x.Isbn == _Libro.Isbn).FirstOrDefault();

                //autor.Id = _autor.Id;
                libro.Isbn = _Libro.Isbn;
                libro.Editorial_id = _Libro.Editorial_id;
                libro.Titulo = _Libro.Titulo;
                libro.Sipnosis= _Libro.Sipnosis;
                libro.N_paginas = _Libro.N_paginas;



                context.Update(libro);
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

        public async Task<Response<bool>> DeleteByIdLibros(int id)
        {
            Response<bool> response = new();
            try
            {
                var libro = context.Libro.Where(x => x.Isbn == id).FirstOrDefault();

                context.Remove(libro);
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
        /**/
    }
}
