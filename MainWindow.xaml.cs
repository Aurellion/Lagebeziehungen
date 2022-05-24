using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //List<TextBox> textBoxesEingabeVektoren = new List<TextBox>();
        Vector3 vecA = Vector3.UnitX;
        Vector3 vecB = Vector3.UnitY;
        Vector3 vecC = Vector3.UnitZ;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float VekAX
        {
            get { return vecA.X; }
            set
            {
                if (value == vecA.X) return;
                vecA.X = value;
                NotifyPropertyChanged(nameof(VekAX)); 
            }
        }      

        public float VekAY
        {
            get { return vecA.Y; }
            set
            {
                if (value == vecA.Y) return;                
                vecA.Y = value;
                NotifyPropertyChanged(nameof(VekAY));
            }
        }
        public float VekAZ
        {
            get { return vecA.Z; }
            set
            {
                if (value == vecA.Z) return;
                vecA.Z = value;
                NotifyPropertyChanged(nameof(VekAZ));
            }
        }

        public float VekBX
        {
            get { return vecB.X; }
            set
            {
                if (value == vecB.X) return;
                vecB.X = value;
                NotifyPropertyChanged(nameof(VekBX));
            }
        }
        public float VekBY
        {
            get { return vecB.Y; }
            set
            {
                if (value == vecB.Y) return;
                vecB.Y = value;
                NotifyPropertyChanged(nameof(VekBY));
            }
        }
        public float VekBZ
        {
            get { return vecB.Z; }
            set
            {
                if (value == vecB.Z) return;
                vecB.Z = value;
                NotifyPropertyChanged(nameof(VekBZ));
            }
        }

        public float VekCX
        {
            get { return vecC.X; }
            set
            {
                if (value == vecC.X) return;
                vecC.X = value;
                NotifyPropertyChanged(nameof(VekCX));
            }
        }
        public float VekCY
        {
            get { return vecC.Y; }
            set
            {
                if (value == vecC.Y) return;
                vecC.Y = value;
                NotifyPropertyChanged(nameof(VekCY));
            }
        }
        public float VekCZ
        {
            get { return vecC.Z; }
            set
            {
                if (value == vecC.Z) return;
                vecC.Z = value;
                NotifyPropertyChanged(nameof(VekCZ));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //int zeile = 1;
            //int spalte = 0;
            //for (int i = 0; i < 9; i++)
            //{
            //    TextBox tb = new TextBox();
            //    tb.PreviewTextInput += ZahlenEingabePrüfung;
            //    Grid_Vektoren.Children.Add(tb);
            //    if (i < 3) { spalte = 1;  }
            //    else if (i < 6) { spalte = 3;  }
            //    else { spalte = 5;  }                
            //    Grid.SetColumn(tb, spalte);
            //    if (i % 3 == 0) { zeile = 1; }
            //    Grid.SetRow(tb, zeile++);                
            //    textBoxesEingabeVektoren.Add(tb);
            //}

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
            //Tab 1 Vektoren
            //Beträge berechnen
            TB_Ba.Text = vecA.Length().ToString();
            TB_Bb.Text = vecB.Length().ToString();
            TB_Bc.Text = vecC.Length().ToString();

            //Skalarprodukt
            TB_SP.Text = Vector3.Dot(vecA, vecB).ToString();

            //Kreuzprodukt
            Vector3 KP = Vector3.Cross(vecA, vecB);
            //TB_VP.Text = "( " + KP.X + " | " + KP.Y + " | " + KP.Z + " )";
            TB_VP.Text = KP.ToString();

            //Spatprodukt
            TB_SPP.Text = Vector3.Dot(KP, vecC).ToString();


            //Tab 2 Punkt-Gerade
            //Geradengleichung
            Vector3 Richtungsvektor = vecC - vecB;
            TB_g.Text = "g: x = " + vecA.ToString() + " r * " + Richtungsvektor.ToString();

            //Abstand P-g
            TB_Abstand.Text = (Vector3.Cross((vecA - vecB), (vecA - vecC)).Length()/(vecB-vecC).Length()).ToString();

            //double[] veka = new double[3];
            //double[] vekb = new double[3];
            //double[] vekc = new double[3];
            //bool fehlerAufgetreten = false;

            //for (int i = 0; i < 3; i++)
            //{
            //    if (double.TryParse(textBoxesEingabeVektoren[i].Text, out veka[i]) == false)
            //    {
            //        MessageBox.Show("falsche Eingabe in Vektor a", "Fehler");
            //        fehlerAufgetreten = true;
            //    }
            //    if (double.TryParse(textBoxesEingabeVektoren[i + 3].Text, out vekb[i]) == false)
            //    {
            //        MessageBox.Show("falsche Eingabe in Vektor b", "Fehler");
            //        fehlerAufgetreten = true;
            //    }
            //    if (double.TryParse(textBoxesEingabeVektoren[i + 6].Text, out vekc[i]) == false)
            //    {
            //        MessageBox.Show("falsche Eingabe in Vektor c", "Fehler");
            //        fehlerAufgetreten = true;
            //    }
            //}
            //if (fehlerAufgetreten)
            //{
            //    MessageBox.Show("Bitte Eingabe korrigieren!","Eingabefehler");
            //}
            //else
            //{
            //    //Beträge berechnen
            //    double Ba, Bb, Bc;
            //    Ba = Math.Sqrt(veka[0] * veka[0] + veka[1] * veka[1] + veka[2] * veka[2]);
            //    Bb = Math.Sqrt(vekb[0] * vekb[0] + vekb[1] * vekb[1] + vekb[2] * vekb[2]);
            //    Bc = Math.Sqrt(vekc[0] * vekc[0] + vekc[1] * vekc[1] + vekc[2] * vekc[2]);
            //    //Skalarprodukt
            //    double skalarproduktAB = veka[0] * vekb[0] + veka[1] * vekb[1] + veka[2] * vekb[2];
            //    //Kreuzprodukt
            //    double[] kreuzproduktAB = new double[3];
            //    kreuzproduktAB[0] = veka[1] * vekb[2] - veka[2] * vekb[1];
            //    kreuzproduktAB[1] = veka[2] * vekb[0] - veka[0] * vekb[2];
            //    kreuzproduktAB[2] = veka[0] * vekb[1] - veka[1] * vekb[0];
            //    //Spatprodukt
            //    double spatprodukt = vekc[0] * kreuzproduktAB[0] + vekc[1] * kreuzproduktAB[1] + vekc[2] * kreuzproduktAB[2];

            //    //Ausgabe
            //    TB_Ba.Text = Ba.ToString();
            //    TB_Bb.Text = Bb.ToString();
            //    TB_Bc.Text = Bc.ToString();
            //    TB_SP.Text = skalarproduktAB.ToString();
            //    TB_SPP.Text = spatprodukt.ToString();
            //    TB_VP.Text = "( " + kreuzproduktAB[0] + "|" + kreuzproduktAB[1] + "|" + kreuzproduktAB[2] + " )";
            //}
        }
    }
}
