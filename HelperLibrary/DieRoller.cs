#region Header

//----------------------------------------------------------------
// <copyright file="DieRoller.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

#endregion Header

namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Die
    {
        #region Fields

        public readonly int Sides;

        public static Die D10 = new Die(10);
        public static Die D100 = new Die(100);
        public static Die D20 = new Die(20);
        public static Die D4 = new Die(4);
        public static Die D6 = new Die(6);
        public static Die D8 = new Die(8);

        #endregion Fields

        #region Constructors

        public Die(int numberOfSides)
        {
            this.Sides = numberOfSides;
        }

        #endregion Constructors

        #region Methods

        public int Roll(Random rand)
        {
            return rand.Next(1, Sides);
        }

        #endregion Methods
    }

    public class DieRoller
    {
        #region Fields

        private Random rand;

        #endregion Fields

        #region Constructors

        public DieRoller()
        {
            rand = new Random();
        }

        #endregion Constructors

        #region Methods

        public int RoleDie(Die die, int timesToRoll)
        {
            int sum = 0;
            for(int i = 0; i < timesToRoll; i ++)
            {
                sum += die.Roll(rand);
            }
            return sum;
        }

        public int RollDice(Die[] dice)
        {
            return dice.Select(die => die.Roll(rand)).Sum();
        }

        #endregion Methods
    }
}