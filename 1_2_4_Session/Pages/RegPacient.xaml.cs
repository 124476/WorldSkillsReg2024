using _1_2_4_Session.Models;
using _1_2_4_Session.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для RegPacient.xaml
    /// </summary>
    public partial class RegPacient : Page
    {
        Pacient pacient;
        public RegPacient(Pacient pac)
        {
            InitializeComponent();
            pacient = pac;
            ComboPols.ItemsSource = App.DB.Pol.ToList();
            DataContext = pacient;
            if (pacient.Id == 0)
            {
                GotQr.Visibility = Visibility.Hidden;
            }
        }

        private void GotPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = ".png; | *.png;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                pacient.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = pacient;
            }
        }

        private void GotQr_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new QtOkno(pacient);
            dialog.ShowDialog();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (pacient.Surname != null && pacient.Name != null && pacient.Otech != null
                && pacient.NumSeria != null && pacient.Adress != null && ComboPols.SelectedItem != null
                && DateBorn.SelectedDate != null && pacient.Phone != null && pacient.Card != null
                && DateNext.SelectedDate != null && DateStart.SelectedDate != null && DatePolis.SelectedDate != null)
            {
                if (pacient.Id == 0)
                {
                    App.DB.Pacient.Add(pacient);
                }
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
