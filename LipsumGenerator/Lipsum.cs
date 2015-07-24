//----------------------------------------------------------------
// <copyright file="Lipsum.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace LipsumGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

    public static class Lipsum
    {
        #region Fields

        internal const int MaxChars = 10000000;
        internal const int MaxLines = 10000;
        internal const int MaxWords = 100000;

        internal static Random rand = new Random();

        #endregion Fields

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantityType"></param>
        /// <param name="lipsumType"></param>
        /// <param name="count"></param>
        /// <param name="startingAt"></param>
        /// <param name="randomize"></param>
        /// <returns></returns>
        public static string GenerateLipsum(QuantityType quantityType, LipsumType lipsumType, int count, bool randomize)
        {
            switch (quantityType)
            {
                case QuantityType.Characters:
                    {
                        #region QuantityType.Characters
                        if(count > MaxChars)
                        {
                            throw new ArgumentOutOfRangeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Count cannot be greater than {0} for characters.", MaxChars));
                        }

                        string selectedLipsum = GetLipsumType(lipsumType).RemoveLinefeeds().SingleSpaceOnly();

                        if(count > selectedLipsum.Length)
                        {
                            while (count > selectedLipsum.Length)
                            {
                                selectedLipsum = string.Concat(selectedLipsum, " ", (selectedLipsum.Length) < (count / 2)
                                    ? selectedLipsum
                                    : selectedLipsum.Substring(0, count - selectedLipsum.Length));
                            }
                        }

                        return randomize
                            ? selectedLipsum.RandomizeOrder(rand).Substring(0, count)
                            : selectedLipsum.Substring(0, count);

                        #endregion
                    }
                case QuantityType.Lines:
                    {
                        #region QuantityType.Lines

                        if (count > MaxLines)
                        {
                            throw new ArgumentOutOfRangeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Count cannot be greater than {0} for lines.", MaxLines));
                        }

                        string selectedLipsum = (randomize)
                            ? GetLipsumType(lipsumType).RandomizeOrder(rand)
                            : GetLipsumType(lipsumType);

                        List<string> lines = selectedLipsum.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        while (count > lines.Count())
                        {
                            lines.AddRange(lines);
                        }

                        return string.Join("\r\n", lines.Take(count));

                        #endregion
                    }
                default:
                case QuantityType.Words:
                    {
                        #region QuantityType.Words

                        if (count > MaxWords)
                        {
                            throw new ArgumentOutOfRangeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Count cannot be greater than {0} for words.", MaxWords));
                        }

                        string selectedLipsum = GetLipsumType(lipsumType).RemoveLinefeeds().SingleSpaceOnly();

                        if (count > selectedLipsum.WordCount())
                        {
                            while (count > selectedLipsum.WordCount())
                            {
                                selectedLipsum = string.Concat(selectedLipsum, selectedLipsum.WordCount() < (count / 2)
                                    ? selectedLipsum
                                    : selectedLipsum.RandomWords(rand, count - selectedLipsum.WordCount() + 1));
                            }
                        }

                        return (randomize)
                            ? selectedLipsum.RandomWords(rand, count)
                            : string.Join(" ", selectedLipsum.Split(' ').AsEnumerable().Take(count));

                        #endregion
                    }
            }
        }

        internal static string GetLipsumType(LipsumType lipsumType)
        {
            return Properties.LipsumTable.ResourceManager.GetString(lipsumType.ToString());
        }

        #endregion Methods
    }
}