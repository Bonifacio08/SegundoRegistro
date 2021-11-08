using Microsoft.EntityFrameworkCore;
using SegundoRegistro.DAL;
using SegundoRegistro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SegundoRegistro.BLL
{
    public class AporteBLL
    {

        public static Aportes Buscar(int id)
        {
            Aportes aportes;
            Contexto contexto = new Contexto();

            try
            {
                aportes = contexto.Aportes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return aportes;
        }
        public static List<Aportes> GetNacionalidades()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }


        /*
        public static bool Guardar(Aportes aporte)
        {
            if (!Existe(aporte.AporteId))//si no existe insertamos
                return Insertar(aporte);
            else
                return Modificar(aporte);
        } //LISTO!!

        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aportes.Add(aporte);

                foreach (var detalle in aporte.Detalle)
                {
                    //detalle.Monto += 1;                
                    //detalle.Persona.CantidadGrupos += 1;
                    detalle.Aportes.Monto += 1;////////////////////////
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
        } //SIN ERRORES, PERO HAY QUE DEPURARLO
        
        private static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aporteAnterior = contexto.Aportes
                    .Where(x => x.AporteId == aporte.AporteId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.Persona)////////////////////////////
                    .AsNoTracking()
                    .SingleOrDefault();

                //busca la entidad en la base de datos y la elimina
                foreach (var detalle in aporteAnterior.Detalle)
                {
                    detalle.Persona.CantidadGrupos -= 1;//////////////////////////////////////////////
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM GruposDetalle Where GrupoId={aporte.AporteId}");

                foreach (var item in aporte.Detalle)
                {
                    item.Persona.CantidadGrupos += 1;/////////////////////////////////
                    contexto.Entry(item).State = EntityState.Added;
                }
                //Afectar
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(aporte).State = EntityState.Modified;
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
        } //ERRORES EN PERSONA, (CAMBIAR)

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var aporte = AporteBLL.Buscar(id);

                if (aporte != null)
                {
                    //busca la entidad en la base de datos y la elimina
                    foreach (var detalle in aporte.Detalle)
                    {
                        detalle.Persona.CantidadGrupos -= 1;
                    }

                    contexto.Aportes.Remove(aporte); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

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
        } //ERRORES EN PERSONA, (CAMBIAR)

        public static Aportes Buscar(int id)
        {
            Aportes aporte = new Aportes();
            Contexto contexto = new Contexto();

            try
            {
                aporte = contexto.Aportes.Include(x => x.Detalle)
                    .Where(x => x.AporteId == id)
                     .Include(x => x.Detalle)
                    .ThenInclude(x => x.Persona)//////////////////////////////
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aporte;
        } //ERRORES EN PERSONA, (CAMBIAR)

        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> Lista = new List<Aportes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        } //LISTO!!

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Aportes.Any(e => e.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        } //LISTO!!
        */
    }
}

