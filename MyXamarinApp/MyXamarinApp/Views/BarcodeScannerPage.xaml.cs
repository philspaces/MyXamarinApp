using MyXamarinApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing;
using ZXing.Net.Mobile.Forms;

namespace MyXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerPage : ContentPage
    {
        BarcodeScannerViewModel _viewModel;

        //ZXingScannerView zxing;
        //ZXingDefaultOverlay overlay;

        public BarcodeScannerPage() : base()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BarcodeScannerViewModel();
        }

        //public BarcodeScannerPage() : base()
        //{
        //    zxing = new ZXingScannerView
        //    {
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //        AutomationId = "zxingScannerView",
        //    };
        //    zxing.OnScanResult += (result) =>
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            // Stop analysis until we navigate away so we don't keep reading barcodes
        //            zxing.IsAnalyzing = false;

        //            // Show an alert
        //            await DisplayAlert("Scanned Barcode", result.Text, "OK");
        //        });

        //    overlay = new ZXingDefaultOverlay
        //    {
        //        TopText = "Hold your phone up to the barcode",
        //        BottomText = "Scanning will happen automatically",
        //        ShowFlashButton = zxing.HasTorch,
        //        AutomationId = "zxingDefaultOverlay",
        //    };
        //    overlay.FlashButtonClicked += (sender, e) =>
        //    {
        //        zxing.IsTorchOn = !zxing.IsTorchOn;
        //    };

        //    var grid = new Grid
        //    {
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //    };

        //    var stopButton = new Button
        //    {
        //        WidthRequest = 100,
        //        HeightRequest = 50,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.End,
        //        Text = "disable",
        //        Command = new Command(() => zxing.IsScanning = false)
        //    };

        //    var cancelButton = new Button
        //    {
        //        WidthRequest = 100,
        //        HeightRequest = 50,
        //        HorizontalOptions = LayoutOptions.Center,
        //        VerticalOptions = LayoutOptions.End,
        //        Text = "cancel",
        //        Command = new Command(async () => await Navigation.PopAsync())
        //    };

        //    var startButton = new Button
        //    {
        //        WidthRequest = 100,
        //        HeightRequest = 50,
        //        HorizontalOptions = LayoutOptions.End,
        //        VerticalOptions = LayoutOptions.End,
        //        Text = "enable",
        //        Command = new Command(() => zxing.IsScanning = true)
        //    };
        //    grid.Children.Add(zxing);
        //    grid.Children.Add(overlay);
        //    grid.Children.Add(startButton);
        //    grid.Children.Add(cancelButton);
        //    grid.Children.Add(stopButton);

        //    // The root page of your application
        //    Content = grid;
        ////}

        private void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string scannedResult = _viewModel.OnScannedResult(result);
                await DisplayAlert("Scanned Barcode", scannedResult, "OK");
            });
        }

        private void OnFlashButtonClicked(object sender, System.EventArgs e)
        {
            _viewModel.ToggleTorchCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            _viewModel.IsScanning = false;

            base.OnDisappearing();
        }
    }
}