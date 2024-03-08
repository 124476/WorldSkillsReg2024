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
            DataZapis.ItemsSource = App.DB.Zapiska.ToList();
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

        private void Refrash()
        {
            DataZapis.ItemsSource = App.DB.Zapiska.ToList();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedackZapiska(new Zapiska()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrash();
        }
    }
}
