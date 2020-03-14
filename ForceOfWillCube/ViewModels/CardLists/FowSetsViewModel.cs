using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ForceOfWillCube.Models.Sets;
using ForceOfWillCube.Utils;
using Xamarin.Forms;

namespace ForceOfWillCube.ViewModels.CardLists
{
    public class FowSetsViewModel : BaseViewModel
    {
        private ObservableCollection<FowSet> _sets;
        public ObservableCollection<FowSet> Sets
        {
            get => this._sets;
            set => this.SetProperty(ref this._sets, value);
        }

        public Command UpdateSetListCommand { get; set; }

        public FowSetsViewModel()
        {
            this.Title = "Card Database";
            this.UpdateSetListCommand = new Command(() => this.UpdateSetListExecute());
            this.UpdateSetListCommand.Execute(null);
        }

        private void UpdateSetListExecute()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            try
            {
                var sets = App.Local.GetAllFowSets();
                this.Sets = new ObservableCollection<FowSet>(sets);
            }
            catch (Exception e)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Fow Sets",
                                                      "Synchronization failed.",
                                                      AppStrings.Bad);
                    Debug.WriteLine($"Exception throwned: {e.Message}");
                });
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
