// <copyright file="Lorem.cs" company="Microsoft Corporation">
// Copyright (c) 2011 All Rights Reserved
// </copyright>
// <author>v-nicarl</author>
// <email></email>
// <date>17-Jan-11 09:16:19</date>
// <summary></summary>
namespace HelperLibrary.Lipsum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Lipsum dummy-text generator.
    /// </summary>
    public partial class Lorem : IDisposable
    {
        #region Fields

        static Random random = new Random();

        private bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor for the lipsum generator.
        /// </summary>
        public Lorem()
        {
        }

        #endregion Constructors

        #region Enumerations

        /// <summary>
        /// This denotes a body of work from which to draw lipsum text.
        /// </summary>
        public enum LipsumType
        {
            /// <summary>
            /// Lorem ipsum - Cicero
            /// </summary>
            Cicero,
            /// <summary>
            /// Le Bateau Ivre - Arthur Baudelaire
            /// </summary>
            Baudelaire,
            /// <summary>
            /// The Raven - Edgar Allen Poe
            /// </summary>
            Poe,
            /// <summary>
            /// Faust: Der Tragödie erster Teil - Johann Wolfgang von Goethe
            /// </summary>
            Faust,
            /// <summary>
            /// Childe Harold's Pilgrimage - Canto the first (I.-X.) - Lord Byron
            /// </summary>
            LordByron,
            /// <summary>
            /// Decameron - Novella Prima - Giovanni Boccaccio
            /// </summary>
            NovellaPrima,
            /// <summary>
            /// In der Fremde - Heinrich Heine
            /// </summary>
            Fremde,
            /// <summary>
            /// Le Masque - Arthur Rembaud
            /// </summary>
            LeMasque,
            /// <summary>
            /// Nagyon fáj - József Attila
            /// </summary>
            Attila,
            /// <summary>
            /// Ómagyar-Mária siralom - Ismeretlen
            /// </summary>
            Siralom,
            /// <summary>
            /// Robinsono Kruso (Esperanto) - Daniel Defoe
            /// </summary>
            KrusoEsperanto,
            /// <summary>
            /// Tierra y Luna - Federico García Lorca
            /// </summary>
            Luna,
            /// <summary>
            /// Hemsöborna - August Strindberg (1912-1921)
            /// </summary>
            Strindberg,
            /// <summary>
            /// La Divina Commedia di Dante: Inferno, Cantos I & II - Dante Alighieri
            /// </summary>
            Inferno
        }

        /// <summary>
        /// User can specify N characters, words, or lines of lipsum.
        /// </summary>
        public enum QuantityType
        {
            /// <summary>
            /// This setting specifies characters of lipsum.
            /// </summary>
            Characters,
            /// <summary>
            /// This setting specifies words of lipsum.
            /// </summary>
            Words,
            /// <summary>
            /// This setting specifies lines of lipsum.
            /// </summary>
            Lines
        }

        #endregion Enumerations

        #region Methods

        /// <summary>
        /// Generates lipsum.
        /// </summary>
        /// <param name="quantityType"></param>
        /// <param name="lipsumType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Lipsum(QuantityType quantityType, LipsumType lipsumType, int count)
        {
            return Lipsum(quantityType, lipsumType, count, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantityType"></param>
        /// <param name="lipsumType"></param>
        /// <param name="count"></param>
        /// <param name="startingAt"></param>
        /// <returns></returns>
        public static string Lipsum(QuantityType quantityType, LipsumType lipsumType, int count, int startingAt)
        {
            return Lipsum(quantityType, lipsumType, count, startingAt, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantityType"></param>
        /// <param name="lipsumType"></param>
        /// <param name="count"></param>
        /// <param name="startingAt"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string Lipsum(QuantityType quantityType, LipsumType lipsumType, int count, int startingAt, bool random)
        {
            string selectedLipsum = GetLipsumType(lipsumType);
            switch (quantityType)
            {
                case QuantityType.Characters:
                    {
                        if (random)
                        {
                            selectedLipsum = RandomizeOrder(selectedLipsum);
                        }

                        selectedLipsum = Lorem.RemoveLinefeeds(selectedLipsum);
                        selectedLipsum = Lorem.SingleSpaceOnly(selectedLipsum);

                        while (count > selectedLipsum.Length)
                        {
                            selectedLipsum = string.Format("{0} {0}", selectedLipsum);
                        }

                        count = (count > selectedLipsum.Length)
                            ? selectedLipsum.Length
                            : count;

                        // startingAt is the character we are starting at
                        startingAt = (startingAt > selectedLipsum.Length)
                            ? selectedLipsum.Length
                            : startingAt;

                        return (count + startingAt > selectedLipsum.Length)
                            ? selectedLipsum.Substring(startingAt, selectedLipsum.Length - startingAt)
                            : selectedLipsum.Substring(startingAt, count);

                    }
                case QuantityType.Lines:
                    {
                        if (random)
                        {
                            selectedLipsum = RandomizeOrder(selectedLipsum);
                        }

                        List<string> lines = selectedLipsum.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        while (count > lines.Count())
                        {
                            lines.AddRange(lines);
                        }

                        // startingAt is the line # we are starting at
                        startingAt = (startingAt + count > lines.Count())
                            ? 0
                            : startingAt;

                        return string.Join(Environment.NewLine, lines.Skip(startingAt).Take(count));
                    }
                default:
                case QuantityType.Words:
                    {
                        //selectedLipsum = selectedLipsum.Replace(Environment.NewLine, " ").Replace("  ", " ");
                        selectedLipsum = Lorem.RemoveLinefeeds(selectedLipsum);
                        selectedLipsum = Lorem.SingleSpaceOnly(selectedLipsum);

                        while (count > WordCount(selectedLipsum))
                        {
                            selectedLipsum = string.Format("{0} {0}", selectedLipsum);
                        }
                        //count = (count > WordCount(selectedLipsum)) ? WordCount(selectedLipsum) : count;
                        // the word we are starting at
                        startingAt = (count + startingAt > WordCount(selectedLipsum)) ? 0 : startingAt;

                        return (random)
                            ? RandomWords(selectedLipsum, count)
                            : string.Join(" ", selectedLipsum.Split(' ').AsEnumerable().Skip(startingAt).Take(count));

                    }
            }
        }

        /// <summary>
        /// Removes blank lines from a text string.
        /// </summary>
        /// <param name="words">A text string.</param>
        /// <returns>The text string with empty lines removed.</returns>
        public static string RemoveEmptyLines(string words)
        {
            return string.Join("\r\n", words.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        /// <summary>
        /// Replaces all linefeeds with a single space.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>New string without linefeeds.</returns>
        public static string RemoveLinefeeds(string words)
        {
            return string.Join(" ", words.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        /// <summary>
        /// Replaces tabs with single spaces.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>A string without tabs.</returns>
        public static string RemoveTabs(string words)
        {
            return words.Replace("\t", " ");
        }

        /// <summary>
        /// Ensures only single spaces exist in a string.
        /// </summary>
        /// <param name="words">String to process.</param>
        /// <returns>New string without linefeeds.</returns>
        public static string SingleSpaceOnly(string words)
        {
            return string.Join(" ", words.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray());
        }

        public static string stuff(string input, LipsumType lipsumType)
        {
            string selectedLipsum = GetLipsumType(lipsumType);
            //char[] splitter = new char[] { ' ', ',', '.', ':', '\t', '|', '[', ']' , '{', '}', '(', ')', '\'', '\"', ';'};

            List<string> inputArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lipsumArr = selectedLipsum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> outputArr = new List<string>();
            string[] namedEntities = new string[] { "&quot;", "&amp;", "&nbsp;", "&apos;", "&lt;", "&gt;" };

            StringBuilder sb = new StringBuilder();

            foreach (string s in inputArr)
            {
                List<string> trunc = lipsumArr.Where(p => p.Length == s.Length).ToList();
                try
                {

                    if (trunc.Count == 0 || namedEntities.Contains(s))
                    {
                        outputArr.Add(s);
                    }
                    else
                    {
                        outputArr.Add(trunc[random.Next(0, trunc.Count)]);
                    }
                }
                catch (Exception)
                {
                    outputArr.Add(s);
                    HelperLibrary.DebugOut.WriteLine(s);
                    //throw;
                }

            }

            // match each word, replace with random word from selectedLipsum
            return string.Join(" ", (outputArr).ToArray());

            //return string.Empty;
        }

        /// <summary>
        /// Count words with Regex.
        /// </summary>
        public static int WordCount(string s)
        {
            MatchCollection collection = Regex.Matches(s, @"[\S]+");
            return collection.Count;
        }

        /// <summary>
        /// IDispose member.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns string variable for the given lipsumType.
        /// </summary>
        /// <param name="lipsumType"></param>
        /// <returns></returns>
        private static string GetLipsumType(LipsumType lipsumType)
        {
            switch (lipsumType)
            {
                default:
                case LipsumType.Cicero:
                    {
                        return Cicero;
                    }
                case LipsumType.Baudelaire:
                    {
                        return Baudelaire;
                    }
                case LipsumType.Poe:
                    {
                        return Poe;
                    }
                case LipsumType.Faust:
                    {
                        return Faust;
                    }
                case LipsumType.LordByron:
                    {
                        return LordByron;
                    }
                case LipsumType.NovellaPrima:
                    {
                        return NovellaPrima;
                    }
                case LipsumType.Fremde:
                    {
                        return Fremde;
                    }
                case LipsumType.LeMasque:
                    {
                        return LeMasque;
                    }
                case LipsumType.Attila:
                    {
                        return Attila;
                    }
                case LipsumType.Siralom:
                    {
                        return Siralom;
                    }
                case LipsumType.KrusoEsperanto:
                    {
                        return KrusoEsperanto;
                    }
                case LipsumType.Luna:
                    {
                        return Luna;
                    }
                case LipsumType.Strindberg:
                    {
                        return Strindberg;
                    }
                case LipsumType.Inferno:
                    {
                        return Inferno;
                    }
            }
        }

        /// <summary>
        /// Randomizes order of words in a given string.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        private static string RandomizeOrder(string words)
        {
            return string.Join(" ", ShuffleArray(words.Split(' ')).ToArray());
        }

        /// <summary>
        /// Selects a number of words at random from a string.
        /// </summary>
        /// <param name="lipsumType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static string RandomWords(string words, int count)
        {
            return string.Join(" ", ShuffleArray(words.Split(' ')).Take(count > words.Count() ? words.Count() : count).ToArray());
        }

        private static IEnumerable<string> ShuffleArray(IEnumerable<string> words)
        {
            return words.OrderBy(x => random.Next());
        }

        /// <summary>
        /// Private dispose method to handle any additional resource cleanup.
        /// </summary>
        void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // dispose logic
                disposed = true;
            }
        }

        #endregion Methods
    }
}