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
    /// Логика взаимодействия для GositalPacient.xaml
    /// </summary>
    public partial class GositalPacient : Page
    {
        Gospital gospital;
        public GositalPacient(Pacient pacient)
        {
            InitializeComponent();

            gospital = App.DB.Gospital.FirstOrDefault(x => x.PacientId == pacient.Id);
            if (gospital == null)
            {
                gospital = new Gospital();
                gospital.IsCan = false;
                gospital.Pacient = pacient;
                gospital.IsMoney = false;
            }
            ComboDiagnoz.ItemsSource = App.DB.Diagnoz.ToList();
            ComboOtdel.ItemsSource = App.DB.Otdel.Where(x => x.Id < 10).ToList();
            DataContext = gospital;

            if (gospital.IsCan == false)
            {
                TextBlockPrich.Visibility = Visibility.Hidden;
                PrichText.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBlockPrich.Visibility = Visibility.Visible;
                PrichText.Visibility = Visibility.Visible;
            }
        }

        private void PrichBox_Click(object sender, RoutedEventArgs e)
        {
            if (PrichBox.IsChecked == false)
            {
                TextBlockPrich.Visibility = Visibility.Hidden;
                PrichText.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBlockPrich.Visibility = Visibility.Visible;
                PrichText.Visibility = Visibility.Visible;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (gospital.Chel != null && DateEnd.SelectedDate != null
                && DateStart.SelectedDate != null && ComboOtdel.SelectedIndex != -1
                && ComboDiagnoz.SelectedIndex != -1)
            {
                if (gospital.Id == 0)
                {
                    App.DB.Gospital.Add(gospital);
                }
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
