namespace App1.ViewModels {
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel : BaseViewModel {
        public string SearchText { get; set; }
        
        public ICommand QrButtonCommand { get; set; }

        public MainViewModel() {
            QrButtonCommand = new Command(QrButtonCommandAction);

        }

        private async void QrButtonCommandAction() {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
                SearchText = result != null ? result.Text : string.Empty;
        }
    }
}