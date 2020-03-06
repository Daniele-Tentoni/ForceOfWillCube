namespace ForceOfWillCube.NUnit
{
    using ForceOfWillCube.Models;
    using global::NUnit.Framework;
    using System;
    using System.IO;

    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "collection.db3"));
        }

        [Test]
        public void Test1()
        {
            var cards = this.database.GetAllCards();
            Assert.AreEqual(2, cards.Count);
            Assert.Pass();
        }
    }
}