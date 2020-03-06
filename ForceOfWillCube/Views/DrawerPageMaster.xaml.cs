using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForceOfWillCube.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawerPageMaster : ContentPage
    {
        public ListView ListView;

        public DrawerPageMaster()
        {
            InitializeComponent();

            BindingContext = new DrawerPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DrawerPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DrawerPageMasterMenuItem> MenuItems { get; set; }

            public DrawerPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DrawerPageMasterMenuItem>(new[]
                {
                    new DrawerPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new DrawerPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new DrawerPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new DrawerPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new DrawerPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}