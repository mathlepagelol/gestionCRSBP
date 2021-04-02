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
using gestionCRSBP.Models;

namespace gestionCRSBP
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            Biblio crsbp = new Biblio("CRSBP du Bas-St-Laurent", "465 rue St-Pierre", "4188671682", "G5R4T6");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Application de gestion des locations pour le Réseau BIBLIO du Bas-Saint-Laurent \n\n Auteur : Mathieu Lepage \n Version : 1.0");
        }


    }
}
