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
    /// Interaction logic for Appintment2.xaml
    /// </summary>
    public partial class Appintment2 : Page
    {
        hospitalEntities db = new hospitalEntities();
        public int D_ID;
        public int pp_ID;
        public Appintment2(int d_ID, int p_ID)
        {
            // i have made alot of changes nehaanehaena
            InitializeComponent();
            D_ID = d_ID;
            pp_ID = p_ID;
            show_Deat();
        }
        public void show_Deat()

        {
            Appointment appointment = new Appointment();
            var Doctor_Check = db.Doctors.FirstOrDefault(x => x.Did == D_ID);

            var Pacient_Check = db.Patients.FirstOrDefault(x => x.Pid == pp_ID); 
            p_name.Content = Pacient_Check.Pname;
            d_name.Content = Doctor_Check.Dname;
            data.Content = DateTime.Now.ToString();
            spec.Content = Doctor_Check.Dspecialize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Pacient_Check = db.Patients.FirstOrDefault(x => x.Pid == pp_ID); 
            var Doctor_Check = db.Doctors.FirstOrDefault(x => x.Did == D_ID);
          
           

            Appointment appointment = new Appointment();
            appointment.Pid = pp_ID;
            appointment.Did = D_ID;
            appointment.AppointemtDate = DateTime.Now.ToString();
            db.Appointments.Add(appointment);
            db.SaveChanges();
            MessageBox.Show("Appitment Made Successfully!");
            
        }
    }
}
