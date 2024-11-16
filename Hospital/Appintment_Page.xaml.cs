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
    /// Interaction logic for Appintment_Page.xaml
    /// </summary>
    public partial class Appintment_Page : Page
    {
        public int pp_id;
        hospitalEntities db = new hospitalEntities();
        public Appintment_Page(int id)
        {
            this.pp_id = id;
            InitializeComponent();
            refresh();
            load_compo();

           
        }
        public void refresh()
        {
            datagrid.ItemsSource = db.Doctors.ToList();
        }
        public void load_compo ()
        {
            var load = db.Doctors.Select(x => x.Dname).ToList();
            load. Add("");
            combo.ItemsSource = load;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(idtxt.Text);
            if (combo.Text == "" && idtxt.Text != "")
            {
                var check = db.Doctors.Where(x => x.Did == Id).ToList();

                if (check != null)
                {
                    datagrid.ItemsSource = check;
                }
            }
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(combo.SelectedItem.ToString() =="")
            {
                refresh();
                return;
            }
            var selected = combo.SelectedItem.ToString();
            var check = db.Doctors.Where(x=>x.Dname == selected).ToList();
            if(check != null)
            {
                datagrid.ItemsSource = check;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(idtxt.Text);
            var check=db.Doctors.Where(db=>db.Did == ID).ToList();
            if(check != null)
            {
                
                NavigationService.Navigate(new Appintment2(ID,pp_id));
                return;

            }
            if (check == null)
            {
                MessageBox.Show("Id Not Found");
                return;
            }

        }
    }
}
