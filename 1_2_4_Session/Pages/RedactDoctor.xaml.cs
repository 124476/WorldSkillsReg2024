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
    /// Логика взаимодействия для RedactDoctor.xaml
    /// </summary>
    public partial class RedactDoctor : Page
    {
        Doctor doctor;
        public RedactDoctor(Doctor doc)
        {
            InitializeComponent();
            doctor = doc;
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DateRaspisans.ItemsSource = App.DB.Raspisanie.Where(x => x.DoctorId == doctor.Id).ToList();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewRaspisan(doctor));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (Raspisanie raspisanie in App.DB.Raspisanie.Where(x => x.DoctorId == doctor.Id))
            {
                if (raspisanie.IsCanUse == false)
                {
                    raspisanie.IsCanUsePac = true;
                }
                raspisanie.IsCanUse = true;
            }
            App.DB.SaveChanges();
            DateRaspisans.ItemsSource = App.DB.Raspisanie.Where(x => x.DoctorId == doctor.Id).ToList();
            MessageBox.Show("Утверждено!");
        }
    }
}
