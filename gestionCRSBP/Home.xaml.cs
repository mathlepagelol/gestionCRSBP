/*
 * Classe : Home.xaml.cs
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente toute la logique applicative (code-behind) de la page principale.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using gestionCRSBP.Models;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// Namespace pour les files de code-behind
/// </summary>
namespace gestionCRSBP
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// On instancie notre bibliothèque qui contiendra tous les listes
        /// </summary>
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

        /* -------------- Fonctions du menu & fonctions complémentaires ------------------------- */

        /// <summary>
        /// Option du menu qui permet de fermer l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuQuitter_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// Option du menu qui permet d'obtenir des renseignements sur l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Application de gestion des locations pour le Réseau BIBLIO du Bas-Saint-Laurent \n\n Auteur : Mathieu Lepage \n Version : 1.0");
        }

        /// <summary>
        /// Option du menu qui permet de sauvegarde l'information des listes dans un fichier XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fonction qui permet de repeupler nos listes/champs texte
        /// </summary>
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

        /// <summary>
        /// Fonction qui permet de vider les champs TextBox & ComboBox
        /// </summary>
        public void viderChamps()
        {
            //Input fields membre
            edtNoMembre.Text = edtNomMembre.Text = edtPrenomMembre.Text = edtAdresseMembre.Text = edtCodePostalMembre.Text = edtTelephoneMembre.Text = "";
            //Input fields employe
            edtNoEmploye.Text = edtNomEmploye.Text = edtPrenomEmploye.Text = edtAdresseEmploye.Text = edtCodePostalEmploye.Text = edtTelephoneEmploye.Text = "";
            //Input fields livre
            edtNoLivre.Text = edtTitreLivre.Text = edtQuantiteLivre.Text = dpDateLivre.Text = edtAuteurLivre.Text = "";
            //Input fields location
            edtNoLocation.Text = dpDateDebutLocation.Text = dpDateFinLocation.Text = dpDateLivre.Text = cbxMembreLocation.Text = cbxEmployeLocation.Text = "";
        }

        /* -------------- Fonctions de gestion des membres ------------------------- */
       
       /// <summary>
       /// Bouton qui permet d'inscrire un membre dans la liste de la bibliothèque
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de modifier un membre de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de supprimer un membre de la liste de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fonction qui permet d'afficher les informations du membre sélectionné dans les champs respectifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet d'inscrire un employe dans la liste de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de modifier un employe de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de supprimer un employe de la liste de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fonction qui permet d'afficher les informations d'un employe sélectionné dans les champs respectifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet d'inscrire un livre dans la liste de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de modifier un livre de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de supprimer un livre de la liste de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fonction qui permet d'afficher les informations d'un livre sélectionné dans les champs respectifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet d'initialiser une location dans le système de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de modifier une location dans le système de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet d'inscrire un livre à la location d'un membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton qui permet de retirer un livre à la location d'un membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Fonction qui permet d'afficher les informations d'une location sélectionnée dans les champs respectifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
