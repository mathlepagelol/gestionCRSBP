/*
 * Classe : Auth.xaml.cs
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente toute la logique applicative (code-behind) de la page d'authentification  
 */

using System;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Namespace pour les files de code-behind
/// </summary>
namespace gestionCRSBP
{
    /// <summary>
    /// Logique d'interaction pour Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bouton qui permet de connecter l'utilisateur => redirection à la HomePage de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edtUsername.Text != "admin" || edtPassword.Password != "admin" )
                {
                    this.lblInvalid.Visibility = Visibility.Visible;
                    this.edtPassword.Password = "";
                    this.edtUsername.Text = "";
                }
                else
                {
                    Home homePage = new Home();
                    this.NavigationService.Navigate(homePage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
