using ForceOfWillCube.Models.Cards;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace ForceOfWillCube.Models.Collections
{
    [Table("collections")]
    public class FowCollection
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }

        [ManyToMany(typeof(CollectionCard))]
        public List<FowCard> Cards { get; set; }
    }
}
