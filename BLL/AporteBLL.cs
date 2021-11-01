using SegundoRegistro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.BLL
{
    public class AporteBLL
    {
        /*
        public static bool Guardar(Aportes aporte)
        {
            if (!Existe(grupo.AporteId))//si no existe insertamos
                return Insertar(grupo);
            else
                return Modificar(grupo);
        }

        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aporte.Add(aporte);

                foreach (var detalle in aporte.Detalle)
                {
                    detalle.Persona.CantidadGrupos += 1;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        */
    }
}

