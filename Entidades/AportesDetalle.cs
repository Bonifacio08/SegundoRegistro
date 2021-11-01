using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.Entidades
{
    public class AportesDetalle
    {
        public int Id { get; set; }
        public int AporteId { get; set; }
        public int DetalleId { get; set; }

        [ForeignKey("DetalleId")]
        public Usuario Usuario { get; set; }//No estoy seguro si es usurario
    }
}
