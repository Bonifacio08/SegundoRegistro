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
    /// Interaction logic for VentanaRol.xaml
    /// </summary>
    public partial class VentanaRol : Window
    {
        Rol R = new Rol();
        public VentanaRol()
        {
            InitializeComponent();
            this.DataContext = R;
        }

        public void Limpiar()
        {
            this.R = new Rol();
            this.DataContext = R;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (TextRolID.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el Rol ID", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            var paso = RolBLL.Guardar(R);

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
        //Ojooooooooooooooooooooooooooooooooooooooooooooo
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            var rol = RolBLL.Buscar(Convert.ToInt32(TextRolID.Text));

            if (rol != null)
                this.R = rol;
            else
                this.R = new Rol();
                /*
                MessageBox.Show("Este ID no existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                */
                

            this.DataContext = this.R;
                
                
                
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //Biding
        

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (TextRolID.Text.Length == 0)
            {
                return;
            }
            if (RolBLL.Eliminar(Convert.ToInt32(TextRolID.Text)))
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
