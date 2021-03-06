using SegundoRegistro.BLL;
using SegundoRegistro.Entidades;
using SegundoRegistro.UI.Registro;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Menu = SegundoRegistro.UI.Registro.Menu;

namespace SegundoRegistro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Login lg = new Login();
            //lg.ShowDialog();
            InitializeComponent();
        }
        Usuario usuario = new Usuario();
        //MainWindow Principal = new MainWindow();

        /*public Login()
        {
            InitializeComponent();
        }
        */

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                Menu menu = new UI.Registro.Menu();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /*
        private void Registro_Click(object sender, RoutedEventArgs e)
        {
            VentanaRol ventanaROL = new VentanaRol();
            ventanaROL.Show();
        }

        private void Usuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuario ventanaUSUARIO = new VentanaUsuario();
            ventanaUSUARIO.Show();
        }
       /* private void Aporte_Click(object sender, RoutedEventArgs e)
        {
            VentanaAportes ventanaAPORTE = new VentanaAportes();
            ventanaAPORTE.Show();
        }
       */
    }
}
