using ForceOfWillCube.ViewModels.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.LifeCount
{
    public partial class LifeLogPage : ContentPage
    {
        public LifeLogPage()
        {
            this.BindingContext = new LifeLogViewModel();
            InitializeComponent();
        }
    }
}