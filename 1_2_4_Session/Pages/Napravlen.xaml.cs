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
    /// Логика взаимодействия для Napravlen.xaml
    /// </summary>
    public partial class Napravlen : Page
    {
        Place place;
        public Napravlen(Pacient pacient)
        {
            InitializeComponent();
            place = App.DB.Place.FirstOrDefault(x => x.PacientId == pacient.Id);
            if (place == null)
            {
                place = new Place();
                place.Pacient = pacient;
            }

            ComboDoctors.ItemsSource = App.DB.Doctor.Where(x => x.OtdelId < 10).ToList();
            ComboTips.ItemsSource = App.DB.Tip.ToList();
            ComboMeropriations.ItemsSource = App.DB.Meroprition.ToList();
            ComboResults.ItemsSource = App.DB.Result.ToList();
            DataContext = place;
        }

        private void BtnRechept_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoRechept(place));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (PicDate.SelectedDate != null && ComboMeropriations.SelectedIndex != -1
                & ComboDoctors.SelectedIndex != -1 && ComboResults.SelectedIndex != -1
                && ComboTips.SelectedIndex != -1 && place.Recomendation != null)
            {
                if (place.Id == 0)
                {
                    App.DB.Place.Add(place);
                }
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
