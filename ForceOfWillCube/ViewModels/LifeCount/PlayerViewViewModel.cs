using System;
using Xamarin.Forms;

namespace ForceOfWillCube.ViewModels.LifeCount
{
    public class PlayerViewViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => this._name;
            set => this.SetProperty(ref this._name, value);
        }

        public int _lifepoints;
        public int Lifepoints
        {
            get => this._lifepoints;
            set => this.SetProperty(ref this._lifepoints, value);
        }

        private int _counters;
        public int Counters
        {
            get => this._counters;
            set
            {
                if (value < 0)
                    return;
                this.SetProperty(ref this._counters, value);
            }
        }

        private int _randomized;
        public int Randomized
        {
            get => this._randomized;
            set => this.SetProperty(ref this._randomized, value);
        }

        // Commands to manipulate results.
        public Command IncrementLifePointsBy100 { get; }
        public Command DecrementLifePointsBy100 { get; }
        public Command IncrementLifePointsBy500 { get; }
        public Command DecrementLifePointsBy500 { get; }
        public Command IncrementCounters { get; }
        public Command DecrementCounters { get; }
        public Command Randomize { get; }

        public PlayerViewViewModel(string name)
        {
            this.Title = name;
            this.Name = name;
            this.Reset();
            this.IncrementLifePointsBy100 = new Command(
                () => this.ExecuteModifyLifePoints(100),
                () => !this.IsBusy);
            this.DecrementLifePointsBy100 = new Command(
                () => this.ExecuteModifyLifePoints(-100),
                () => !this.IsBusy);
            this.IncrementLifePointsBy500 = new Command(
                () => this.ExecuteModifyLifePoints(500),
                () => !this.IsBusy);
            this.DecrementLifePointsBy500 = new Command(
                () => this.ExecuteModifyLifePoints(-500),
                () => !this.IsBusy);
            this.IncrementCounters = new Command(
                () => this.ExecuteModifyCounters(1),
                () => !this.IsBusy);
            this.DecrementCounters = new Command(
                () => this.ExecuteModifyCounters(-1),
                () => !this.IsBusy);
            this.Randomize = new Command(
                () => this.ExecuteRandomize(),
                () => !this.IsBusy);
        }

        public void Reset()
        {
            this.Lifepoints = 4000;
            this.Counters = 0;
            this.Randomized = 0;
        }

        private void ExecuteModifyLifePoints(int modification = 1)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            var old = this.Lifepoints;
            this.Lifepoints += modification;
            this.ComposeLog("Lifepoints", old, this.Lifepoints);

            this.IsBusy = false;
        }

        private void ExecuteModifyCounters(int modification = 1)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            var old = this.Counters;
            this.Counters += modification;
            this.ComposeLog("Counters", old, this.Counters);

            this.IsBusy = false;
        }

        private void ExecuteRandomize()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            Random r = new Random(DateTime.Now.Millisecond);
            var times = r.Next(1, 10);
            for(int i = 0; i < times; i++)
            {
                this.Randomized = r.Next(1, 20);
            }

            this.IsBusy = false;
        }

        private void ComposeLog(string element, int from, int to) =>
            App.Local.InsertLifecountLog(this.Name, element, from, to);
    }
}
