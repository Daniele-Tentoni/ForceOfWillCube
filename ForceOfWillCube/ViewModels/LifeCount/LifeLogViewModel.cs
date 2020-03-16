using System.Collections.ObjectModel;
using ForceOfWillCube.Models.Logs;

namespace ForceOfWillCube.ViewModels.LifeCount
{
    public class LifeLogViewModel : BaseViewModel
    {
        private ObservableCollection<LifecountLog> _logs;
        public ObservableCollection<LifecountLog> Logs
        {
            get => this._logs;
            set => this.SetProperty(ref this._logs, value);
        }

        public LifeLogViewModel()
        {
            var logs = App.Local.GetAllLifecountLogs();
            this.Logs = new ObservableCollection<LifecountLog>(logs);
        }
    }
}
