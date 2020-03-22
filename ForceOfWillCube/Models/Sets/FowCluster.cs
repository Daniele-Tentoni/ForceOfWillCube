namespace ForceOfWillCube.Models.Sets
{
    using SQLite;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// A single expansion cluster.
    /// </summary>
    [Table("clustes")]
    public class FowCluster
    {
        /// <summary>
        /// The local id. This is not the remote id.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The sets in the cluster.
        /// </summary>
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FowSet> Sets { get; set; }

        /// <summary>
        /// This is the long count of sets in.
        /// Use this for MVVM Data Binding.
        /// </summary>
        [Ignore]
        public long SetsInCount => this.Sets != null && this.Sets.Count > 0 ? this.Sets.Count : 0;
    }
}
