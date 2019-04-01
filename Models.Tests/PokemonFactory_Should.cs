using NUnit.Framework;
using Project.Models;
using System;
using Project.Data;
using System.Collections.Generic;

namespace Project.UnitTests.Models
{
    public class PokemonFactory_Should
    {   DbRecord record = new DbRecord();
        Pokemon pokemon;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void stub()
        {
            Assert.Pass();
        }
        [Test]
        public void factoryGetTypeTest(){
            PokemonFactory factory = new PokemonFactory();
            Type type = factory.getType("Fighting");
            Assert.AreEqual(type,Type.Fighting);

        }
        [Test]
        public void factoryGetTypeTestNull(){
            PokemonFactory factory = new PokemonFactory();
            Type type = factory.getType("john");
            Assert.IsNull(type);

        }
        
        [Test]
        public void factoryGetRarityTest(){
            PokemonFactory factory = new PokemonFactory();
            Rarity rarity = factory.getRarity("Common");
            Assert.AreEqual(rarity,Rarity.Common);

        }
        [Test]
        public void factoryGetRarityTestNull(){
            PokemonFactory factory = new PokemonFactory();
            Rarity rarity = factory.getRarity("john");
            Assert.IsNull(rarity);

        }
    }
}