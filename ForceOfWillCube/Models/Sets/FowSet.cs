namespace ForceOfWillCube.Models.Sets
{
    using System;
    using System.Collections.Generic;
    using ForceOfWillCube.Models.Cards;
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    /// <summary>
    /// A single expansion set of a cluster.
    /// </summary>
    [Table("sets")]
    public class FowSet
    {
        /// <summary>
        /// The local id. This is not the remote id.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        [MaxLength(63)]
        public string Name { get; set; }

        /// <summary>
        /// The date when the set was released.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// This is the list of all card of the set.
        /// </summary>
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FowCard> Cards { get; set; }

        /// <summary>
        /// The long number of cards in.
        /// Use this for MVVM Data Binding.
        /// </summary>
        [Ignore]
        public long CardsInCount => this.Cards != null && this.Cards.Count > 0 ? this.Cards.Count : 0;

        /// <summary>
        /// The id of the cluster.
        /// </summary>
        [ForeignKey(typeof(FowCluster))]
        public int ClusterId { get; set; }

        /// <summary>
        /// The cluster of this set.
        /// </summary>
        [ManyToOne]
        public FowCluster Cluster { get; set; }
    }
}
