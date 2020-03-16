namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Cards;
    using ForceOfWillCube.Models.Collections;
    using ForceOfWillCube.Models.Sets;
    using SQLite;
    using Xamarin.Forms.Internals;
    using SQLiteNetExtensionsAsync.Extensions;
    using System.IO;
    using ForceOfWillCube.Remotes;
    using System;
    using ForceOfWillCube.Models.Logs;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Database
    {
        private const string LOG_TAG = "DATABASE";
        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "collection.db3");
        private readonly SQLiteAsyncConnection _database;

        public Database()
        {
#if DEBUG
            // Reset the database only in debug compilation mode.
            if (File.Exists(dbPath))
                File.Delete(dbPath);
#endif
            this._database = new SQLiteAsyncConnection(dbPath);
            this._database.CreateTableAsync<FowCard>().Wait();
            this._database.CreateTableAsync<FowCollection>().Wait();
            this._database.CreateTableAsync<CollectionCard>().Wait();
            this._database.CreateTableAsync<FowSet>().Wait();
            this._database.CreateTableAsync<LifecountLog>().Wait();
#if DEBUG
            if (this._database.Table<FowCard>().CountAsync().Result <= 0)
            {
                Log.Warning(LOG_TAG, "A new database need to be generated.");
                RealtimeDatabaseClient client = new RealtimeDatabaseClient();
                var sets = client.GetAllSetsAsync();
                _database.InsertOrReplaceAllWithChildrenAsync(sets);
                Log.Warning(LOG_TAG, "Database generation completed.");
            }
            else
            {
                Log.Warning(LOG_TAG, "No database generation needed.");
            }
#else
            Log.Warning(LOG_TAG, "No database generation.");
#endif
        }

        public int InsertLifecountLog(string player, string obj, int from, int to) =>
            this._database.InsertAsync(
                new LifecountLog
                {
                    Name = player,
                    Object = obj,
                    From = from,
                    To = to,
                    Registration = DateTime.Now
                })
            .Result;

        public IEnumerable<LifecountLog> GetAllLifecountLogs() =>
            this._database.GetAllWithChildrenAsync<LifecountLog>().Result
            .OrderByDescending(o => o.Registration);

        public void ClearLifecountLogs() =>
            this.GetAllLifecountLogs().ForEach(elem =>
            {
                this._database.DeleteAsync(elem);
            });

    }
}