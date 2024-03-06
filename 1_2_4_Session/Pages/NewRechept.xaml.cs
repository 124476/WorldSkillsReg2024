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
    /// Логика взаимодействия для NewRechept.xaml
    /// </summary>
    public partial class NewRechept : Page
    {
        Rechpt rechpt;
        public NewRechept(Place place)
        {
            InitializeComponent();
            rechpt = new Rechpt();
            rechpt.Place = place;
            DataContext = rechpt;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (rechpt.Name != null && rechpt.Format != null && rechpt.Doza != null)
            {
                App.DB.Rechpt.Add(rechpt);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
