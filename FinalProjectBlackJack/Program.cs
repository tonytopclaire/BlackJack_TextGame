using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProjectBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BLACKJACK = 21;
            const int DEALER_HIT = 17;

            List<int> player1 = new List<int>(); // New Player
            List<int> dealer = new List<int>();
            Deck deck = new Deck(8);
            deck.Shuffle();
            bool playerStop = false;
            bool playerBust = false;
            bool dealerStay = false;
            string hitCheck;
            int cardIndex = 0;

            Console.WriteLine("Test \"Hitting\" Program!");


            player1.Add(cardIndex); // Give the player the first card
            cardIndex++;
            player1.Add(cardIndex); // Give the player the second card
            cardIndex++;
            dealer.Add(cardIndex);
            cardIndex++;
            dealer.Add(cardIndex);

            Console.WriteLine("You picked up " + deck.GetCard(player1[0]) + "! And " 
                + deck.GetCard(player1[1]) + " Value: " + deck.getValue(ref player1) + "\n");

            Console.WriteLine("The Dealer picked up two cards, One of them being " + deck.GetCard(dealer[0]) + "!\n");

            while (!playerStop)
            {
                Console.Write("\nHit? (Y/N):");
                hitCheck = Console.ReadLine();

                if (hitCheck == "Y" || hitCheck == "y")
                {
                    cardIndex++;
                    player1.Add(cardIndex);
                    Console.WriteLine("You picked up " + deck.GetCard(cardIndex) + "!\n");
                    Console.WriteLine("Value: " + deck.getValue(ref player1));

                    if (deck.getValue(ref player1) > BLACKJACK)
                    {
                        Console.WriteLine("Bust!! ");
                        playerStop = true;
                        playerBust = true;
                    }
                }
                else
                {
                    Console.WriteLine("You stayed with a value of "  + deck.getValue(ref player1));
                    playerStop = true;
                }
            }

            if (!playerBust)
            {
                Console.WriteLine("Dealer flips other card. It is " + deck.GetCard(dealer[1]));

                while (!dealerStay)
                {
                    if ((deck.getValue(ref dealer) < DEALER_HIT) && !deck.isSoft(ref dealer))
                    {
                        cardIndex++;
                        dealer.Add(cardIndex);
                        Console.WriteLine("The dealer picked up " + deck.GetCard(dealer[dealer.Count - 1]));
                    }
                    else
                        dealerStay = true;
                }

                if (deck.getValue(ref player1) > deck.getValue(ref dealer) || deck.getValue(ref dealer) > BLACKJACK)
                    Console.WriteLine("You Win! Dealer got: " + deck.getValue(ref dealer) + 
                        " You got: " + deck.getValue(ref player1));
                else if (deck.getValue(ref player1) == deck.getValue(ref dealer))
                    Console.WriteLine("You Tie! Dealer got: " + deck.getValue(ref dealer) + 
                        " You got: " + deck.getValue(ref player1));
                else
                    Console.WriteLine("You Lose! Dealer got: " + deck.getValue(ref dealer) +
                        " You got: " + deck.getValue(ref player1));
            }

            Console.ReadKey();
        }

        // Saves the status of a deck to a text file
        public static void saveDeck(ref Deck theDeck)
        {
            System.IO.StreamWriter fileTest = new System.IO.StreamWriter("SaveDeck.txt");
            for (int card = 0; card < 52; card++)
            {
                fileTest.WriteLine(theDeck.GetCard(card).getCardString());
            }
            fileTest.Close();
        }

        // Saves the cards being held in a player's hand.
        public static void savePlayerHand(ref List<int> hand, int playerNum)
        {
            System.IO.StreamWriter fileTest = new System.IO.StreamWriter("SaveHand.txt");
            fileTest.Write("Player" + playerNum + "=");
            foreach (int card in hand)
            {
                fileTest.Write(card + ",");
            }
            fileTest.Close();
        }
    }
}
