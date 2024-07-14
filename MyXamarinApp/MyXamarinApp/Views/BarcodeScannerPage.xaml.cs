using MyXamarinApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing;

namespace MyXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerPage : ContentPage
    {
        BarcodeScannerViewModel _viewModel;

        public BarcodeScannerPage() : base()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BarcodeScannerViewModel();
        }

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