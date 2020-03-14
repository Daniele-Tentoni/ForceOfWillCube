using System.Collections.Generic;
using ForceOfWillCube.Models.Collections;
using ForceOfWillCube.Models.Sets;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ForceOfWillCube.Models.Cards
{
    [Table("cards")]
    public class FowCard
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlavourText { get; set; }
        public string EffectText { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        [ForeignKey(typeof(FowSet))]     // Specify the foreign key
        public int SetId { get; set; }

        [ManyToOne]
        public FowSet Set { get; set; }

        [ManyToMany(typeof(CollectionCard))]
        public List<FowCollection> Collections { get; set; }
    }
}
