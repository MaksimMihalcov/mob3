using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Mob3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        private async void ScanQrCode(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () => 
                {
                    await Navigation.PopToRootAsync();
                    var action = await DisplayAlert("Qr code: ", result.Text, "Copy", "Open in Browser");
                    if (action)
                        await Clipboard.SetTextAsync(result.Text);
                    else
                    {
                        try
                        {
                            await Browser.OpenAsync(result.Text, BrowserLaunchMode.SystemPreferred);
                        }
                        catch
                        {
                            await DisplayAlert("Error: ", "Incorrect url format!", "Ok");
                        }
                    }
                });
            };
        }
    }
}