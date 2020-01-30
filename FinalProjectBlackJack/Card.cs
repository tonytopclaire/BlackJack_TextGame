/*********************************************************************************************
 * Program Name:    Card.cs Class                                                            *
 * Program Author:  David McDonald, Marya Pannike, Shengqian Wang                            *
 * Date:            March 24th, 2013                                                         *
 *                                                                                           *
 * Description:     This class matches the Rank and Suit enums together to form cards.       *
 *                  There are a total of 52 total combinations between the feilds entered    *
 *                  in between the 2 enums                                                   *
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
    public class Card
    {
        public readonly Rank rank; // Rank of the card
        public readonly Suit suit; // Suit of the card

        // Default constructor (should be never used...)
        public Card(){}

        // Parameterized constructor
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        // Return name of card
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        // Return the 2 integer values that make up the card
        public string getCardString()
        {
            return ((int)rank + " " + (int)suit);
        }
    }
}
