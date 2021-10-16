using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle(int RolId, int PermisoId, bool EsAsignado)
        {
            this.Id = 0;
            this.RolId = RolId;
            this.PermisoId = PermisoId;
            this.EsAsignado = EsAsignado;
        }
    }
}
