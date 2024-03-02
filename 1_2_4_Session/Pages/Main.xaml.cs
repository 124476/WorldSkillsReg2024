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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void NewPac_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPacient(new Pacient()));
        }

        private void GotPac_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GotPacient());
        }
    }
}
