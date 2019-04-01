using NUnit.Framework;
using Project.Models;
using System;
using System.Collections.Generic;

namespace Project.UnitTests.Models
{
    public class TypeController_Should
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
        public void TestgetSuperEffectiveAgainstWith1Type()
        {
            Type type1check = Type.Fighting;
            String Expected = "Normal Rock Steel Ice Dark";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getSuperEffectiveAgainst(type1check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetSuperEffectiveAgainstWith2Type()
        {
            Type type1check = Type.Fighting;
            Type type2check = Type.Dark;
            String Expected = "Normal Rock Steel Ice";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getSuperEffectiveAgainst(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestGetTypesSuperEffectiveAgainstWith1Type()
        {
            Type type1check = Type.Fighting;
            String Expected = "Flying Psychic Fairy";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesSuperEffectiveAgainst(type1check);
            Assert.AreEqual(Expected, check);
        }
         [Test]
        public void TestGetTypesSuperEffectiveAgainstWith2Type()
        {
            Type type1check = Type.Dragon;
            Type type2check = Type.Dark;
            String Expected = "Fighting Bug Ice Dragon Fairy";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesSuperEffectiveAgainst(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }




        [Test]
        public void TestGetNotVeryEffectiveAgainstWith1Type()
        {
            Type type1check = Type.Fire;
            String Expected = "Rock Fire Water Dragon";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getNotVeryEffectiveAgainst(type1check);
            Assert.AreEqual(Expected, check);
        }
        [Test]
        public void TestGetNotVeryEffectiveAgainstWith2Type()
        {
            Type type1check = Type.Poison;
            Type type2check = Type.Water;
            String Expected = "Poison Ghost Steel Water Dragon";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getNotVeryEffectiveAgainst(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetTypesNotVeryEffectiveAgainstWith1Type()
        {
            Type type1check = Type.Ice;
            String Expected = "Steel Fire Water Ice";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesNotVeryEffectiveAgainst(type1check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetTypesNotVeryEffectiveAgainstWith2Type()
        {
            Type type1check = Type.Grass;
            Type type2check = Type.Water;
            String Expected = "Ground Steel Water";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesNotVeryEffectiveAgainst(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }


        [Test]
        public void TestgetTypesImmuneToItWith1Type()
        {
            Type type1check = Type.Flying;
            String Expected = "                  ";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesImmuneToIt(type1check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetTypesImmuneToItWith2Type()
        {
            Type type1check = Type.Psychic;
            Type type2check = Type.Ground;
            String Expected = "  Flying              Dark ";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getTypesImmuneToIt(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }


         [Test]
        public void TestgetImmuneToWith1Type()
        {
            Type type1check = Type.Steel;
            String Expected = "Poison";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getImmuneTo(type1check);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetImmuneToWith2Type()
        {
            Type type1check = Type.Ghost;
            Type type2check = Type.Rock;
            String Expected = "Normal Fighting";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getImmuneTo(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }





//effectiveness
        [Test]
        public void TestgetEffectivenessAgainstWith1Type()
        {
            Type type1check = Type.Ghost;
            Type Against = Type.Normal;
            float Expected = 0.0f;
            TypeCalculator tc = new TypeCalculator();
            float check = tc.getEffectivenessAgainst(type1check, Against);
            Assert.AreEqual(Expected, check);
        }
        [Test]
        public void TestgetEffectivenessAgainstDualTypewith2EffectsAgainst()
        {
            Type type1check = Type.Poison;
            Type Against1 = Type.Normal;
            Type Against2 = Type.Grass;
            float Expected = 2.0f;
            TypeCalculator tc = new TypeCalculator();
            float check = tc.getEffectivenessAgainstDualType(type1check, Against1, Against2);
            Assert.AreEqual(Expected, check);
        }
        [Test]
        public void TestgetDualTypeEffectivenessAgainstwith2EffectsAgainst()
        {
            Type type1check = Type.Steel;
            Type Type2check = Type.Psychic;
            Type Against1 = Type.Normal;
            float Expected = 1.0f;
            TypeCalculator tc = new TypeCalculator();
            float check = tc.getDualTypeEffectivenessAgainst(type1check, Type2check, Against1);
            Assert.AreEqual(Expected, check);
        }

        [Test]
        public void TestgetEffectivenessAgainstwith2EffectsAgainst()
        {
            Type type1check = Type.Flying;
            Type Type2check = Type.Ghost;
            Type Against1 = Type.Ground;
            Type Against2 = Type.Poison;
            float Expected = 1.0f;
            TypeCalculator tc = new TypeCalculator();
            float check = tc.getEffectivenessAgainst(type1check, Type2check, Against1, Against2);
            Assert.AreEqual(Expected, check);
        }

         [Test]
        public void TestCombineEffectivenesswith2EffectsAgainst()
        {
            Type type1check = Type.Ice;
            Type Type2check = Type.Rock;
            float[] Expected = { 1.0f, 0.5f, 4.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 0.25f, 1.0f, 0.5f, 2.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 1.0f };
            TypeCalculator tc = new TypeCalculator();
            float[] check = tc.CombineEffectiveness(type1check, Type2check);
            Assert.AreEqual(Expected, check);
        }
    }
}