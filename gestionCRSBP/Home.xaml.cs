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
using System.IO;
using System.Xml.Serialization;

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
            if (File.Exists("gestionCRSBP.xml"))
            {
                XmlSerializer leFichierCRSBP = new XmlSerializer(typeof(Biblio));

                FileStream fichierLogique;

                fichierLogique = File.OpenRead("gestionCRSBP.xml");
                crsbp = (Biblio)leFichierCRSBP.Deserialize(fichierLogique);
                fichierLogique.Close();
            }
            lvLocation.ItemsSource = null;
            lvLocation.ItemsSource = crsbp.listeLocation;
            peuplerLesListes();
        }

        public void viderChamps()
        {
            edtNoMembre.Text = edtNomMembre.Text = edtPrenomMembre.Text = edtAdresseMembre.Text = edtCodePostalMembre.Text = edtTelephoneMembre.Text = "";
            edtNoEmploye.Text = edtNomEmploye.Text = edtPrenomEmploye.Text = edtAdresseEmploye.Text = edtCodePostalEmploye.Text = edtTelephoneEmploye.Text = "";
            edtNoLivre.Text = edtTitreLivre.Text = edtQuantiteLivre.Text = dpDateLivre.Text = edtAuteurLivre.Text = "";
            edtNoLocation.Text = dpDateDebutLocation.Text = dpDateFinLocation.Text = dpDateLivre.Text = cbxMembreLocation.Text = cbxEmployeLocation.Text = "";
        }

        private void MenuQuitter_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Application de gestion des locations pour le Réseau BIBLIO du Bas-Saint-Laurent \n\n Auteur : Mathieu Lepage \n Version : 1.0");
        }

        private void MenuSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("gestionCRSBP.xml"))
                {
                    File.Delete("gestionCRSBP.xml");
                }
                XmlSerializer leFichierCRSBP = new XmlSerializer(typeof(Biblio));
                FileStream fichierLogique;

                using (fichierLogique = File.OpenWrite("gestionCRSBP.xml"))
                {
                    leFichierCRSBP.Serialize(fichierLogique, crsbp);
                }
                MessageBox.Show("Sauvegarde dans le fichier XML réussie");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void peuplerLesListes()
        {
            lvMembre.ItemsSource = null;
            lvMembre.ItemsSource = crsbp.listeMembre;
            lvEmploye.ItemsSource = null;
            lvEmploye.ItemsSource = crsbp.listeEmploye;
            lvLivre.ItemsSource = null;
            lvLivre.ItemsSource = crsbp.listeLivre;
            lvLivreDispo.ItemsSource = null;
            lvLivreDispo.ItemsSource = crsbp.listeLivre;
            cbxMembreLocation.Items.Clear();
            foreach (Membre membre in crsbp.listeMembre)
            { cbxMembreLocation.Items.Add(membre); }
            cbxEmployeLocation.Items.Clear();
            foreach (Employe employe in crsbp.listeEmploye)
            { cbxEmployeLocation.Items.Add(employe);}
        }

        /* -------------- Fonctions de gestion des membres ------------------------- */
        private void btnAjouterMembre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                crsbp.listeMembre.Add(new Membre() { NoMembre = edtNoMembre.Text, Nom = edtNomMembre.Text, Prenom = edtPrenomMembre.Text, Adresse = edtAdresseMembre.Text, Telephone = edtTelephoneMembre.Text, CodePostal = edtCodePostalMembre.Text });
                peuplerLesListes();
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
                MessageBox.Show("Modification réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimerMembre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Membre monMembre;
                monMembre = crsbp.ObtenirMembre(new Membre() { NoMembre = crsbp.ObtenirListeMembre()[lvMembre.SelectedIndex].NoMembre });
                crsbp.EnleverMembre(monMembre);
                MessageBox.Show("Suppression réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                peuplerLesListes();
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
                MessageBox.Show("Modification réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimerEmploye_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employe monEmploye;
                monEmploye = crsbp.ObtenirEmploye(new Employe() { NoEmploye = crsbp.ObtenirListeEmploye()[lvEmploye.SelectedIndex].NoEmploye });
                crsbp.EnleverEmploye(monEmploye);
                MessageBox.Show("Suppression réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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

        /* -------------- Fonctions de gestion des livres ------------------------- */

        private void btnAjouterLivre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                crsbp.listeLivre.Add(new Livre() { NoSerie = edtNoLivre.Text, Titre = edtTitreLivre.Text, Qte = int.Parse(edtQuantiteLivre.Text), DatePublication = DateTime.Parse(dpDateLivre.Text), Auteur = edtAuteurLivre.Text });
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifierLivre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Livre monLivre;
                monLivre = crsbp.ObtenirLivre(new Livre() { NoSerie = crsbp.ObtenirListeLivre()[lvLivre.SelectedIndex].NoSerie });
                monLivre.Titre = edtTitreLivre.Text;
                monLivre.Qte = int.Parse(edtQuantiteLivre.Text);
                monLivre.DatePublication = DateTime.Parse(dpDateLivre.Text);
                monLivre.Auteur = edtAuteurLivre.Text;
                MessageBox.Show("Modification réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimerLivre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Livre monLivre;
                monLivre = crsbp.ObtenirLivre(new Livre() { NoSerie = crsbp.ObtenirListeLivre()[lvLivre.SelectedIndex].NoSerie });
                crsbp.EnleverLivre(monLivre);
                MessageBox.Show("Suppression réussie");
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowSelected_Livre(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Livre monLivre;
                monLivre = crsbp.ObtenirLivre(new Livre() { NoSerie = crsbp.ObtenirListeLivre()[lvLivre.SelectedIndex].NoSerie });
                edtNoLivre.Text = monLivre.NoSerie;
                edtTitreLivre.Text = monLivre.Titre;
                edtQuantiteLivre.Text = monLivre.Qte.ToString();
                dpDateLivre.Text = monLivre.DatePublication.ToString();
                edtAuteurLivre.Text = monLivre.Auteur;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /* -------------- Fonctions de gestion des locations ------------------------- */

        private void btnInitialiserLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employe monEmploye;
                monEmploye = crsbp.ObtenirEmploye(new Employe() { NoEmploye = crsbp.ObtenirListeEmploye()[cbxEmployeLocation.SelectedIndex].NoEmploye });
                Membre monMembre;
                monMembre = crsbp.ObtenirMembre(new Membre() { NoMembre = crsbp.ObtenirListeMembre()[cbxMembreLocation.SelectedIndex].NoMembre });
                crsbp.listeLocation.Add(new Location() { NoLocation = edtNoLocation.Text, DateDebut = DateTime.Parse(dpDateDebutLocation.Text), DateFin = DateTime.Parse(dpDateFinLocation.Text), unEmploye = monEmploye, unMembre = monMembre});
                lvLocation.ItemsSource = null;
                lvLocation.ItemsSource = crsbp.listeLocation;
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifierLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location maLocation;
                maLocation = crsbp.ObtenirLocation(new Location() { NoLocation = crsbp.ObtenirListeLocation()[lvLocation.SelectedIndex].NoLocation });

                Employe monEmploye;
                monEmploye = crsbp.ObtenirEmploye(new Employe() { NoEmploye = crsbp.ObtenirListeEmploye()[cbxEmployeLocation.SelectedIndex].NoEmploye });
                Membre monMembre;
                monMembre = crsbp.ObtenirMembre(new Membre() { NoMembre = crsbp.ObtenirListeMembre()[cbxMembreLocation.SelectedIndex].NoMembre });

                maLocation.NoLocation = edtNoLocation.Text;
                maLocation.DateDebut = DateTime.Parse(dpDateDebutLocation.Text);
                maLocation.DateFin = DateTime.Parse(dpDateFinLocation.Text);
                maLocation.unMembre = monMembre;
                maLocation.unEmploye = monEmploye;
                MessageBox.Show("Modification réussie");
                lvLocation.ItemsSource = null;
                lvLocation.ItemsSource = crsbp.listeLocation;
                peuplerLesListes();
                viderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAjouterLivreLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location maLocation;
                maLocation = crsbp.ObtenirLocation(new Location() { NoLocation = crsbp.ObtenirListeLocation()[lvLocation.SelectedIndex].NoLocation });
                Livre monLivre;
                monLivre = crsbp.ObtenirLivre(new Livre() { NoSerie = crsbp.ObtenirListeLivre()[lvLivreDispo.SelectedIndex].NoSerie });
                if (monLivre.Qte > 0 && monLivre.Qte >= int.Parse(edtQteLocation.Text))
                {
                    maLocation.AjouterLivre(new Livre() { NoSerie = monLivre.NoSerie, Titre = monLivre.Titre, Qte = int.Parse(edtQteLocation.Text), DatePublication = monLivre.DatePublication, Auteur = monLivre.Auteur });
                    monLivre.Qte = monLivre.Qte - int.Parse(edtQteLocation.Text);
                    lvLocationMembre.ItemsSource = null;
                    lvLocationMembre.ItemsSource = maLocation.listeLivre;
                    peuplerLesListes();
                }
                else
                {
                    MessageBox.Show("Quantité insuffisante...");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Assurez-vous d'avoir au moins une location de sélectionnée...");
            }
        }

        private void btnRetirerLivreLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location maLocation;
                maLocation = crsbp.ObtenirLocation(new Location() { NoLocation = crsbp.ObtenirListeLocation()[lvLocation.SelectedIndex].NoLocation });
                Livre monLivre; Livre livreOriginal;
                
                monLivre = maLocation.ObtenirLivre(new Livre() { NoSerie = maLocation.ObtenirListeLivre()[lvLocationMembre.SelectedIndex].NoSerie });
                livreOriginal = crsbp.ObtenirLivre(new Livre() { NoSerie = monLivre.NoSerie });

                if (monLivre.Qte > 0 && int.Parse(edtQteLocation.Text) <= monLivre.Qte)
                {
                    monLivre.Qte = monLivre.Qte - int.Parse(edtQteLocation.Text);
                    livreOriginal.Qte = livreOriginal.Qte + int.Parse(edtQteLocation.Text);
                    if (monLivre.Qte <= 0)
                        maLocation.EnleverLivre(monLivre);
                    lvLocationMembre.ItemsSource = null;
                    lvLocationMembre.ItemsSource = maLocation.listeLivre;
                    peuplerLesListes();
                }
                else
                    MessageBox.Show("Vous ne possédez pas en main autant de copie...");
            }
            catch (Exception)
            {
                MessageBox.Show("Assurez-vous d'avoir au moins une location de sélectionnée...");
            }
        }

        private void ShowSelected_Location(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Location maLocation;
                maLocation = crsbp.ObtenirLocation(new Location() { NoLocation = crsbp.ObtenirListeLocation()[lvLocation.SelectedIndex].NoLocation });
                edtNoLocation.Text = maLocation.NoLocation;
                dpDateDebutLocation.Text = maLocation.DateDebut.ToString();
                dpDateFinLocation.Text = maLocation.DateFin.ToString();
                cbxMembreLocation.Text = maLocation.unMembre.ToString();
                cbxEmployeLocation.Text = maLocation.unEmploye.ToString();
                lvLocationMembre.ItemsSource = null;
                lvLocationMembre.ItemsSource = maLocation.listeLivre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
