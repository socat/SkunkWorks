//----------------------------------------------------------------
// <copyright file="LipsumGeneratorTest.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

using System;
using System.Linq;
//using CT;
using LipsumGenerator;

namespace LipsumGeneratorTests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LipsumGeneratorTest
    {
        #region Methods


        [TestMethod]
        public void GenerateLipsumOutOfRangeCharCount()
        {
            try
            {
                Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, Lipsum.MaxChars + 1, true);
                Assert.Fail("GenerateLipsum should throw an out of range exception when the max value is exceeded.");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void GenerateLipsumOutOfRangeLineCount()
        {
            try
            {
                Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, Lipsum.MaxLines + 1, true);
                Assert.Fail("GenerateLipsum should throw an out of range exception when the max value is exceeded.");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void GenerateLipsumOutOfRangeWordCount()
        {
            try
            {
                Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, Lipsum.MaxWords + 1, true);
                Assert.Fail("GenerateLipsum should throw an out of range exception when the max value is exceeded.");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void GenerateLipsumWithCharacters()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, 100, true);
            Assert.AreEqual(100, blah.Length, "Expected 100 characters.");
        }
        
        [TestMethod]
        public void GenerateLipsumWithCharactersRandomize()
        {
            Assert.AreEqual(Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, 100, false), Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, 100, false));
            Assert.AreNotEqual(Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, 100, true), Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, 100, false));
        }

        [TestMethod]
        public void GenerateLipsumWithLines()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, 100, true);
            Assert.AreEqual(100, blah.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Count(), "Expected 100 lines .");
        }

        [TestMethod]
        public void GenerateLipsumWithLinesRandomize()
        {
            Assert.AreEqual(Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, 100, false), Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, 100, false));
            Assert.AreNotEqual(Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, 100, true), Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, 100, false));
        }

        [TestMethod]
        public void GenerateLipsumWithMaxCharacters()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Characters, LipsumType.Cicero, Lipsum.MaxChars, true);
            Assert.AreEqual(Lipsum.MaxChars, blah.Length, "Expected max characters .");
        }

        [TestMethod]
        public void GenerateLipsumWithMaxLines()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Lines, LipsumType.Cicero, Lipsum.MaxLines, true);
            Assert.AreEqual(Lipsum.MaxLines, blah.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Count(), "Expected max lines .");
        }

        [TestMethod]
        public void GenerateLipsumWithMaxWords()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, Lipsum.MaxWords, true);
            Assert.AreEqual(Lipsum.MaxWords, blah.WordCount(), "Expected max words .");
        }

        [TestMethod]
        public void GenerateLipsumWithWords()
        {
            string blah = Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, 100, true);
            Assert.AreEqual(100, blah.WordCount(), "Expected 100 words.");
        }

        [TestMethod]
        public void GenerateLipsumWithWordsRandomize()
        {
            Assert.AreEqual(Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, 100, false), Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, 100, false));
            Assert.AreNotEqual(Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, 100, true), Lipsum.GenerateLipsum(QuantityType.Words, LipsumType.Cicero, 100, false));
        }

        #endregion Methods
    }
}