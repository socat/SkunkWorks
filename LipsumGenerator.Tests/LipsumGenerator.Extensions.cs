#region Header

//----------------------------------------------------------------
// <copyright file="LipsumGenerator.Extensions.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

#endregion Header

namespace LipsumGeneratorTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using LipsumGenerator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class LipsumGeneratorExtensionTests
    {
        #region Fields

        private readonly RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
        private readonly Random testRandom = new Random();

        private string[] testArray;
        private List<string> testList;

        #endregion Fields

        #region Methods

        [TestMethod]
        public void RandomizeOrderReturnsSelfWhenNull()
        {
            string testString = null;
            Assert.AreEqual(testString, testString.RandomizeOrder(testRandom));
        }
        
        [TestMethod]
        public void RandomizeOrderReturnsSelfWhenEmpty()
        {
            string testString = string.Empty;
            Assert.AreEqual(testString, testString.RandomizeOrder(testRandom));
        }

        [TestMethod]
        public void RandomizeOrderReordersSelf()
        {
            string testString = string.Join(" ", ArrayWithTestData());
            Assert.AreNotEqual(testString, testString.RandomizeOrder(testRandom));
        }

        [TestMethod]
        public void RandomWordsReturnsSelfIfNull()
        {
            string words = null;
            Assert.AreEqual(words, words.RandomWords(testRandom, 10));
        }
        
        [TestMethod]
        public void RandomWordsReturnsSelfIfEmpty()
        {
            string words = string.Empty;
            Assert.AreEqual(words, words.RandomWords(testRandom, 10));
        }

        [TestMethod]
        public void RandomWordsReordersWords()
        {
            string words = string.Join(" ", ArrayWithTestData(20));
            Assert.AreNotEqual(words, words.RandomWords(testRandom, 10));
        }



        [TestMethod]
        public void RandomWordsReturnsCorrectNumberOfWords()
        {
            string words = string.Join(" ", ArrayWithTestData(20));
            Assert.AreEqual(10, words.RandomWords(testRandom, 10).WordCount(), "Word count should be 10.");
        }


        [TestMethod]
        public void RandomWordsReturnsCurrentCountIfSpecifiedExceedsWordCount()
        {
            string words = string.Join(" ", ArrayWithTestData(20));
            Assert.AreEqual(20, words.RandomWords(testRandom, 100).WordCount(), "Word count should be 20.");
        }

        [TestMethod]
        public void RemoveEmptyLinesReturnsSelfIfNull()
        {
            string words = null;
            Assert.AreEqual(words, words.RemoveEmptyLines(), "RemoveEmptyLines should return self if null.");
        }

        [TestMethod]
        public void RemoveEmptyLinesReturnsSelfIfEmpty()
        {
            string words = string.Empty;
            Assert.AreEqual(words, words.RemoveEmptyLines(), "RemoveEmptyLines should return self if empty."); 
        }

        [TestMethod]
        public void RemoveEmptyLinesRemovesEmptyLines()
        {
            string words = string.Join("\r\n\r\n", ArrayWithTestData(20));
            Assert.AreNotEqual(words, words.RemoveEmptyLines());
            Assert.IsFalse(words.RemoveEmptyLines().Contains("\r\n\r\n"));
            Assert.IsTrue(words.RemoveEmptyLines().Contains("\r\n"));
        }


        [TestMethod]
        public void RemoveLinefeedsReturnsSelfIfNull()
        {
            string words = null;
            Assert.AreEqual(words, words.RemoveLinefeeds(), "RemoveLinefeeds should return self if null.");
        }

        [TestMethod]
        public void RemoveLinefeedsReturnsSelfIfEmpty()
        {
            string words = string.Empty;
            Assert.AreEqual(words, words.RemoveLinefeeds(), "RemoveLinefeeds should return self if empty.");
        }

        [TestMethod]
        public void RemoveLinefeedsRemovesAllLineFeeds()
        {
            string words = string.Join("\r\n\r\n", ArrayWithTestData(20));
            Assert.AreNotEqual(words, words.RemoveLinefeeds());
            Assert.IsFalse(words.RemoveLinefeeds().Contains("\r\n\r\n"));
            Assert.IsFalse(words.RemoveLinefeeds().Contains("\r\n"));
        }

        [TestMethod]
        public void RemoveTabsReturnsSelfIfNull()
        {
            string words = null;
            Assert.AreEqual(words, words.RemoveTabs(), "RemoveTabs should return self if null.");
        }

        [TestMethod]
        public void RemoveTabsReturnsSelfIfEmpty()
        {
            string words = string.Empty;
            Assert.AreEqual(words, words.RemoveTabs(), "RemoveTabs should return self if empty.");
        }

        [TestMethod]
        public void RemoveTabsRemovesAllTabs()
        {
            string words = string.Join("\t\t", ArrayWithTestData(20));
            Assert.AreNotEqual(words, words.RemoveTabs());
            Assert.IsFalse(words.RemoveTabs().Contains("\t"));
        }



        [TestMethod]
        public void ShufflArrayWithListReordersList()
        {
            testList = ListWithTestData();
            Assert.AreNotEqual(testList, testList.ShuffleArray(testRandom));
        }

        [TestMethod]
        public void ShuffleArrayWithArrayReordersArray()
        {
            testArray = ArrayWithTestData();
            Assert.AreNotEqual(testArray, testArray.ShuffleArray(testRandom));
        }

        [TestMethod]
        public void ShuffleArrayWithArrayReturnsSelfIfLengthIsZero()
        {
            testArray = new string[0];
            Assert.AreEqual(testArray, testArray.ShuffleArray(testRandom));
        }

        [TestMethod]
        public void ShuffleArrayWithArrayReturnsSelfIfNull()
        {
            testArray = null;
            Assert.AreEqual(testArray, testArray.ShuffleArray(testRandom));
        }

        

        [TestMethod]
        public void ShuffleArrayWithListReturnsSelfIfNull()
        {
            testList = null;
            Assert.AreEqual(testList, testList.ShuffleArray(testRandom));
        }

        [TestMethod]
        public void SingleSpaceOnlyReturnsSelfIfNull()
        {
            string words = null;
            Assert.AreEqual(words, words.SingleSpaceOnly(), "SingleSpaceOnly should return self if null.");
        }

        [TestMethod]
        public void SingleSpaceOnlyReturnsSelfIfEmpty()
        {
            string words = string.Empty;
            Assert.AreEqual(words, words.SingleSpaceOnly(), "SingleSpaceOnly should return self if empty.");
        }

        [TestMethod]
        public void SingleSpaceOnlyRemovesAllTabs()
        {
            string words = string.Join("  ", ArrayWithTestData(20));
            Assert.AreNotEqual(words, words.SingleSpaceOnly());
            Assert.IsFalse(words.SingleSpaceOnly().Contains("  "));
            Assert.IsTrue(words.SingleSpaceOnly().Contains(" "));
        }


        [TestInitialize]
        public void Startup()
        {
        }

        /// <summary>
        /// Generates a random string.
        /// </summary>
        /// <param name="stringLength">Length of the random string</param>
        /// <returns>A random string</returns>
        internal string RandomString(int stringLength = 10)
        {
            const string allowedChars = "abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Byte[] randomBytes = new Byte[stringLength];
            char[] chars = new char[stringLength];
            int allowedCharCount = allowedChars.Length;

            lock (rngProvider)
            {
                rngProvider.GetBytes(randomBytes);
            }
            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }

        /// <summary>
        /// Generates test data.
        /// </summary>
        /// <returns>An array with test data.</returns>
        internal string[] ArrayWithTestData(int arraySize = 10)
        {
            return Enumerable.Repeat<string>(string.Empty, arraySize)
                .Select(i => RandomString())
                .ToArray();
        }

        /// <summary>
        /// Generates test data.
        /// </summary>
        /// <returns>A list of test data.</returns>
        internal List<string> ListWithTestData(int listSize = 10)
        {
            return Enumerable.Repeat<string>(string.Empty, listSize)
                .Select(i => RandomString())
                .ToList();
        }

        #endregion Methods
    }
}