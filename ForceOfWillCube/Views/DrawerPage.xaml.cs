namespace ForceOfWillCube.Views
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawerPage : MasterDetailPage
    {
        public DrawerPage()
        {
            this.InitializeComponent();
            this.MasterPage.ListView.ItemSelected += this.ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is DrawerPageMasterMenuItem item))
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            this.Detail = new NavigationPage(page);
            this.IsPresented = false;

            this.MasterPage.ListView.SelectedItem = null;
        }
    }
}