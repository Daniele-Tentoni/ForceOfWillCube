using System.Collections.Generic;
using System.Threading.Tasks;
using ForceOfWillCube.Models.Sets;

namespace ForceOfWillCube.Models
{
    public partial class Database
    {
        #region Create

        public Task<int> InsertSetAsync(FowSet set) =>
            this._database.InsertAsync(set);

        #endregion

        #region Read

        public IEnumerable<FowSet> GetAllFowSets() =>
            this._database.Table<FowSet>().ToListAsync().Result;

        public async Task<FowSet> GetSetById(int setId) =>
            await this._database.FindAsync<FowSet>(setId);

        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
