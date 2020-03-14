using System;
using System.Collections.Generic;
using ForceOfWillCube.Models.Cards;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ForceOfWillCube.Models.Sets
{
    [Table("sets")]
    public class FowSet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(63)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// This is the list of all card of the set.
        /// </summary>
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FowCard> Cards { get; set; }

        [Ignore]
        public long CardsInCount
        {
            get
            {
                if (Cards != null && Cards.Count > 0)
                    return Cards.Count;
                return 0;
            }
        }
    }
}
