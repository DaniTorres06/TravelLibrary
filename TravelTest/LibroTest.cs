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
    public class LibroTest
    {

        private LibroRepository _libroRepository;

        [SetUp]
        public void Setup()
        {
            _libroRepository = new(new DbCrudContext());
        }

        [Test]
        public async Task GetLibro()
        {
            Response<object> prueba = await _libroRepository.GetLibros();
            Assert.IsTrue(prueba.ObjectResponse != null);
        }

        [Test]
        public async Task CreateLibro()
        {
            LibroDto vObjLibro = new LibroDto();
            vObjLibro.Isbn = 924682468;
            vObjLibro.Editorial_id = 3;
            vObjLibro.Titulo = "Don Quijote";
            vObjLibro.Sipnosis = "Texto de prueba";
            vObjLibro.N_paginas = "60 con 15 fotos.";

            Response<bool> prueba = await _libroRepository.CreateLibros(vObjLibro);
            Assert.IsTrue(prueba.ObjectResponse);
        }

        [Test]
        public async Task GetLibroXId()
        {
            int vId = 924682468;
            Response<LibroDto> response = new();
            response = await _libroRepository.GetByIdLibros(vId);
            Assert.IsTrue(response.ObjectResponse.Isbn > 0);
        }

        [Test]
        public async Task EditLibro()
        {
            LibroDto vObjLibro = new LibroDto();
            vObjLibro.Isbn = 924682468;
            vObjLibro.Editorial_id = 3;
            vObjLibro.Titulo = "Don Quijote Mod";
            vObjLibro.Sipnosis = "Texto de prueba Mod";
            vObjLibro.N_paginas = "60 con 15 fotos. Mod";

            Response<bool> prueba = await _libroRepository.UpdateLibros(vObjLibro);
            Assert.IsTrue(prueba.ObjectResponse);
        }
        /*
        [Test]
        public async Task DeleteLibro()
        {
            int vId = 924682468;

            Response<bool> prueba = await _libroRepository.DeleteByIdLibros(vId);
            Assert.IsTrue(prueba.Status = true);
        }
        */

        
    }
}