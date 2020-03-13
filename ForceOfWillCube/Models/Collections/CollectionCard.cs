using System;
using ForceOfWillCube.Models.Cards;
using SQLiteNetExtensions.Attributes;

namespace ForceOfWillCube.Models.Collections
{
    public class CollectionCard
    {
        [ForeignKey(typeof(FowCollection))]
        public int StudentId { get; set; }

        [ForeignKey(typeof(FowCard))]
        public int SubjectId { get; set; }
    }
}