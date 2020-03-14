using System;
using System.Collections.Generic;
using ForceOfWillCube.Utils;
using ForceOfWillCube.ViewModels.CardLists;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.CardLists
{
    public partial class FowSetsView : ContentPage
    {
        private readonly FowSetsViewModel viewModel;
        public FowSetsView()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel =  new FowSetsViewModel();
        }

        protected override void ChangeVisualState()
        {
            base.ChangeVisualState();
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.DisplayAlert(
                    "Alert",
                    "Changed visual state to ...",
                    AppStrings.Bad);
            });
        }
    }
}
