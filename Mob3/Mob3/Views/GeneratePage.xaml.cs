using QRCoder;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mob3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneratePage : ContentPage
    {
        public GeneratePage()
        {
            InitializeComponent();
        }

        private async void GenerateQrCode(object sender, EventArgs e)
        {
            if (qrText.Text == null || qrText.Text.Length == 0)
            {
                await DisplayAlert("Error: ", "Text is empty!", "Ok");
                return;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText.Text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            qrImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }
    }
}