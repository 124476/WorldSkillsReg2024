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
            ComboVid.ItemsSource = new string[] { "Дневное", "Недельное" };
            ComboVid.SelectedIndex = 0;
            PoiskDate.SelectedDate = DateTime.Now;
            Refrash();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            Raspisanie raspisanie = DataPasrisans.SelectedItem as Raspisanie;
            if (raspisanie != null)
            {
                App.DB.Raspisanie.Remove(raspisanie);
                App.DB.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберите расписание!");
            }
        }
        private void Refrash()
        {
            var raspican = App.DB.Raspisanie.ToList();
            if (ComboVid.SelectedIndex == 0)
            {
                raspican = raspican.Where(x => x.Date == PoiskDate.SelectedDate).ToList();
            }
            else
            {
                raspican = raspican.Where(x => PoiskDate.SelectedDate <= x.Date && x.Date <= PoiskDate.SelectedDate.Value.AddDays(7)).ToList();
            }
            raspican = raspican.Where(x => x.Doctor.Surname.ToLower().Contains(PoiskText.Text.ToLower()) || x.Doctor.Otdel.Name.ToLower().Contains(PoiskText.Text.ToLower())).ToList();

            DataPasrisans.ItemsSource = raspican;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewRaspisan());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (Raspisanie raspisanie in App.DB.Raspisanie)
            {
                if (raspisanie.IsCanUse == false)
                {
                    raspisanie.IsCanUsePac = true;
                }
                raspisanie.IsCanUse = true;
            }
            App.DB.SaveChanges();
            MessageBox.Show("Утверждено!");
            Refrash();
        }

        private void PoiskBtn_Click(object sender, RoutedEventArgs e)
        {
            Refrash();
        }

        private void ComboVid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }

        private void PoiskDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrash();
        }
    }
}
