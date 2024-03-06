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
    /// Логика взаимодействия для NewRaspisan.xaml
    /// </summary>
    public partial class NewRaspisan : Page
    {
        Doctor doctor;
        public NewRaspisan(Doctor doc)
        {
            InitializeComponent();
            doctor = doc;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (DateStart.SelectedDate != null && DateEnd.SelectedDate != null
                && TimePac != null)
            {
                DateTime dateTime = DateStart.SelectedDate.Value;
                while(dateTime <= DateEnd.SelectedDate.Value)
                {
                    Raspisanie raspisanie = new Raspisanie();
                    raspisanie.Date = dateTime;
                    raspisanie.Time = TimeSpan.Parse(TimePac.Text);
                    raspisanie.DoctorId = doctor.Id;
                    raspisanie.IsCanUse = false;
                    raspisanie.IsSpech = IsSpech.IsChecked;
                    raspisanie.IsCanUsePac = true;
                    App.DB.Raspisanie.Add(raspisanie);
                    dateTime = dateTime.AddDays(1);
                }
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
