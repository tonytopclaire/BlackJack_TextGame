/*********************************************************************************************
 * Program Name:    Deck.cs Class                                                            *
 * Program Author:  David McDonald, Marya Pannike, Shengqian Wang                            *
 * Date:            March 24th, 2013                                                         *
 *                                                                                           *
 * Description:     This Class manages an array of 52 Card class objects. With the ability   *
 *                  to shuffle the deck multiple times, and get the cards by an integer      *
 *                  indexed system.                                                          *
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

    public class Deck
    {
        private Card[] cards; // Array of Card class Objects

        private const int CARDS_IN_DECK = 52; //Number of cards in a deck
        private const int NUM_OF_SUITS = 4; // Number of suits in a deck
        private const int NUM_OF_RANKS = 13; // Number of ranks in a deck
        private const int DEFAULT_NUM_OF_DECKS = 2; // Default number of decks

        // Default constructor
        public Deck():this (DEFAULT_NUM_OF_DECKS)
        {
        }

        public Deck(int numOfDecks)
        {
            cards = new Card[CARDS_IN_DECK * numOfDecks]; //Create a new Array of Cards

            for (int decks = 0; decks <= (numOfDecks-1); decks++)
            {
                // Using two for loops, create each combination of card (Make a deck of cards)
                for (int suitVal = 0; suitVal < NUM_OF_SUITS; suitVal++)
                {
                    for (int rankVal = 1; rankVal <= NUM_OF_RANKS; rankVal++)
                    {
                        //Make a new card with the current Suit/Rank Values
                        cards[suitVal * NUM_OF_RANKS + rankVal - 1 + (decks * CARDS_IN_DECK)] = new Card((Suit)suitVal,
                                                                    (Rank)rankVal);
                    }
                }
            }
        }

        // Gets a card based on the index specified
        public Card GetCard(int cardNum)
        {
            // If the card number is between 0-51 (Valid card number)
            if (cardNum >= 0 && cardNum <= cards.Length-1)
                return cards[cardNum]; // Return the card in that place in the deck

            // The card wasn't between the valid values
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                          "There was a problem retrieving a card."));
        }

        // Shuffle's the Deck
        public void Shuffle()
        {
            Card[] newDeck = new Card[cards.Length]; // The new deck that will be shuffled into
            bool[] assigned = new bool[cards.Length]; // Array of Booleans. Used for "Has this card been shuffled yet logic"
            Random sourceGen = new Random(); // For Random numbers

            bool foundCard = false; // Used for while-loop logic during card processing
            int destCard = 0;

            // For each card in the deck
            for (int i = 0; i < cards.Length; i++)
            {
                destCard = 0; // Reset destCard to zero
                foundCard = false; // Reset while-logic 
                while (foundCard == false) // Loop until unassigned card is found
                {
                    destCard = sourceGen.Next(cards.Length); //get a random number
                    if (assigned[destCard] == false) // If that random number hasn't been assigned yet
                        foundCard = true; // Break loop so card can be assigned
                }
                assigned[destCard] = true; // Set assigned flag to true
                newDeck[destCard] = cards[i]; // Assign the card to it's new position in the deck
            }
            newDeck.CopyTo(cards, 0); // Hope the new deck to the old deck, replacing the positions of the cards with the new ones
        }

        public int getValue(ref List<int> hand)
        {
            const int FACE_VALUE = 10; // Value of a face card
            const int GOOD_BLACKJACK_HAND = 21; // Value of a Perfect Blackjack hand

            bool handIsSoft = false; // If the player has an ace
            int handValue = 0; // Value of the player's hand

            // For each card in the player's hand
            foreach (int card in hand)
            {
                // Check if the card is an ace
                if (this.isSoft(ref hand))
                    handIsSoft = true;

                // If the card is a face card (Jack to King)
                if ((int)this.GetCard(card).rank > FACE_VALUE)
                    handValue += FACE_VALUE; // Add the Face Value to the hand value
                else
                    handValue += (int)this.GetCard(card).rank; // Add the card's value to the hand's value
            }

            // If the hand's value is less than 21. AND the player has an ace in hand
            if (handValue < GOOD_BLACKJACK_HAND && handIsSoft)
            {
                // If the player's hand + 10 would still be Less than or equal to a good hand
                if ((handValue + FACE_VALUE) <= GOOD_BLACKJACK_HAND)
                    handValue += FACE_VALUE; // Add the 10 value from the ace (Otherwise keep the 1
            }

            return handValue;
        }

        public bool isSoft(ref List<int> hand)
        {
            bool result = false;

            foreach (int card in hand)
            {
                if (this.GetCard(card).rank == Rank.Ace)
                    result = true;
            }
            return result;
        }
    }
}