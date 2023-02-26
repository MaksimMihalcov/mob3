using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

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
            var qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Margin = 10;
            qr.BarcodeValue = qrText.Text;
            stackL.Children.Add(qr);
        }
    }
}