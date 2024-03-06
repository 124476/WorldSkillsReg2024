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
    /// Логика взаимодействия для RedackZapiska.xaml
    /// </summary>
    public partial class RedackZapiska : Page
    {
        Zapiska zapiska;
        public RedackZapiska(Zapiska zap)
        {
            InitializeComponent();
            zapiska = zap;
            ComboDoctors.ItemsSource = App.DB.Doctor.Where(x => x.OtdelId < 10).ToList();
            ComboPacients.ItemsSource = App.DB.Pacient.ToList();
            zapiska.IsPredvar = false;
            DataContext = zapiska;
        }

        private void Refrash()
        {
            if (ComboDoctors.SelectedIndex != -1 && PacDate.SelectedDate != null)
            {
                ComboTimes.ItemsSource = App.DB.Raspisanie.Where(x => x.Doctor.Surname == ComboDoctors.Text
                && x.Date == PacDate.SelectedDate && x.IsCanUsePac == true).ToList();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ComboTimes.SelectedItem != null && ComboDoctors.SelectedItem != null
                && ComboPacients != null && PacDate.SelectedDate != null)
            {
                App.DB.Zapiska.Add(zapiska);
                TimeSpan timeSpan = TimeSpan.Parse(ComboTimes.Text);
                zapiska.Raspisanie = App.DB.Raspisanie.FirstOrDefault(x => x.Doctor.Surname == ComboDoctors.Text
                && x.Date == PacDate.SelectedDate && x.Time == timeSpan);
                zapiska.Raspisanie.IsCanUsePac = false;
                zapiska.Pacient = ComboPacients.SelectedItem as Pacient;
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
        }

        private void ComboDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }

        private void PacDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }
    }
}
