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
    /// Логика взаимодействия для OknoAdmin.xaml
    /// </summary>
    public partial class OknoAdmin : Page
    {
        public OknoAdmin()
        {
            InitializeComponent();
        }

        private void Pac_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoDoctor());
        }

        private void Ras_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoRegister());
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoGlav());
        }
    }
}
