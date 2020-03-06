namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Cards;
    using ForceOfWillCube.Models.Collections;
    using SQLite;
    using System;
    using Xamarin.Forms.Internals;

    public partial class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            this._database = new SQLiteAsyncConnection(dbPath);
            this._database.CreateTableAsync<FowCard>().Wait();
            this._database.CreateTableAsync<FowCollection>().Wait();

#if DEBUG
            if(this._database.Table<FowCard>().CountAsync().Result <= 0)
            {
                var card1 = new FowCard { 
                    Name = "First Card", 
                    EffectText = "This card haven't any effect.", 
                    FlavourText = "Legends says that is was the first card added in the database." };
                var card2 = new FowCard { 
                    Name = "Second Card", 
                    EffectText = "This card haven't any effect.", 
                    FlavourText = "Legends says that is was the second card added in the database." };
                var res = this.InsertCardAsync(card1);
                res = this.InsertCardAsync(card2);
                var coll1 = new FowCollection
                {
                    Name = "First Collection",
                    UserId = 1,
                    CreationDate = DateTime.Now
                };
                var coll2 = new FowCollection
                {
                    Name = "Second Collection",
                    UserId = 1,
                    CreationDate = DateTime.Now
                };
                res = this.InsertCollectionAsync(coll1);
                res = this.InsertCollectionAsync(coll2);
            }
            Log.Warning("DATABASE", "Database generation completed.");
#else
            Log.Warning("DATABASE", "No database generation.");
#endif
        }
    }
}
