namespace ForceOfWillCube.Models.Cards
{
    using SQLite;

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
    }
}
