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
        List<TextBox> textBoxesEingabeVektoren = new List<TextBox>();
        public MainWindow()
        {
            InitializeComponent();
            int zeile = 1;
            int spalte = 0;
            for (int i = 0; i < 9; i++)
            {
                TextBox tb = new TextBox();
                tb.PreviewTextInput += ZahlenEingabePrüfung;
                Grid_Vektoren.Children.Add(tb);
                if (i < 3) { spalte = 1;  }
                else if (i < 6) { spalte = 3;  }
                else { spalte = 5;  }                
                Grid.SetColumn(tb, spalte);
                if (i % 3 == 0) { zeile = 1; }
                Grid.SetRow(tb, zeile++);                
                textBoxesEingabeVektoren.Add(tb);
            }

        }


        private void ZahlenEingabePrüfung(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[+-]?[0-9]*(\\,|\\.)?$");
            //? 0 oder 1
            //+ 0 oder beliebig
            //* 1 oder beliebig
        }        

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            double[] veka = new double[3];
            double[] vekb = new double[3];
            double[] vekc = new double[3];

            for (int i = 0; i < 3; i++)
            {
                if (double.TryParse(textBoxesEingabeVektoren[i].Text, out veka[i]) == false)
                {
                    MessageBox.Show("falsche Eingabe", "Fehler");
                }
                if (double.TryParse(textBoxesEingabeVektoren[i + 3].Text, out vekb[i]) == false)
                {
                    MessageBox.Show("falsche Eingabe", "Fehler");
                }
                if (double.TryParse(textBoxesEingabeVektoren[i + 6].Text, out vekc[i]) == false)
                {
                    MessageBox.Show("falsche Eingabe", "Fehler");
                }
            }

            //Beträge berechnen
            double Ba, Bb, Bc;
            Ba = Math.Sqrt(veka[0]*veka[0]+ veka[1] * veka[1] + veka[2] * veka[2] );
            Bb = Math.Sqrt(vekb[0]*vekb[0]+ vekb[1] * vekb[1] + vekb[2] * vekb[2] );
            Bc = Math.Sqrt(vekc[0]*vekc[0]+ vekc[1] * vekc[1] + vekc[2] * vekc[2] );
            //Skalarprodukt
            double skalarproduktAB = veka[0] * vekb[0] + veka[1] * vekb[1] + veka[2] * vekb[2];
            //Kreuzprodukt
            double[] kreuzproduktAB = new double[3];
            kreuzproduktAB[0] = veka[1] * vekb[2] - veka[2] * vekb[1];
            kreuzproduktAB[1] = veka[2] * vekb[0] - veka[0] * vekb[2];
            kreuzproduktAB[2] = veka[0] * vekb[1] - veka[1] * vekb[0];
            //Spatprodukt
            double spatprodukt = vekc[0] * kreuzproduktAB[0] + vekc[1] * kreuzproduktAB[1] + vekc[2] * kreuzproduktAB[2];

            //Ausgabe
            TB_Ba.Text = Ba.ToString();
            TB_Bb.Text = Bb.ToString();
            TB_Bc.Text = Bc.ToString();
            TB_SP.Text = skalarproduktAB.ToString();
            TB_SPP.Text = spatprodukt.ToString();
            TB_VP.Text = "( "+ kreuzproduktAB[0] + "|" + kreuzproduktAB[1] + "|" + kreuzproduktAB[2] + " )";
            
        }
    }
}
