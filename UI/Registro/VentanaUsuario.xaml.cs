using SegundoRegistro.BLL;
using SegundoRegistro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoRegistro.UI.Registro
{
    /// <summary>
    /// Interaction logic for VentanaUsuario.xaml
    /// </summary>
    public partial class VentanaUsuario : Window
    {
        private Usuario U = new Usuario();
        public VentanaUsuario()
        {
            InitializeComponent();
            this.DataContext = U;
        }

        public void Limpiar()
        {
            this.U = new Usuario();
            this.DataContext = U;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (TextUsuarioID.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el Usuario ID", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            /*if (!Validar())
            {
                return;
            }
            */

            //var paso = UsuarioBLL.Guardar(U);

            var usuario = UsuarioBLL.Buscar(Convert.ToInt32(TextUsuarioID.Text));

            if (usuario != null)
                this.U = usuario;
            else
                this.U = new Usuario();

            this.DataContext = this.U;
            /*
            if (paso)
            {
                //Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Negado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            */
        }


        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuarioBLL.Guardar(U);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Negado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (TextUsuarioID.Text.Length == 0)
            {
                return;
            }
            if (UsuarioBLL.Eliminar(Convert.ToInt32(TextUsuarioID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
