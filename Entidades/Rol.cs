using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.Entidades
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public String Descripcion { get; set; }
    }
}
