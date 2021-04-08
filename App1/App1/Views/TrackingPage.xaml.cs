using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views {
    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackingPage : ContentPage {
        public TrackingPage() {
            InitializeComponent();
        }
    }
}