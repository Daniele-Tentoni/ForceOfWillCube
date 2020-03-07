namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms.Internals;

    public partial class Database
    {
        #region Create

        public async Task<FowCollection> InsertCollectionAsync(FowCollection collection)
        {
            await this._database.InsertAsync(collection, typeof(FowCollection));
            return this._database.Table<FowCollection>().ToListAsync().Result.Last();
        }

        #endregion

        #region Read

        public Task<List<FowCollection>> GetAllCollections() =>
            this._database.Table<FowCollection>().ToListAsync();

        public async Task<FowCollection> GetCollectionByIdAsync(int collectionId) =>
            await this._database.FindAsync<FowCollection>(collectionId);

        #endregion

        #region Update

        public async Task<int> AddCardToCollectionByIdAsync(int collectionId, int cardId)
        {
            var collection = await this.GetCollectionByIdAsync(collectionId);
            // collection.Cards.Add(await this.GetCardByIdAsync(cardId));
            return await this._database.UpdateAsync(collection, typeof(FowCollection));
        }

        public async Task<int> RemoveCardFromCollectionByIdAsync(int collectionId, int cardId)
        {
            var collection = await this.GetCollectionByIdAsync(collectionId);
            // collection.Cards.Remove(await this.GetCardByIdAsync(cardId));
            return await this._database.UpdateAsync(collection, typeof(FowCollection));
        }

        #endregion

        #region Delete

        public async Task<int> DeleteCollectionById(int collectionId) =>
            await this._database.DeleteAsync<FowCollection>(collectionId);

        #endregion
    }
}
