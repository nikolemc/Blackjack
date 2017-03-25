using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack

{
    class Program
    {
        static List<Card> deck = new List<Card>();
        static Card[] dealersHand, playersHand;
        static int numberOfCards = 52;
        static int playerScore = 0, dealerScore = 0, dealerShowingScore = 0;
        static bool playing, bust;
        static bool playerWin, dealerWin;
        static int currentCard = 0;
        static int counter = 0;
        static bool initialDeal = true;
        

        static void Main(string[] args)
        {
            GameGreeting();
            FillDeck();
            ShuffleDeck();
            FirstDealFromDeck();
            CompareDealerTotalValueWithPlayerTotalValue();
            
            Console.ReadLine();

        }


        static void GameGreeting()
        {
            //Game Greeting & Start Game
            Console.WriteLine("Welcome to McStanley's Black Jack. Would you like to play Black Jack? \nY/N");
            playing = Console.ReadLine().ToString().ToLower() == "y";
        }

        static void FillDeck()
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suits s in Enum.GetValues(typeof(Suits)))
                {
                    deck.Add(new Card(s, r));
                }
            }

        }

        static void ShuffleDeck()
        {

            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        static Card[] DealCards(int numOfCardsToDeal)
        {
            var chosenCards = deck.Take(numOfCardsToDeal).ToArray(); // chooses cards from deck
            deck = deck.Except(chosenCards).ToList(); // removes dealt cards from deck
            return chosenCards;

        }


        static void FirstDealFromDeck()
        {
            dealersHand = DealCards(2);
            playersHand = DealCards(2);

            Console.WriteLine("Your cards are:");

            foreach (var dealCard in playersHand)
            {
                 Console.WriteLine(dealCard);
                
            }
                               
        }

        public static int ConvertHandofCardsTotalValue(Card[] listToConvert)
        {
            var TotalValueofHand = 0;

            foreach (var CardIterate in listToConvert)
            {
                TotalValueofHand += CardIterate.GetCardValue();
            }
            return TotalValueofHand;

        }


        public static void CompareDealerTotalValueWithPlayerTotalValue()
        {

            playerScore = ConvertHandofCardsTotalValue(playersHand);
            dealerScore = ConvertHandofCardsTotalValue(dealersHand);
            dealerShowingScore = dealersHand[1].GetCardValue();
            Console.WriteLine($"Your current score is {playerScore}");
            
            if (initialDeal & playerScore == 21 & dealerScore == 21)
            {
                Console.WriteLine("Dealer's hand: ", dealersHand);
                Console.WriteLine("It's a draw. No one wins.");
                //updateStats("draw");
            }

            else if (initialDeal & playerScore == 21)
            {
               Console.WriteLine("BlackJack! You win.");
               Console.WriteLine();
               //updateStats("user");

            }
            
            else if (initialDeal & (!(playerScore == 21) & !(dealerScore == 21)) || (!(playerScore == 21) & dealerScore == 21))
            {
                Console.WriteLine("Dealer is showing:");
                Console.WriteLine($"{dealersHand[1]} ({dealerShowingScore})");
                
                Console.WriteLine("Lets Continue");
            }
            initialDeal = false;   //this is true the first time is runs through- then will switch to false on 2nd loop and all thereafter
        }


    }


}
