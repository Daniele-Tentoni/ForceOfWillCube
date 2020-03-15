using ForceOfWillCube.ViewModels.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.LifeCount
{
    public partial class PlayerView : ContentView
    {
        private readonly PlayerViewViewModel viewModel;

        public PlayerView(string name)
        {
            this.BindingContext = this.viewModel = new PlayerViewViewModel(name);
            InitializeComponent();
        }

        public PlayerView() : this("Guest Player") { }
    }
}
