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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        hospitalEntities db = new hospitalEntities();
        public Login()
        {
            InitializeComponent();
        }
        // i have made alot of changes nehaanehaena
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Emailbox.Text == "" || passwordbox.Password == "")

                {
                    MessageBox.Show("Feilds Reqiard");
                    return;
                }
                var Check = db.Patients.FirstOrDefault(x => x.Pemail == Emailbox.Text && x.Ppassword == passwordbox.Password);

                if (Check != null)
                {
               
                    MessageBox.Show("Logged in Successfully!");
                    NavigationService.Navigate(new Appintment_Page(Check.Pid));
                }
                if (Check == null)
                {
                    MessageBox.Show("Invalud Email or Password");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
    }
}

