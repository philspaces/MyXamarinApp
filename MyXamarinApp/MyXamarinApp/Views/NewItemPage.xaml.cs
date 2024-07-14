using MyXamarinApp.Models;
using MyXamarinApp.ViewModels;
using Xamarin.Forms;

namespace MyXamarinApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}