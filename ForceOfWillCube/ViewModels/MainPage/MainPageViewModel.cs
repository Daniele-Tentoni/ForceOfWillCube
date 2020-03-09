namespace ForceOfWillCube.ViewModels.MainPage
{
    using ForceOfWillCube.Models.Collections;
    using ForceOfWillCube.Utils;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public class MainPageViewModel : BaseViewModel
    {
        private const string LOG_TAG = nameof(MainPageViewModel);
        private ObservableCollection<FowCollection> _collections;
        public ObservableCollection<FowCollection> Collections
        {
            get => this._collections;
            set => this.SetProperty(ref this._collections, value);
        }

        public string Username => App.AuthenticatorManager.SignedUser.Username;
        public int UserId => App.AuthenticatorManager.SignedUser.UserId;

        public Command AddCollectionToolbarCommand { get; set; }
        public Command DeleteCollectionSwipeInvoke { get; set; }

        public MainPageViewModel()
        {
            this.Title = AppStrings.MainPageTitle;
            var collections = App.Local.GetAllCollections().Result;
            this.Collections = new ObservableCollection<FowCollection>(collections);
            this.PropertyChanged += this.CatchPropertyChanged;
            this.AddCollectionToolbarCommand = new Command(() => this.CreateCollectionModal());
            this.DeleteCollectionSwipeInvoke = new Command(itemId => this.ExcecuteDeleteCollectionCommandAsync((FowCollection)itemId));

            MessagingCenter.Subscribe<MainPageViewModel, string>(this, "Hello", (obj, item) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Log.Warning("HOME", "MESSAGE");
                });
            });
        }

        private void CatchPropertyChanged(object sender, PropertyChangedEventArgs e) => Log.Warning("a", "b");

        private async void CreateCollectionModal()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            string name = string.Empty;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                name = await Application.Current.MainPage.DisplayPromptAsync(AppStrings.NewCollection,
                                                                             "Input the name of the new collection",
                                                                             "Ok",
                                                                             "Cancel",
                                                                             "Name",
                                                                             -1,
                                                                             Keyboard.Text,
                                                                             string.Empty);
            });
            var newCollection = new FowCollection { Name = name ?? "New collection", UserId = 1 };
            var collectionAdded = await App.Local.InsertCollectionAsync(newCollection);
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(
                    AppStrings.NewCollection, 
                    collectionAdded != null ? AppStrings.WellDone : AppStrings.BadDone,   
                    collectionAdded != null ? AppStrings.Great : AppStrings.Bad);
            });

            this.Collections.Add(collectionAdded);
            this.IsBusy = false;
        }

        private async void ExcecuteDeleteCollectionCommandAsync(FowCollection collection)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            var res = await App.Local.DeleteCollectionById(collection.Id);
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Delete collection",
                    res == 1 ? "You have correctly deleted the collection." : "Bad done, bad job.",
                    res == 1 ? "Great!" : "Bad!");
            });

            this.Collections.RemoveAt(this.Collections.IndexOf(i => i.Id == collection.Id));
            this.OnPropertyChanged(nameof(this.Collections));
            this.IsBusy = false;
        }
    }
}