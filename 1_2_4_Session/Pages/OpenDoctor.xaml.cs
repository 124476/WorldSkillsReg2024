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
    /// Логика взаимодействия для OpenDoctor.xaml
    /// </summary>
    public partial class OpenDoctor : Page
    {
        public OpenDoctor()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = App.DB.Doctor.FirstOrDefault(x => x.Surname == DoctorText.Text);
            if (doctor != null)
            {
                if (doctor.OtdelId == 10)
                {
                    NavigationService.Navigate(new OknoAdmin());
                }
                else
                {
                    if (doctor.OtdelId == 11)
                    {
                        NavigationService.Navigate(new OknoRegister());
                    }
                    else
                    {
                        if (doctor.OtdelId == 12)
                        {
                            NavigationService.Navigate(new OknoGlav());
                        }
                        else
                        {
                            NavigationService.Navigate(new OknoDoctor());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Данный доктор не найден!");
            }
        }
    }
}
