using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class AutorDto
    {        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        
    }
}
