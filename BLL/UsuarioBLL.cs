//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SegundoRegistro.DAL;
using SegundoRegistro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SegundoRegistro.BLL
{
    public class UsuarioBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                //Ojo a esto
                encontrado = contexto.Usuario
                    .Any(e => e.UsuarioID == id);
            }
            catch (Exception)
            {
                //Que hace el 
                throw;
            }
            finally
            {
                //Que hace el dispose
                contexto.Dispose();
            }
            return encontrado;
        }//Visto

        private static bool Insertar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que desee insertar al contexto
                contexto.Usuario.Add(usuario);
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
        }//Visto

        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioID))//Si no existe insertamos
                return Insertar(usuario);
            else
                return Modificar(usuario);//Aqui va modificar
        }//Visto

        private static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;//
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }//Visto

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //Buscar la entidad que se desea eliminar
                var usuario = contexto.Usuario.Find(id);

                if (usuario != null)
                {
                    contexto.Usuario.Remove(usuario);//Remover la cantidad
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
        }//Visto

        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;
            try
            {
                usuario = contexto.Usuario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }//Visto


        public static bool Validar(string email, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Usuario
                    .Any(u => u.Email.Equals(email)
                                && u.Clave.Equals(GetSHA256(clave))
                          );
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
        //Metodo para encriptar la clave 
        private static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {
            List<Usuario> lista = new List<Usuario>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Usuario.Where(criterio).ToList();
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
