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
    public class RolBLL
    {
        private static bool Insertar(Rol rol)
        {
            bool paso = false;
            Contexto Contexto = new Contexto();
            try
            {
                Contexto.Rol.Add(rol);
                paso = Contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Contexto.Dispose();
            }
            return paso;
        }//Listo

        public static bool Modificar(Rol rol)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(rol).State = EntityState.Modified;
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
        }//listar

        public static bool Existe(int ID)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Rol.Any(e => e.RolID == ID);
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
        }//Listar

        public static bool Guardar(Rol rol)
        {
            if (!Existe(rol.RolID))
                return Insertar(rol);
            else
                return Modificar(rol);
        }//Listo

        public static bool Eliminar(int ID)
        {
            bool paso = false;
            Contexto contexto = new  Contexto();
            try
            {
                var rol = contexto.Rol.Find(ID);
                if(rol != null)
                {
                    contexto.Rol.Remove(rol);
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
        }//Listo

        public static Rol Buscar(int ID)
        {
            Contexto contexto = new Contexto();
            Rol rol;
            try
            {
                rol = contexto.Rol.Find(ID);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rol;
        }

        public static List<Rol> GetList(Expression<Func<Rol, bool>> criterio)
        {
            List<Rol> lista = new List<Rol>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Rol.Where(criterio).ToList();
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
    }
}
