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
        static int playerScore = 0, dealerScore = 0;
        static bool playing, bust;
        static bool playerWin, dealerWin;
        static int currentCard = 0;
        static int counter = 0;
        
        static void Main(string[] args)
        {
            GameGreeting();
            FillDeck();
            ShuffleDeck();
             FirstDealFromDeck();



            //Console.WriteLine(randomDeck[1]);

            foreach (var dealCard in playersHand)
            {
                Console.WriteLine(dealCard);
            }

            foreach (var dealCard in dealersHand)
            {
                Console.WriteLine(dealCard);
            }
            //Console.WriteLine((int)dealersHand[1].Rank);
            //Console.WriteLine((int)dealersHand[2].Rank);
            //Console.WriteLine((int)dealersHand[1].Rank + (int)dealersHand[2].Rank);

            
            //Console.WriteLine((int)playersHand[1].Rank);
            //Console.WriteLine((int)playersHand[2].Rank);
            //Console.WriteLine((int)playersHand[1].Rank + (int)playersHand[2].Rank);

            //Console.WriteLine((int)deck[0].Rank);
            //Console.WriteLine((int)deck[1].Rank);
            //Console.WriteLine((int)deck[0].Rank + (int)deck[1].Rank);

            //foreach (var dealCard in deck)
            //{
            //    Console.WriteLine(dealCard);
            //    Console.WriteLine(dealCard.Rank);
            //    Console.WriteLine((int)dealCard.Rank);
            //}

            playerScore = ConvertHandofCardsTotalValue(playersHand);
            Console.WriteLine(playerScore);

            dealerScore = ConvertHandofCardsTotalValue(dealersHand);
            Console.WriteLine(dealerScore);



            //foreach (var dealCard in deck)
            //{
            //    Console.WriteLine(dealCard);
            //}

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

            // dealerScore = dealersHand.Sum(c => Card.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);
            //playerScore = playersHand.Sum(c => values.First(v => val(c) > 0 ? val(c).ToString() == v.cardName : c.StartsWith(v.cardName)).cardValue);

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
    }


}
