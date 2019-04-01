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
            String Expected = "Normal Rock Steel Ice ";
            TypeCalculator tc = new TypeCalculator();
            string check = tc.getSuperEffectiveAgainst(type1check, type2check);
            Assert.AreEqual(Expected, check);
        }

        // [Test]
        // public void TestgetSuperEffectiveAgainstWith2Type()
        // {
        //     Type type1check = Type.Fighting;
        //     Type type2check = Type.Dark;
        //     String Expected = "Normal Rock Steel Ice ";
        //     TypeCalculator tc = new TypeCalculator();
        //     string check = tc.getSuperEffectiveAgainst(type1check, type2check);
        //     Assert.AreEqual(Expected, check);
        // }

    }
}