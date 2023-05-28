using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("autor_has_libro")]
    public class AutorHasLibro
    {
        
        [Key]
        [Column("autor_id")]
        public int AutorId { get; set; }

        [Column("libro_ISBN")]
        //[Key]
        public Int64 LibroISBN { get; set; }


    }
}
