//----------------------------------------------------------------
// <copyright file="Extensions.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace LipsumGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// Randomizes order of words in a given string.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static string RandomizeOrder(this string words, Random rnd)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : string.Join(" ", ShuffleArray(words.Split(' '), rnd).ToArray());
        }

        /// <summary>
        /// Selects a number of words at random from a string.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="count"></param>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static string RandomWords(this string words, Random rnd, int count)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : string.Join(" ", ShuffleArray(words.Split(' '), rnd)
                    .Take(count > words.WordCount() ? words.WordCount() : count)
                    .ToArray());
        }

        /// <summary>
        /// Removes blank lines from a text string.
        /// </summary>
        /// <param name="words">A text string.</param>
        /// <returns>The text string with empty lines removed.</returns>
        public static string RemoveEmptyLines(this string words)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : string.Join("\r\n", words.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        /// <summary>
        /// Replaces all linefeeds with a single space.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>New string without linefeeds.</returns>
        public static string RemoveLinefeeds(this string words)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : string.Join(" ", words.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        /// <summary>
        /// Replaces tabs with single spaces.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>A string without tabs.</returns>
        public static string RemoveTabs(this string words)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : words.Replace("\t", " ");
        }

        /// <summary>
        /// Shuffle the entries in a word array.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static string[] ShuffleArray(this string[] words, Random rnd)
        {
            if(words == null || words.Length == 0)
            {
                return words;
            }

            return words.OrderBy(x => rnd.Next()).ToArray();
        }

        /// <summary>
        /// Shuffle the entries in a word array.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static IEnumerable<string> ShuffleArray(this IEnumerable<string> words, Random rnd)
        {
            if (words == null)
            {
                return words;
            }

            return words.OrderBy(x => rnd.Next()).ToArray();
        }

        /// <summary>
        /// Ensures only single spaces exist in a string.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>New string without linefeeds.</returns>
        public static string SingleSpaceOnly(this string words)
        {
            return string.IsNullOrEmpty(words)
                ? words
                : string.Join(" ", words.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        /// <summary>
        /// Count words with Regex.
        /// </summary>
        public static int WordCount(this string words)
        {
            MatchCollection collection = Regex.Matches(words, @"[\S]+");
            return collection.Count;
        }

        #endregion Methods
    }
}