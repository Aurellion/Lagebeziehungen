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
using WpfMath;


namespace Lagebeziehungen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window//, INotifyPropertyChanged
    {
        Vector3 vecA = Vector3.Zero;
        Vector3 vecB = Vector3.Zero;
        Vector3 vecC = Vector3.Zero;

        
        public float VekAX
        { 
            get { return vecA.X; } 
            set 
            {
                if (value == vecA.X) return;                
                vecA.X = value;
                //NotifyPropertyChanged(nameof(VekAX));
            } 
        }
        public float VekAY
        { 
            get { return vecA.Y; } 
            set 
            {
                if (value == vecA.Y) return;                
                vecA.Y = value;
                //NotifyPropertyChanged(nameof(VekAX));
            } 
        }
        public float VekAZ
        { 
            get { return vecA.Z; } 
            set 
            {
                if (value == vecA.Z) return;                
                vecA.Z = value;
                //NotifyPropertyChanged(nameof(VekAX));
            } 
        }

        public float VekBX
        {
            get { return vecB.X; }
            set
            {
                if (value == vecB.X) return;
                vecB.X = value;
                //NotifyPropertyChanged(nameof(VekAY));
            }
        }
        public float VekBY
        {
            get { return vecB.Y; }
            set
            {
                if (value == vecB.Y) return;
                vecB.Y = value;
                //NotifyPropertyChanged(nameof(VekBY));
            }
        }
        public float VekBZ
        {
            get { return vecB.Z; }
            set
            {
                if (value == vecB.Z) return;
                vecB.Z = value;
                //NotifyPropertyChanged(nameof(VekBY));
            }
        }

        public float VekCX
        {
            get { return vecC.X; }
            set
            {
                if (value == vecC.X) return;
                vecC.Y = value;
                //NotifyPropertyChanged(nameof(VekCY));
            }
        }
        public float VekCY
        {
            get { return vecC.Y; }
            set
            {
                if (value == vecC.Y) return;
                vecC.Y = value;
                //NotifyPropertyChanged(nameof(VekCY));
            }
        }
        public float VekCZ
        {
            get { return vecC.Z; }
            set
            {
                if (value == vecC.Z) return;
                vecC.Z = value;
                //NotifyPropertyChanged(nameof(VekCY));
            }
        }




        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

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

        private double Skalarprodukt(Vector3 vecA, Vector3 vecB)
        {
            Vector3 vecBuff = vecA * vecB;
            return vecBuff.X + vecBuff.Y + vecBuff.Z;
        }

        private Vector3 Kreuzprodukt(Vector3 vecA, Vector3 vecB)
        {
            Vector3 vecbuff;
            vecbuff.X = vecA.Y * vecB.Z - vecA.Z * vecB.Y;
            vecbuff.Y = vecA.Z * vecB.X - vecA.X * vecB.Z;
            vecbuff.Z = vecA.X * vecB.Y - vecA.Y * vecB.X;
            return vecbuff;
        }

        private double Spatprodukt(Vector3 vecA, Vector3 vecB, Vector3 vecC)
        {
            return Skalarprodukt(vecA, Kreuzprodukt(vecB, vecC));
        }

        private void bt_berechne_Click(object sender, RoutedEventArgs e)
        {
            tb_Ba.Text = vecA.Length().ToString();
            tb_Bb.Text = vecB.Length().ToString();
            tb_Bc.Text = vecC.Length().ToString();
            
        }
    }
}
