using ForceOfWillCube.Models.Cards;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ForceOfWillCube.Models.Collections
{
    [Table("collectioncards")]
    public class CollectionCard
    {
        [ForeignKey(typeof(FowCollection))]
        public int StudentId { get; set; }

        [ForeignKey(typeof(FowCard))]
        public int SubjectId { get; set; }
    }
}