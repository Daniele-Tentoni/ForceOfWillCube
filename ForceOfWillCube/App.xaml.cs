namespace ForceOfWillCube
{
    using ForceOfWillCube.Models;
    using ForceOfWillCube.Remotes;
    using ForceOfWillCube.Utils;
    using ForceOfWillCube.Views;
    using System;
    using Xamarin.Forms;

    public partial class App : Application
    {
        private static readonly Lazy<Database> _database =
            new Lazy<Database>();
        public static Database Local => _database.Value;

        private static readonly Lazy<AuthenticatorManager> _authManager =
            new Lazy<AuthenticatorManager>();
        public static AuthenticatorManager AuthenticatorManager => _authManager.Value;

        private static readonly Lazy<RealtimeDatabaseClient> _remote =
            new Lazy<RealtimeDatabaseClient>();
        public static RealtimeDatabaseClient Remote => _remote.Value;

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
            Local.ClearLifecountLogs();
        }

        protected override void OnResume()
        {
        }
    }
}
