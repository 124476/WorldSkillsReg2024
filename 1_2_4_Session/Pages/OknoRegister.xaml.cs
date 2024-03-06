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
    /// Логика взаимодействия для OknoRegister.xaml
    /// </summary>
    public partial class OknoRegister : Page
    {
        public OknoRegister()
        {
            InitializeComponent();
            ComboVid.ItemsSource = new string[] { "Дневное", "Недельное" };
            ComboVid.SelectedIndex = 0;
            PoiskDate.SelectedDate = DateTime.Now;
        }

        private void ComboVid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Refrash();
        }

        private void PoiskBtn_Click(object sender, RoutedEventArgs e)
        {
            Refrash();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Zapiska zapiska = DataZapis.SelectedItem as Zapiska;
            if (zapiska != null)
            {
                zapiska.Raspisanie.IsCanUsePac = true;
                App.DB.Zapiska.Remove(zapiska);
                App.DB.SaveChanges();
                Refrash();
            }
            else
            {
                MessageBox.Show("Не выбрано!");
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedackZapiska(new Zapiska()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrash();
        }

        private void Refrash()
        {
            var zapickas = App.DB.Zapiska.ToList();
            if (ComboVid.SelectedIndex == 0)
            {
                zapickas = zapickas.Where(x => x.Raspisanie.Date == PoiskDate.SelectedDate).ToList();
            }
            else {
                zapickas = zapickas.Where(x => PoiskDate.SelectedDate <= x.Raspisanie.Date
                && x.Raspisanie.Date <= PoiskDate.SelectedDate.Value.AddDays(7)).ToList(); 
            }

            if (PoiskText.Text != null)
            {
                zapickas = zapickas.Where(x => x.Pacient.Surname.Contains(PoiskText.Text)
                || x.Raspisanie.Doctor.Surname.Contains(PoiskText.Text)
                || x.Raspisanie.Doctor.Otdel.Name.Contains(PoiskText.Text)).ToList();
            }
            DataZapis.ItemsSource = zapickas;
        }

        private void ComboVid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }

        private void PoiskDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }
    }
}
