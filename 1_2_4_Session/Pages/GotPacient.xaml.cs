using _1_2_4_Session.Models;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для GotPacient.xaml
    /// </summary>
    public partial class GotPacient : Page
    {
        public GotPacient()
        {
            InitializeComponent();
        }

        private void GotPac_Click(object sender, RoutedEventArgs e)
        {
            Pacient pacient = App.DB.Pacient.FirstOrDefault(x => x.Id.ToString() == PacId.Text);
            if (pacient != null)
            {
                NavigationService.Navigate(new RegPacient(pacient));
            }
            else
            {
                MessageBox.Show("Данный пациент не найден");
            }
        }

        private void GotQr_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter=".png; | *.png;"};
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var imageBytes = File.ReadAllBytes(dialog.FileName);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    var imageBitmap = new BitmapImage();
                    imageBitmap.BeginInit();
                    imageBitmap.StreamSource = ms;
                    imageBitmap.CacheOption = BitmapCacheOption.OnLoad;
                    imageBitmap.EndInit();

                    using (MemoryStream mss = new MemoryStream(imageBytes))
                    {
                        var bitmap = new Bitmap(ms);
                        QRCodeDecoder decoder = new QRCodeDecoder();
                        string id = decoder.Decode(new QRCodeBitmapImage(bitmap));
                        Pacient pacient = App.DB.Pacient.FirstOrDefault(x => x.Id.ToString() == id);
                        if (pacient != null)
                        {
                            NavigationService.Navigate(new RegPacient(pacient));
                        }
                        else
                        {
                            MessageBox.Show("Данный пациент не найден");
                        }
                    }
                }
            }
        }
    }
}
