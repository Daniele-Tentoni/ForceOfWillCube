namespace ForceOfWillCube.Models.Collections
{
    using ForceOfWillCube.Models.Cards;
    using SQLite;
    using System;
    using System.Collections.ObjectModel;

    [Table("collections")]
    public class FowCollection
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
