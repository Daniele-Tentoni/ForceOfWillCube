namespace ForceOfWillCube.Models
{
    using ForceOfWillCube.Models.Cards;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class Database
    {
        #region Create
        
        public async Task<int> InsertCardAsync(FowCard card) =>
            await this._database.InsertAsync(card);

        #endregion
        
        #region Read
        
        public List<FowCard> GetAllCards() =>
            this._database.Table<FowCard>().ToListAsync().Result;

        public async Task<FowCard> GetCardByIdAsync(int cardId) =>
            await this._database.FindAsync<FowCard>(cardId);

        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
