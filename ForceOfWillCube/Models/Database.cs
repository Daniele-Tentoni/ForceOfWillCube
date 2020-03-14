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

    public partial class Database
    {
        private const string LOG_TAG = "DATABASE";
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
#if DEBUG
            if (File.Exists(dbPath))
                File.Delete(dbPath);
#endif
            this._database = new SQLiteAsyncConnection(dbPath);
            this._database.CreateTableAsync<FowCard>().Wait();
            this._database.CreateTableAsync<FowCollection>().Wait();
            this._database.CreateTableAsync<CollectionCard>().Wait();
            this._database.CreateTableAsync<FowSet>().Wait();
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
    }
}