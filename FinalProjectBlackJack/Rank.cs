/*********************************************************************************************
 * Program Name:    Rank.cs Enum                                                             *
 * Program Author:  David McDonald, Marya Pannike, Shengqian Wang                            *
 * Date:            March 24th, 2013                                                         *
 *                                                                                           *
 * Description:     This Enum places values on the 13 different ranks in a deck of cards.    *
 *                  By design this enum will place the value of 1 on the "Ace" card up to    *
 *                  the rank of 13 given to the "King" card.                                 *
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
    // Gives a value to each rank in a deck.
    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}
