using NUnit.Framework;
using Project.Models;
using System;
using Project.Data;
using System.Collections.Generic;

namespace Project.UnitTests.Models
{
    public class Pokemon_Should
    {   DbRecord record = new DbRecord();
        Pokemon pokemon;
        [SetUp]
        public void Setup()
        {
            record.Name = "Pikachu";
            record.Number = "25";
            record.Image = "image";
            record.Type_1 = "Electric";
            record.Type_2 = "Electric";
            record.Move1 = "Quick Attack";
            record.Move2 = "Agility";
            record.Move3 = "Iron Tail";
            record.Move4 = "Tail whip";
            record.Description = "Description";
            record.Weight = "10";
            record.Height = "192";
            record.Level = "30";
            record.HP = "100";
            record.Pre_Evolution = "pichu";
            record.Evolution = "Raichu";

            PokemonFactory pokemonFactory = new PokemonFactory();

            pokemon = new Pokemon(
                record.Number, 
                record.Name, 
                Type.Electric, 
                Type.Electric, 
                record.Description, 
                record.Weight,
                record.Height,
                Convert.ToUInt32(record.Level), 
                Convert.ToUInt32(record.HP), 
                record.Pre_Evolution, 
                record.Evolution, 
                Rarity.Common, 
                record.Move1, 
                record.Move2,
                record.Move3, 
                record.Move4, 
                record.Image
            ); 
        }

        [Test]
        public void stub()
        {
            Assert.Pass();
        }
        [Test]
        public void pokemonConstructorTest()
        {   
            Assert.AreEqual(record.Name,pokemon.Name);
            Assert.AreEqual(Convert.ToInt32(record.Number),pokemon.Number);
            Assert.AreEqual(record.Image,pokemon.Image);
            Assert.AreEqual(record.Move1,pokemon.Move1);
            Assert.AreEqual(record.Move2,pokemon.Move2);
            Assert.AreEqual(record.Move3,pokemon.Move3);
            Assert.AreEqual(record.Move4,pokemon.Move4);
            Assert.AreEqual(record.Description,pokemon.Description);
            Assert.AreEqual(Convert.ToInt32(record.Weight),pokemon.Weight);
            Assert.AreEqual(Convert.ToInt32(record.Height),pokemon.Height);
            Assert.AreEqual(Convert.ToInt32(record.Level),pokemon.Level);
            Assert.AreEqual(Convert.ToInt32(record.HP),pokemon.Hp);
            Assert.AreEqual(record.Pre_Evolution,pokemon.PreEvolution);
            Assert.AreEqual(record.Evolution,pokemon.Evolution);
        }

        public void pokemonIVTest(){
            pokemon.getIV();
            Assert.LessOrEqual(pokemon.IV,1);
            Assert.GreaterOrEqual(pokemon.IV,0);
        }
    }
}