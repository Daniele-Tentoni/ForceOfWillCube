using ForceOfWillCube.Models.Sets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForceOfWillCube.Models
{
    /// <summary>
    /// The Database partial class for clusters.
    /// </summary>
    public partial class Database
    {
        #region Create

        public Task<int> InsertClusterAsync(FowCluster cluster) =>
            this._database.InsertAsync(cluster);

        #endregion

        #region Read

        public IEnumerable<FowCluster> GetAllClusters() =>
            this._database.Table<FowCluster>().ToListAsync().Result;

        public async Task<FowCluster> GetClusterById(int clusterId) =>
            await this._database.FindAsync<FowCluster>(clusterId);

        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
