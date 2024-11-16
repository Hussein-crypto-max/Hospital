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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        hospitalEntities db = new hospitalEntities();
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

            if(namebox.Text ==""|| Emailbox.Text==""|| passwordbox.Password=="")
            {
                MessageBox.Show("Fields Reqiard");
                return;
            }
            Patient patient = new Patient();
            patient.Pname = namebox.Text;
            patient.Pemail = Emailbox.Text;
            patient.Ppassword=passwordbox.Password;
            db.Patients.Add(patient);
            db.SaveChanges();
            MessageBox.Show("Added Successfully!");
                NavigationService.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }
    }
}
