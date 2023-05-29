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
    public class AutorTest
    {

        private AutorRepository _autorRepository;

        [SetUp]
        public void Setup()
        {
            _autorRepository = new(new DbCrudContext());
        }

        [Test]
        public async Task GetAutores()
        {
            Response<object> prueba = await _autorRepository.GetAutores();
            Assert.IsTrue(prueba.ObjectResponse != null);
        }

        [Test]
        public async Task GetAutoresXId()
        {
            int vId = 6;
            Response<AutorDto> response = new();
            response = await _autorRepository.GetByIdAutor(vId);
            Assert.IsTrue(response.ObjectResponse.Id > 0);
        }

        [Test]
        public async Task CreateAutor()
        {
            AutorDto vObjAutor = new AutorDto();
            vObjAutor.Nombre = "Dani";
            vObjAutor.Apellidos = "Torres";

            Response<bool> prueba = await _autorRepository.CreateAutor(vObjAutor);
            Assert.IsTrue(prueba.ObjectResponse);
        }

        [Test]
        public async Task EditAutor()
        {
            AutorDto vObjAutor = new AutorDto();
            vObjAutor.Id = 17;
            vObjAutor.Nombre = "Dani Mod";
            vObjAutor.Apellidos = "Torres Mod";

            Response<bool> prueba = await _autorRepository.UpdateAutor(vObjAutor);
            Assert.IsTrue(prueba.ObjectResponse);
        }

        [Test]
        public async Task DeleteAutor()
        {
            int vId = 16;

            Response<bool> prueba = await _autorRepository.DeleteByIdAutor(vId);
            Assert.IsTrue(prueba.Status = true);
        }





    }
}