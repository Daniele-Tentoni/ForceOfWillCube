namespace ForceOfWillCube.ViewModels.MainPage
{
    using ForceOfWillCube.Models.Collections;
    using ForceOfWillCube.Utils;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<FowCollection> _collections;
        public ObservableCollection<FowCollection> Collections
        {
            get => this._collections;
            set => this.SetProperty(ref this._collections, value);
        }

        private string _username;
        public string Username
        {
            get => this._username;
            set => this.SetProperty(ref this._username, value);
        }

        public Command SwithUserCommand { get; set; }
        public Command AddCollectionToolbarCommand { get; set; }
        public Command DeleteCollectionCommand { get; set; }

        public MainPageViewModel()
        {
            this.Title = AppStrings.MainPageTitle;
            this.UpdateCollections();
            this.Username = DependencyService.Get<IAuthenticatorManager>().GetSignedUser().Username;
            this.SwithUserCommand = new Command(() => this.SwitchUser());
            this.AddCollectionToolbarCommand = new Command(() => this.CreateCollectionModal());
            this.DeleteCollectionCommand = new Command(itemId => this.ExcecuteDeleteCollectionCommandAsync((FowCollection)itemId));

            MessagingCenter.Subscribe<MainPageViewModel, string>(this, "Hello", (obj, item) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Log.Warning("HOME", "MESSAGE");
                });
            });
        }

        private void SwitchUser()
        {
            var authManager = DependencyService.Get<IAuthenticatorManager>();
            var signedUser = authManager.GetSignedUser();
            if (signedUser != null && signedUser.IsLogged)
            {
                authManager.SignoutUser();
                this.Username = "Guest User";
            }
            else
            {
                authManager.SigninUser("Tento");
                this.Username = authManager.GetSignedUser().Username;
            }
        }

        private async void UpdateCollections()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            try
            {
                var collections = await App.Local.GetAllCollections();
                this.Collections = new ObservableCollection<FowCollection>(collections);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private async void CreateCollectionModal()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            string name = string.Empty;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                name = await Application.Current.MainPage.DisplayPromptAsync("New collection",
                                                                             "Input the name of the new collection",
                                                                             "Ok",
                                                                             "Cancel",
                                                                             "Name",
                                                                             -1,
                                                                             Keyboard.Text,
                                                                             string.Empty);
            });
            var res = await App.Local.InsertCollectionAsync(new FowCollection { Name = name ?? "New collection", UserId = 1 });
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(
                    "New Collection", res == 1 ? "Well done, good job." : "Bad done, bad job.", res == 1 ? "Great!" : "Bad!");
            });

            this.IsBusy = false;
            this.UpdateCollections();
        }

        private async void ExcecuteDeleteCollectionCommandAsync(FowCollection collectionId)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            var res = await App.Local.DeleteCollectionById(collectionId.Id);
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Delete collection",
                    res == 1 ? "You have correctly deleted the collection." : "Bad done, bad job.",
                    res == 1 ? "Great!" : "Bad!");
            });

            this.IsBusy = false;
            this.UpdateCollections();
        }
    }
}