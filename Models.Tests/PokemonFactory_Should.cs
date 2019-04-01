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
        // [Test]
        // public void factoryGetTypeTest(){
        //     PokemonFactory factory = new PokemonFactory();
        //     Type type = factory.GetType("Fighting");
        //     Assert.AreEqual(type,Type.Fighting);

        [Test]
        public void factoryTest(){
            PokemonFactory factory = new PokemonFactory();
            Pokemon pokemon = factory.GetPokemonByName("Ivysaur");
            Assert.IsNotNull(pokemon);
            Assert.AreEqual("IVYSAUR",pokemon.Name);

        }
        
    }
}