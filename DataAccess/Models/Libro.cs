using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public Int64 Isbn { get; set; }

        [Column("editorial_id")]
        public int Editorial_id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("sipnosis")]
        public string Sipnosis { get; set; }

        [Column("n_paginas")]
        public string N_paginas { get; set; }
        
    }
}
