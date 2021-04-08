namespace App1.Views {
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage {
        public MainPage() { InitializeComponent(); }

        private async void Button_OnClicked(object sender, EventArgs e) {
            LoadingSpinner.IsVisible = true;
            ErrorLabel.IsVisible = false;
            var vm = Startup.ServiceProvider.GetService<TrackingViewModel>();
            vm.ProductCode = SearchBar.Text;
            // Task.Run(
            //     async () => {
            await vm.InitializeData();
            LoadingSpinner.IsVisible = false;
            if (!vm.TrackingInfos.Any()) {
                ErrorLabel.IsVisible = true;
                
                return;
            }
            var secondPage = new TrackingPage {
                                                  BindingContext = vm
                                              };

            await Navigation.PushModalAsync(secondPage);
            // });
        }

        private async void QrButton_OnClicked(object sender, EventArgs e) {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            // scanner.UseCustomOverlay = true;
            var result = await scanner.Scan();
            SearchBar.Text = result?.Text;
        }
    }
}