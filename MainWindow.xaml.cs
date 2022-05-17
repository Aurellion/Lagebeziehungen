using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lagebeziehungen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ZahlenEingabePrüfung(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[+-]?[0-9]*(\\,|\\.)?$");
            //? 0 oder 1
            //+ 0 oder beliebig
            //* 1 oder beliebig
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vector3 a = new Vector3();
            Vector3 b = new Vector3();
            Vector3 c = new Vector3();

            
            //if (!float.TryParse(tb_ax.Text, out a.X)) MessageBox.Show("Eingabefehler in ax");            
            //if (!float.TryParse(tb_ay.Text, out a.Z)) MessageBox.Show("Eingabefehler in ay");
            //if (!float.TryParse(tb_az.Text, out a.Z)) MessageBox.Show("Eingabefehler in az");
            //if (!float.TryParse(tb_bx.Text, out b.X)) MessageBox.Show("Eingabefehler in bx");
            //if (!float.TryParse(tb_by.Text, out b.Y)) MessageBox.Show("Eingabefehler in by");
            //if (!float.TryParse(tb_bz.Text, out b.Z)) MessageBox.Show("Eingabefehler in bz");
            //if (!float.TryParse(tb_cx.Text, out c.X)) MessageBox.Show("Eingabefehler in cx");
            //if (!float.TryParse(tb_cy.Text, out c.Y)) MessageBox.Show("Eingabefehler in cy");
            //if (!float.TryParse(tb_cz.Text, out c.Z)) MessageBox.Show("Eingabefehler in cz");
        }
    }
}
