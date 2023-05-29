using Business.Contract;
using Business.Implement;
using Common.Utilities.Services;
using DataAccess.Core.Implements;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TravelLibrary.Controllers;

namespace TravelTest
{
    [TestFixture]
    public class EditorialTest
    {

        private EditorialRepository _editorialRepository;

        [SetUp]
        public void Setup()
        {
            _editorialRepository = new(new DbCrudContext());
        }

        [Test]
        public async Task GetEditorial()
        {
            Response<object> prueba = await _editorialRepository.GetEditoriales();
            Assert.IsTrue(prueba.ObjectResponse != null);
        }

        

        [Test]
        public async Task CreateEditorial()
        {
            EditorialDto vObjEditorial = new EditorialDto();
            vObjEditorial.Nombre = "Editorial prueba";
            vObjEditorial.Sede = "Sede prueba";

            Response<bool> prueba = await _editorialRepository.CreateEditorial(vObjEditorial);
            Assert.IsTrue(prueba.ObjectResponse);
        }

        [Test]
        public async Task GetEditorialXId()
        {
            int vId = 5;
            Response<EditorialDto> response = new();
            response = await _editorialRepository.GetByIdEditorial(vId);
            Assert.IsTrue(response.ObjectResponse.Id > 0);
        }

        [Test]
        public async Task EditLibro()
        {
            EditorialDto vObjEditorial = new EditorialDto();
            vObjEditorial.Id = 5;
            vObjEditorial.Nombre = "Editorial prueba. Mod";
            vObjEditorial.Sede = "Sede prueba. MOD";

            Response<bool> prueba = await _editorialRepository.UpdateEditorial(vObjEditorial);
            Assert.IsTrue(prueba.ObjectResponse);
        }
        
        /*
        [Test]
        public async Task DeleteAutor()
        {
            int vId = 924682468;

            Response<bool> prueba = await _libroRepository.DeleteByIdLibros(vId);
            Assert.IsTrue(prueba.Status = true);
        }
        */

        
    }
}