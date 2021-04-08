namespace App1.Views {
    using System;
    using ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage {
        public MainPage() { InitializeComponent(); }

        private async void Button_OnClicked(object sender, EventArgs e) {
            var secondPage = new TrackingPage {
                                                  BindingContext = new TrackingViewModel(SearchBar.Text)
                                              };
            await Navigation.PushModalAsync(secondPage);
        }
    }
}