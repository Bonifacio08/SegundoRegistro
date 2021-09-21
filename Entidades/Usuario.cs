using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public int RolID { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int Activo { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
