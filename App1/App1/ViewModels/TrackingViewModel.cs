namespace App1.ViewModels {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api;
    using Models;

    public class TrackingViewModel : BaseViewModel{
        public string ProductCode { get; }

        public string ImageSource { get; }

        public string CropName { get; }

        public bool IsBusy { get; set; }

        public List<Root> TrackingInfos { get; set; }


        public TrackingViewModel() { }

        public TrackingViewModel(string productCode) {
            ProductCode = productCode;
            IsBusy = true;
            try {
                List<Root> trackingInfoRoot = RestService.GetTrackingInfoRoot(productCode);
                TrackingInfos = trackingInfoRoot;
                ImageSource = trackingInfoRoot.FirstOrDefault()?.Record.imgUrl;
                CropName = trackingInfoRoot.FirstOrDefault()?.Record.cropName;
            } catch (Exception e) {
                
            } finally {
                IsBusy = false;
            }
        }
    }
}