using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //Level 1: Create a playable blackjack game with one human player and one computer dealer

    //How to Play Black Jack:
    //1.	Start a new game
    //2.	Deal two cards to both players
    //3.	Ask players with the status "playing" if they want another card: if someone does, give them another card; if someone doesn't, change their status to "stay"
    //4.	Repeat step 3 while there are players with "playing" status
    //5.	Compare players' hands to declare winner and loser. Update player statistics

    //     Game Classes:
    //     PlayerStatus class: wrapper class for player; data such as current player's hand and current status are stored 
    //     Game Class: Blackjack game Logic 
    //     Main

    //     GAME METHODS
    //     StartGame
    //     PlayerTurn
    //     GiveCardToPlayer
    //     EndRound

    //     ENUMS & CLASSES
    //     Suit: Hearts, Clubs, Diamonds, Spades
    //     Rank: Ace(11), Deuce, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    //     Card: 




    class Program
    {

        
        static void Main(string[] args)
        {
            int playerScore, dealerScore;
            bool playing, bust;
            int numberOfCards = 52;
            int currentCard;
            int counter = 0;

            // / Game Greeting & Start Game
            Console.WriteLine("Welcome to McStanley's Black Jack. Would you like to play Black Jack? \nY/N");
            playing = Console.ReadKey().ToString().ToLower() == "y";

            //New Deck)
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suits s in Enum.GetValues(typeof(Suits)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            //this is deck shuffled
            //sort the deck. NOTICE that the variable 'deck' is unchanged, but 'randomDeck' is the actual sorted deck.
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            //Check all cards are there and go to output
            foreach (var dealCard in randomDeck)
            {

                Console.WriteLine(dealCard);
            }

            Console.ReadLine();

        }
    }
}
