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
            this.Lifepoints = 4000; // Restore previous values if exists.
            this.Counters = 0;
            this.Randomized = 0;
            this.IncrementLifePointsBy100 = new Command(
                () => this.ExecuteIncrementLifePoints(100),
                () => !this.IsBusy);
            this.DecrementLifePointsBy100 = new Command(
                () => this.ExecuteDecrementLifePoints(100),
                () => !this.IsBusy);
            this.IncrementLifePointsBy500 = new Command(
                () => this.ExecuteIncrementLifePoints(500),
                () => !this.IsBusy);
            this.DecrementLifePointsBy500 = new Command(
                () => this.ExecuteDecrementLifePoints(500),
                () => !this.IsBusy);
            this.IncrementCounters = new Command(
                () => this.ExecuteIncrementCounters(),
                () => !this.IsBusy);
            this.DecrementCounters = new Command(
                () => this.ExecuteDecrementCounters(),
                () => !this.IsBusy);
            this.Randomize = new Command(
                () => this.ExecuteRandomize(),
                () => !this.IsBusy);
        }

        private void ExecuteIncrementLifePoints(int increment = 100)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            this.Lifepoints += increment;
            this.ComposeLog("Lifepoints", "incremented", increment);

            this.IsBusy = false;
        }

        private void ExecuteDecrementLifePoints(int decrement = 100)
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            this.Lifepoints -= decrement;
            this.ComposeLog("Lifepoints", "decremented", decrement);

            this.IsBusy = false;
        }

        private void ExecuteIncrementCounters()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            this.Counters++;
            this.ComposeLog("Counters", "incremented", 1);

            this.IsBusy = false;
        }

        private void ExecuteDecrementCounters()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            this.Counters--;
            this.ComposeLog("Counters", "decremented", 1);

            this.IsBusy = false;
        }

        private void ExecuteRandomize()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            Random r = new Random(DateTime.Now.Millisecond);
            this.Randomized = r.Next(1, 20);

            this.IsBusy = false;
        }

        private void ComposeLog(string element, string operation, int change)
        {
            var logString = $"{this.Name}'s {element} {operation} by {change}";
            App.Local.InsertLifecountLog(logString);
        }
    }
}
