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
    /// Логика взаимодействия для OknoDoctor.xaml
    /// </summary>
    public partial class OknoDoctor : Page
    {
        public OknoDoctor()
        {
            InitializeComponent();
            DataPacients.ItemsSource = App.DB.Pacient.ToList();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Pacient pacient = DataPacients.SelectedItem as Pacient;
            if (pacient != null)
            {
                NavigationService.Navigate(new RegPacient(pacient));
            }
        }

        private void Nap_Click(object sender, RoutedEventArgs e)
        {
            Pacient pacient = DataPacients.SelectedItem as Pacient;
            if (pacient != null)
            {
                NavigationService.Navigate(new Napravlen(pacient));
            }

        }
    }
}
