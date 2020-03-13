namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Cards;
    using ForceOfWillCube.Models.Collections;
    using ForceOfWillCube.Models.Sets;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms.Internals;
    using SQLiteNetExtensionsAsync;
    using SQLiteNetExtensionsAsync.Extensions;

    public partial class Database
    {
        private const string LOG_TAG = "DATABASE";
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            this._database = new SQLiteAsyncConnection(dbPath);
            this._database.CreateTableAsync<FowCard>().Wait();
            this._database.CreateTableAsync<FowCollection>().Wait();

#if DEBUG
            if (this._database.Table<FowCard>().CountAsync().Result <= 0)
            {
                Log.Warning(LOG_TAG, "A new database need to be generated.");
                var g1 = new FowSet
                {
                    Name = "Grimm Cluster First Set",
                    ReleaseDate = DateTime.Now
                };
                _ = this.InsertSetAsync(g1);
                var g2 = new FowSet
                {
                    Name = "Grimm Cluster Second Set",
                    ReleaseDate = DateTime.Now
                };
                _ = this.InsertSetAsync(g2);
                var card1 = new FowCard
                {
                    Name = "First Card",
                    EffectText = "This card haven't any effect.",
                    FlavourText = "Legends says that is was the first card added in the database."
                };
                _ = this.InsertCardAsync(card1);
                var card2 = new FowCard
                {
                    Name = "Second Card",
                    EffectText = "This card haven't any effect.",
                    FlavourText = "Legends says that is was the second card added in the database."
                };
                _ = this.InsertCardAsync(card2);

                // Associate set with cards.
                g1.Cards = new List<FowCard> { card1 };
                _database.UpdateWithChildrenAsync(card1);
                if (card1.Set == g1)
                {
                    Log.Warning(LOG_TAG, "Inverse relationship already set, yay!");
                }

                // Get the object and the relationships.
                var storedValuation = _database.GetAllWithChildrenAsync<FowCard>().Result;
                //if (dollar.Symbol.Equals(storedValuation.Stock.Symbol))
                //{
                //    Debug.WriteLine("Object and relationships loaded correctly!");
                //}

                var coll1 = new FowCollection
                {
                    Name = "First Collection",
                    UserId = 1,
                    CreationDate = DateTime.Now
                };
                _ = this.InsertCollectionAsync(coll1);
                coll1.Cards = new List<FowCard> { card1 };
                _database.UpdateWithChildrenAsync(coll1);

                var coll2 = new FowCollection
                {
                    Name = "Second Collection",
                    UserId = 1,
                    CreationDate = DateTime.Now
                };
                _ = this.InsertCollectionAsync(coll2);
                coll2.Cards = new List<FowCard> { card2 };
                _database.UpdateWithChildrenAsync(coll2);

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