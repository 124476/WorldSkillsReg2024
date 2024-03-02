using _1_2_4_Session.Models;
using MessagingToolkit.QRCode.Codec;
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
using System.Windows.Shapes;

namespace _1_2_4_Session.Windows
{
    /// <summary>
    /// Логика взаимодействия для QtOkno.xaml
    /// </summary>
    public partial class QtOkno : Window
    {
        public QtOkno(Pacient pacient)
        {
            InitializeComponent();
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap bitmap = encoder.Encode(pacient.Id.ToString());
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Position = 0;

                var imageBitmap = new BitmapImage();
                imageBitmap.BeginInit();
                imageBitmap.StreamSource = ms;
                imageBitmap.CacheOption = BitmapCacheOption.OnLoad;
                imageBitmap.EndInit();

                QrI.Source = imageBitmap;
            }
        }

        private void SaveQr_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog() { Filter = ".png; | *.png;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var file = File.Create(dialog.FileName);
                file.Close();

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                BitmapSource bitmapSource = (BitmapSource)QrI.Source;
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    File.WriteAllBytes(dialog.FileName, ms.ToArray());
                }
            }
        }
    }
}
