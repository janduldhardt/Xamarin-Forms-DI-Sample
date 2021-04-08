namespace App1.ViewModels {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Api;
    using Models;
    using Xamarin.Forms;

    public class TrackingViewModel : BaseViewModel {

        private readonly IRestService _MyRestService;

        public string ImageSource { get; set; }

        public string CropName { get; set; }

        public bool IsBusy { get; set; }

        public ObservableCollection<Root> TrackingInfos { get; set; }

        public string ProductCode { get; set; }

        public ICommand TestButtonCommand { get; set; }


        public TrackingViewModel(IRestService myRestService) {
            IsBusy = true;
            _MyRestService = myRestService;
            TestButtonCommand = new Command(TestButtonCommandAction);
            InitializeData();
        }

        private void TestButtonCommandAction(object obj) {
            
        }

        public TrackingViewModel() {}

        public void InitializeData() {
            var trackingInfoRoot = _MyRestService.RefreshData(ProductCode);
            var sortedTrackingInfo = trackingInfoRoot.OrderByDescending(x => x.Record.timestamp);
            TrackingInfos = new ObservableCollection<Root>(sortedTrackingInfo);
            ImageSource = trackingInfoRoot.FirstOrDefault()?.Record.imgUrl;
            CropName = trackingInfoRoot.FirstOrDefault()?.Record.cropName;
            IsBusy = false;
        }
    }
}