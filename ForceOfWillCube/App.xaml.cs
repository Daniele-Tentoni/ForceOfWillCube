namespace ForceOfWillCube
{
    using ForceOfWillCube.Models;
    using ForceOfWillCube.Utils;
    using ForceOfWillCube.Views;
    using System;
    using System.IO;
    using Xamarin.Forms;

    public partial class App : Application
    {
        private static Database database;
        public static Database Local
        {
            get
            {
                if(database == null)
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "collection.db3"));
                return database;
            }
        }

        private static AuthenticatorManager _authManager;
        public static AuthenticatorManager AuthenticatorManager
        {
            get
            {
                if (_authManager == null)
                    _authManager = new AuthenticatorManager();
                return _authManager;
            }
        }

        public App()
        {
            this.InitializeComponent();

            // TODO: Manage authentication.
            // this.MainPage = new NavigationPage(new MainPage());
            this.MainPage = new DrawerPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
