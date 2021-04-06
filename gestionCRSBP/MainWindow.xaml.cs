/*
 * Classe : MainWindow.xaml.cs
 * 
 * Version : 1.0
 * 
 * Auteur : Mathieu Lepage
 * 
 * Date : 02/04/2021
 * 
 * But :  Classe qui représente toute la logique applicative (code-behind) de la 'Main Window' de l'application. Pour cette application, elle sert simplement de
 *        NavigationWindow parent pour nos pages enfants (Auth/Home).
 */
using System.Windows.Navigation;

/// <summary>
/// Namespace pour les files de code-behind
/// </summary>
namespace gestionCRSBP
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
