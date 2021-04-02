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

        private void Button_Click(object sender, RoutedEventArgs e)
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
