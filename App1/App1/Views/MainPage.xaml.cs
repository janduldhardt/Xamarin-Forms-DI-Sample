namespace App1.Views {
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage {
        public MainPage() { InitializeComponent(); }

        private async void Button_OnClicked(object sender, EventArgs e) {
            var vm = Startup.ServiceProvider.GetService<TrackingViewModel>();
            vm.ProductCode = SearchBar.Text;
            // vm?.InitializeData(SearchBar?.Text);
            var secondPage = new TrackingPage {
                                                  BindingContext = vm
                                              };

            await Navigation.PushModalAsync(secondPage);
        }

        private async void QrButton_OnClicked(object sender, EventArgs e) {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            // scanner.UseCustomOverlay = true;
            var result = await scanner.Scan();
            SearchBar.Text = result?.Text;
        }
    }
}