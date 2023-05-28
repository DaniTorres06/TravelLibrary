using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class LibroDto
    {
        public Int64 Isbn { get; set; }
        public int Editorial_id { get; set; }
        public string Titulo { get; set; }
        public string Sipnosis { get; set; }
        public string N_paginas { get; set; }
    }
}
