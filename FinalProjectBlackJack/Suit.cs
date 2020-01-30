/*********************************************************************************************
 * Program Name:    Suit.cs Enum                                                             *
 * Program Author:  David McDonald, Marya Pannike, Shengqian Wang                            *
 * Date:            March 24th, 2013                                                         *
 *                                                                                           *
 * Description:     This Enum places values on the 4 different suits in a deck of cards.     *
 *                  By design this enum will place the value of 0 on "Clubs" to the value of *
 *                  3 on "Spades"                                                            *
 *                                                                                           *
 * Note:            This class was originally designed by the Tutorial programs from         *
 *                  Beginning Visual C# 2010 by Karli Watson, Jacob Hammer Pedersen,         *
 *                  Jon D. Reid and Morgan Skinner.                                          *
 *********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProjectBlackJack
{   
    // Gives a value to each suit in a deck
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }
}
