namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class Database
    {
        #region Create

        public async Task<int> InsertCollectionAsync(FowCollection collection) =>
            await this._database.InsertAsync(collection, typeof(FowCollection));

        #endregion

        #region Read

        public async Task<List<FowCollection>> GetAllCollections() =>
            await this._database.Table<FowCollection>().ToListAsync();

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
