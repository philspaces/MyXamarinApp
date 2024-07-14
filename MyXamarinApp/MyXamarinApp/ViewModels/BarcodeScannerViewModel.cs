using MyXamarinApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using ZXing;

namespace MyXamarinApp.ViewModels
{
    public class BarcodeScannerViewModel : BaseViewModel
    {
        private bool isScanning;
        private bool isAnalyzing;
        private bool isTorchOn;
        private string scannedResult;

        public bool IsScanning
        {
            get => isScanning;
            set
            {
                SetProperty(ref isScanning, value);
            }
        }
        public bool IsAnalyzing
        {
            get => isAnalyzing;
            set
            {
                SetProperty(ref isAnalyzing, value);
            }
        }
        public bool IsTorchOn
        {
            get => isTorchOn;
            set
            {
                SetProperty(ref isTorchOn, value);
            }
        }
        public string ScannedResult
        {
            get => scannedResult;
            set
            {
                SetProperty(ref scannedResult, value);
            }
        }

        public Command StartScanningCommand { get; }
        public Command StopScanningCommand { get; }
        public Command CancelScanningCommand { get; }
        public Command ToggleTorchCommand { get; }


        public BarcodeScannerViewModel()
        {
            Title = "Barcode scanner";
            StartScanningCommand = new Command(StartScanning);
            StopScanningCommand = new Command(StopScanning);
            CancelScanningCommand = new Command(CancelScanning);
            ToggleTorchCommand = new Command(ToggleTorch);
        }

        public string OnScannedResult(Result result)
        {
            IsAnalyzing = false;
            ScannedResult = result.Text;
            Logger.Log("OnScannedResult: " + result.ToString());
            // Parse the result (assuming JSON format)
            var scannedData = JsonConvert.DeserializeObject(result.Text);
            Logger.Log("OnScannedResult(JSON): " + scannedData.ToString());

            return ScannedResult;
        }

        private void ToggleTorch()
        {
            IsTorchOn = !IsTorchOn;
        }

        private async void CancelScanning()
        {
            // TODO: Logic to navigate back

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void StopScanning()
        {
            IsScanning = false;
            IsAnalyzing = false;
        }

        private void StartScanning()
        {
            IsScanning = true;
            IsAnalyzing = true;
        }
    }
}