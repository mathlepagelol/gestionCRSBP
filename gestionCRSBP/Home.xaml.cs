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
        Biblio crsbp = new Biblio("CRSBP du Bas-St-Laurent", "465 rue St-Pierre", "4188671682", "G5R4T6");
        
        public Home()
        {
            InitializeComponent();
        }

        public void viderChamps()
        {
            edtNoMembre.Text = edtNomMembre.Text = edtPrenomMembre.Text = edtAdresseMembre.Text = edtCodePostalMembre.Text = edtTelephoneMembre.Text = "";
            edtNoEmploye.Text = edtNomEmploye.Text = edtPrenomEmploye.Text = edtAdresseEmploye.Text = edtCodePostalEmploye.Text = edtTelephoneEmploye.Text = "";
        }

        private void MenuQuitter_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Application de gestion des locations pour le Réseau BIBLIO du Bas-Saint-Laurent \n\n Auteur : Mathieu Lepage \n Version : 1.0");
        }

        /* -------------- Fonctions de gestion des membres ------------------------- */
        private void btnAjouterMembre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                crsbp.listeMembre.Add(new Membre() { NoMembre = edtNoMembre.Text, Nom = edtNomMembre.Text, Prenom = edtPrenomMembre.Text, Adresse = edtAdresseMembre.Text, Telephone = edtTelephoneMembre.Text, CodePostal = edtCodePostalMembre.Text });
                lvMembre.ItemsSource = null;
                lvMembre.ItemsSource = crsbp.listeMembre;
                viderChamps();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifierMembre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Membre monMembre;
                monMembre = crsbp.ObtenirMembre(new Membre() { NoMembre = crsbp.ObtenirListeMembre()[lvMembre.SelectedIndex].NoMembre });

                monMembre.Nom = edtNomMembre.Text;
                monMembre.Prenom = edtPrenomMembre.Text;
                monMembre.Adresse = edtAdresseMembre.Text;
                monMembre.Telephone = edtTelephoneMembre.Text;
                monMembre.CodePostal = edtCodePostalMembre.Text;
                lvMembre.ItemsSource = null;
                lvMembre.ItemsSource = crsbp.listeMembre;
                MessageBox.Show("Modification réussie");
                viderChamps();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimerMembre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSelected_Membre(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Membre monMembre;
                monMembre = crsbp.ObtenirMembre(new Membre() { NoMembre = crsbp.ObtenirListeMembre()[lvMembre.SelectedIndex].NoMembre });
                edtNoMembre.Text = monMembre.NoMembre;
                edtNomMembre.Text = monMembre.Nom;
                edtPrenomMembre.Text = monMembre.Prenom;
                edtAdresseMembre.Text = monMembre.Adresse;
                edtTelephoneMembre.Text = monMembre.Telephone;
                edtCodePostalMembre.Text = monMembre.CodePostal;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /* -------------- Fonctions de gestion des employes ------------------------- */
        private void btnAjouterEmploye_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                crsbp.listeEmploye.Add(new Employe() { NoEmploye = edtNoEmploye.Text, Nom = edtNomEmploye.Text, Prenom = edtPrenomEmploye.Text, Adresse = edtAdresseEmploye.Text, Telephone = edtTelephoneEmploye.Text, CodePostal = edtCodePostalEmploye.Text });
                lvEmploye.ItemsSource = null;
                lvEmploye.ItemsSource = crsbp.listeEmploye;
                viderChamps();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifierEmploye_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employe monEmploye;
                monEmploye = crsbp.ObtenirEmploye(new Employe() { NoEmploye = crsbp.ObtenirListeEmploye()[lvEmploye.SelectedIndex].NoEmploye });

                monEmploye.Nom = edtNomEmploye.Text;
                monEmploye.Prenom = edtPrenomEmploye.Text;
                monEmploye.Adresse = edtAdresseEmploye.Text;
                monEmploye.Telephone = edtTelephoneEmploye.Text;
                monEmploye.CodePostal = edtCodePostalEmploye.Text;
                lvEmploye.ItemsSource = null;
                lvEmploye.ItemsSource = crsbp.listeEmploye;
                MessageBox.Show("Modification réussie");
                viderChamps();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimerEmploye_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSelected_Employe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Employe monEmploye;
                monEmploye = crsbp.ObtenirEmploye(new Employe() { NoEmploye = crsbp.ObtenirListeEmploye()[lvEmploye.SelectedIndex].NoEmploye});
                edtNoEmploye.Text = monEmploye.NoEmploye;
                edtNomEmploye.Text = monEmploye.Nom;
                edtPrenomEmploye.Text = monEmploye.Prenom;
                edtAdresseEmploye.Text = monEmploye.Adresse;
                edtTelephoneEmploye.Text = monEmploye.Telephone;
                edtCodePostalEmploye.Text = monEmploye.CodePostal;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
