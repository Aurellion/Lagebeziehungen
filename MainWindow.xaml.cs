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
using WpfMath;


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

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            
                
            
        }

        private double Skalarprodukt(Vector3 vecA, Vector3 vecB)
        {
            Vector3 vecBuff = vecA * vecB;
            return vecBuff.X + vecBuff.Y + vecBuff.Z;
        }

        private Vector3 Kreuzprodukt(Vector3 vecA, Vector3 vecB)
        {
            Vector3 vecbuff;
            vecbuff.X = vecA.Y*vecB.Z - vecA.Z * vecB.Y;
            vecbuff.Y = vecA.Z*vecB.X - vecA.X * vecB.Z;
            vecbuff.Z = vecA.X*vecB.Y - vecA.Y * vecB.X;
            return vecbuff;
        }

        private double Spatprodukt(Vector3 vecA, Vector3 vecB, Vector3 vecC)
        {
            return Skalarprodukt(vecA, Kreuzprodukt(vecB, vecC));
        }

    
    }
}
