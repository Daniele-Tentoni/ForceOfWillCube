namespace ForceOfWillCube.Views
{
    using ForceOfWillCube.Utils;
    using ForceOfWillCube.ViewModels;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawerPageMaster : ContentPage
    {
        public ListView ListView;

        public DrawerPageMaster()
        {
            this.InitializeComponent();

            this.BindingContext = new DrawerPageMasterViewModel();
            this.ListView = this.MenuItemsListView;
        }

        class DrawerPageMasterViewModel : BaseViewModel
        {
            private const string LOG_TAG = "MENU";
            public string Username => App.AuthenticatorManager.SignedUser.Username;

            private ObservableCollection<DrawerPageMasterMenuItem> _menuitems;
            public ObservableCollection<DrawerPageMasterMenuItem> MenuItems
            {
                get => new ObservableCollection<DrawerPageMasterMenuItem>(
                    this._menuitems.Where(o => o.IsVisible)
                    );
                set => this.SetProperty(ref this._menuitems, value);
            }

            public DrawerPageMasterViewModel()
            {
                this.MenuItems = new ObservableCollection<DrawerPageMasterMenuItem>(new[]
                {
                    new DrawerPageMasterMenuItem { Id = 0, Title = "Collections", TargetType = typeof(MainPage), IsVisible = true },
                    new DrawerPageMasterMenuItem { Id = 1, Title = "Sign in", TargetType = typeof(LoginPage), IsVisible = true },
                    new DrawerPageMasterMenuItem { Id = 2, Title = "Sign up", TargetType = typeof(DrawerPageDetail), IsVisible = true },
                    new DrawerPageMasterMenuItem { Id = 3, Title = "Account", TargetType = typeof(DrawerPageDetail), IsVisible = false },
                    new DrawerPageMasterMenuItem { Id = 4, Title = "Sign out", TargetType = typeof(DrawerPageDetail), IsVisible = false },
                    new DrawerPageMasterMenuItem { Id = 5, Title = "About", TargetType = typeof(DrawerPageDetail), IsVisible = true }
                });

                this.SubsribeForMessages();
            }

            /// <summary>
            /// Subscribe for messages from authenticator manager.
            /// </summary>
            public void SubsribeForMessages()
            {
                MessagingCenter.Subscribe<AuthenticatorManager>(this, AppStrings.USER_SIGN_IN, manager => this.SetItemVisibiltyForSignIn());
                MessagingCenter.Subscribe<AuthenticatorManager>(this, AppStrings.USER_SIGN_OUT, manager => this.SetItemVisibiltyForSignOut());
                MessagingCenter.Subscribe<AuthenticatorManager>(this, AppStrings.USER_NOT_SIGN_IN, manager => this.SetItemVisibiltyForSignOut());
                MessagingCenter.Subscribe<AuthenticatorManager>(this, AppStrings.USER_NOT_SIGN_OUT, manager => this.SetItemVisibiltyForSignIn());
            }

            /// <summary>
            /// Set menu items for sign in, show sign out and hide sign in.
            /// </summary>
            public void SetItemVisibiltyForSignIn()
            {
                this.SetItemVisibility(1, false);
                this.SetItemVisibility(2, false);
                this.SetItemVisibility(3, true);
                this.SetItemVisibility(4, true);
                this.OnPropertyChanged(nameof(this.MenuItems));
            }

            /// <summary>
            /// Set menu items for sign out, show sign in and hide sign out.
            /// </summary>
            public void SetItemVisibiltyForSignOut()
            {
                this.SetItemVisibility(1, true);
                this.SetItemVisibility(2, true);
                this.SetItemVisibility(3, false);
                this.SetItemVisibility(4, false);
                this.OnPropertyChanged(nameof(this.MenuItems));
            }

            /// <summary>
            /// Set visibilty property for a single menu item.
            /// You have to call propery changed event to see this work.
            /// </summary>
            /// <param name="id">Id of the menu item.</param>
            /// <param name="isVisible">Value of the property visibility.</param>
            public void SetItemVisibility(int id, bool isVisible)
            {
                var menuItem = this._menuitems.FirstOrDefault(f => f.Id == id);
                menuItem.IsVisible = isVisible;
                Log.Warning(LOG_TAG, $"Changed {menuItem.Title} visibility to {menuItem.IsVisible}");
            }
        }
    }
}