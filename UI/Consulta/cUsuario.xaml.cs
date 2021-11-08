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

namespace SegundoRegistro.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cUsuario.xaml
    /// </summary>
    public partial class cUsuario : Window
    {
        public cUsuario()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuario>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EstudianteId
                        listado = UsuarioBLL.GetList(e => e.UsuarioID == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = UsuarioBLL.GetList(e => e.Email.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = UsuarioBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = UsuarioBLL.GetList(c => c.FechaIngreso.Date >= DesdeDataPicker.SelectedDate);
                        
            if (HastaDatePicker.SelectedDate != null)
                listado = UsuarioBLL.GetList(c => c.FechaIngreso.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
