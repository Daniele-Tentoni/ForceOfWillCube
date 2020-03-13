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

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// This is the list of all card of the set.
        /// </summary>
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FowCard> Cards { get; set; }

        public FowSet()
        {
        }
    }
}
