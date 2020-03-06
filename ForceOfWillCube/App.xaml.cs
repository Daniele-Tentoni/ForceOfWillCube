namespace ForceOfWillCube
{
    using ForceOfWillCube.Models;
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

        public App()
        {
            this.InitializeComponent();

            // TODO: Manage authentication.
            this.MainPage = new NavigationPage(new MainPage());
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
