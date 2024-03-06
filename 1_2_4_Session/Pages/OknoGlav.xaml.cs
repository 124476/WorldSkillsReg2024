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
    /// Логика взаимодействия для OknoGlav.xaml
    /// </summary>
    public partial class OknoGlav : Page
    {
        public OknoGlav()
        {
            InitializeComponent();
            DataDoctors.ItemsSource = App.DB.Doctor.Where(x => x.OtdelId < 10).ToList();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = DataDoctors.SelectedItem as Doctor;
            if (doctor != null)
            {
                NavigationService.Navigate(new RedactDoctor(doctor));
            }
            else
            {
                MessageBox.Show("Выберите доктора!");
            }
        }
    }
}
