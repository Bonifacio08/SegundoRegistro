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

namespace SegundoRegistro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
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

        private void Aporte_Click(object sender, RoutedEventArgs e)
        {
            VentanaAportes ventanaAPORTE = new VentanaAportes();
            ventanaAPORTE.Show();
        }
    }
}
