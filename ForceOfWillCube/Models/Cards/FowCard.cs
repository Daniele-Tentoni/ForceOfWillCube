namespace ForceOfWillCube.Models.Cards
{
    using System.Collections.Generic;
    using ForceOfWillCube.Models.Collections;
    using ForceOfWillCube.Models.Sets;
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    [Table("cards")]
    public class FowCard
    {
        /// <summary>
        /// Id inside the db. This is not the set progressive number.
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The flavour text of the card.
        /// </summary>
        public string FlavourText { get; set; }

        /// <summary>
        /// The effect of the card.
        /// </summary>
        public string EffectText { get; set; }

        /// <summary>
        /// The attack of the card.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// The defense of the card.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// The Id of the set of the card.
        /// Represent the foreign key to the other table.
        /// </summary>
        [ForeignKey(typeof(FowSet))]     // Specify the foreign key
        public int SetId { get; set; }

        /// <summary>
        /// The set of the card.
        /// </summary>
        [ManyToOne]
        public FowSet Set { get; set; }

        /// <summary>
        /// The collections where the card is.
        /// </summary>
        [ManyToMany(typeof(CollectionCard))]
        public List<FowCollection> Collections { get; set; }
    }
}
