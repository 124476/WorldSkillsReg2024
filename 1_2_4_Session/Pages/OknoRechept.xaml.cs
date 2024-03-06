using _1_2_4_Session.Models;
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

namespace _1_2_4_Session.Pages
{
    /// <summary>
    /// Логика взаимодействия для OknoRechept.xaml
    /// </summary>
    public partial class OknoRechept : Page
    {
        Place place;
        public OknoRechept(Place plac)
        {
            InitializeComponent();
            place = plac;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Rechpt rechpt = DataRechepts.SelectedItem as Rechpt;
            if (rechpt != null)
            {
                App.DB.Rechpt.Remove(rechpt);
                App.DB.SaveChanges();
                DataRechepts.ItemsSource = App.DB.Rechpt.Where(x => x.PlacesId == place.Id).ToList();
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewRechept(place));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataRechepts.ItemsSource = App.DB.Rechpt.Where(x => x.PlacesId == place.Id).ToList();
        }
    }
}
