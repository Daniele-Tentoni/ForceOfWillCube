using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.LifeCount
{
    public class LogChangesPage : ContentPage
    {
        private ObservableCollection<string> _logs;
        public ObservableCollection<string> Logs
        {
            get => this._logs;
            set => this._logs = value;
        }

        public LogChangesPage()
        {
            var logs = App.Local.GetAllLifecountLogs();
            this.Logs = new ObservableCollection<string>(logs);
            Content = new StackLayout
            {
                Children = {
                    new CollectionView
                    {
                        ItemsSource = this.Logs
                    }
                }
            };
        }
    }
}

