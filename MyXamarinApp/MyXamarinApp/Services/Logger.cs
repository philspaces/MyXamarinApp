namespace MyXamarinApp.Services
{
    public static class Logger
    {
        public static void Log(string message)
        {
            // Simple console logging
            System.Diagnostics.Debug.WriteLine($"LOG: {message}");

            // Optionally, log to Xamarin Essentials (AppCenter, etc.)
            // For this, you need to configure and use AppCenter or another service.
        }
    }
}