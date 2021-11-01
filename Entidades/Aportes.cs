using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> Detalle { get; set; } = new List<AportesDetalle>();
    }
}
