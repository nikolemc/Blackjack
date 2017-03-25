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
        static int currentCard = 0;
        static int counter = 0;
        static bool initialDeal = true;
        static bool player, dealer;
        string gameStatus;
       
     
        

        static void Main(string[] args)
        {
            GameGreeting();
            FillDeck();
            ShuffleDeck();
            FirstDealFromDeck();
            CompareDealerTotalValueWithPlayerTotalValue();
            PlayerContinuesPlayingGame();


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
            playersHand = DealCards(1);
            dealersHand = DealCards(1);
            playersHand = playersHand.Concat(DealCards(1)).ToArray();
            dealersHand = dealersHand.Concat(DealCards(1)).ToArray();

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
            dealerShowingScore = dealersHand[0].GetCardValue(); //Get the value of the dealers first card only
            Console.WriteLine($"Your current score is {playerScore}");
            
            if (initialDeal & playerScore == 21 & dealerScore == 21)
            {
                Console.WriteLine("Dealer's hand: ", dealersHand);
                Console.WriteLine("It's a draw. No one wins.");
                //GameStatus("draw");
            }

            else if (initialDeal & playerScore == 21)
            {
               Console.WriteLine("BlackJack! You win.");
               Console.WriteLine();
               
            }
            
            else if (initialDeal & (!(playerScore == 21) & !(dealerScore == 21)) || (!(playerScore == 21) & dealerScore == 21))
            {
                Console.WriteLine("Dealer is showing:");
                Console.WriteLine($"{dealersHand[0]} ({dealerShowingScore})"); //Show only the first card of the Dealers hand using [0]

            }
            initialDeal = false;   //this is true the first time is runs through- then will switch to false on 2nd loop and all thereafter
        }

        public static void PlayerContinuesPlayingGame()
        {

            do //do while loop for status "playing"
            {
                Console.WriteLine("Do you want anothter Card? (Y/N)");
                playing = Console.ReadLine().ToString().ToLower() == "y";

                if (playing)
                {
                    playersHand = playersHand.Concat(DealCards(1)).ToArray(); //deal another card to player
                    playerScore = ConvertHandofCardsTotalValue(playersHand);  //update players hand total score value.

                    if (playerScore > 21)
                    {
                        Console.WriteLine("Sorry you are bust!");
                        Console.WriteLine($"Your total score is {playerScore}");
                        playing = false;

                    }

                    else if (playerScore == 21 & !(dealerScore == 21))
                    {
                        Console.WriteLine("You win.");
                        playing = false;
                    }

                    Console.WriteLine("Your cards are:");

                    foreach (var dealCard in playersHand)
                    {
                        Console.WriteLine(dealCard);

                    }

                    if (playerScore < 21)
                    {
                        Console.WriteLine($"Your current score is {playerScore}");
                    }

                }

            }
            while (playing);
        }





    }


}
