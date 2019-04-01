using NUnit.Framework;
using Project.Models;
using System;
using System.Collections.Generic;

namespace Project.UnitTests.Models
{
    public class Pokemon_Should
    {
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
        public void pokemonConstructorTest()
        {   Data data = new Data();
            data.Name = "Pikachu";
            data.Number = "25";
            data.Image = "image";
            data.Type_1 = "Electric";
            data.Type_2 = "Electric";
            data.Move1 = "Quick Attack";
            data.Move2 = "Agility";
            data.Move3 = "Iron Tail";
            data.Move4 = "Tail whip";
            data.Description = "Description";
            data.Weight = "10";
            data.Height = "192";
            data.Level = "30";
            data.HP = "100";
            data.Pre_Evolution = "pichu";
            data.Evolution = "Raichu";
            Pokemon pokemon = new Pokemon(data);
            Assert.AreEqual(data.Name,pokemon.Name);
            Assert.AreEqual(Convert.ToInt32(data.Number),pokemon.Number);
            Assert.AreEqual(data.Image,pokemon.Image);
            Assert.AreEqual(data.Move1,pokemon.move1);
            Assert.AreEqual(data.Move2,pokemon.move2);
            Assert.AreEqual(data.Move3,pokemon.move3);
            Assert.AreEqual(data.Move4,pokemon.move4);
            Assert.AreEqual(data.Description,pokemon.Description);
            Assert.AreEqual(Convert.ToInt32(data.Weight),pokemon.Weight);
            Assert.AreEqual(Convert.ToInt32(data.Height),pokemon.Height);
            Assert.AreEqual(Convert.ToInt32(data.Level),pokemon.Level);
            Assert.AreEqual(Convert.ToInt32(data.HP),pokemon.Hp);
            Assert.AreEqual(data.Pre_Evolution,pokemon.Pre_Evolution);
            Assert.AreEqual(data.Evolution,pokemon.Evolution);
        }
    }
}