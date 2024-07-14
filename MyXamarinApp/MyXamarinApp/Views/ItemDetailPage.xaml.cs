using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}