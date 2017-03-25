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
        static bool playing, dealerDrawing, playerDrawing;
        static int currentCard = 0;
        static int counter = 0;
        static bool player, dealer;
        string gameStatus;
       
     
        

        static void Main(string[] args)
        {
            GameGreeting();
            FillDeck();
            ShuffleDeck();
            FirstDealFromDeck();
            CompareScoresAfterInitialDeal();
            PlayerDrawsCards();
            DealerDrawsCards();
            DetermineOutcome();


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


        public static void CompareScoresAfterInitialDeal()
        {

            playerScore = ConvertHandofCardsTotalValue(playersHand);
            dealerScore = ConvertHandofCardsTotalValue(dealersHand);
            dealerShowingScore = dealersHand[0].GetCardValue(); //Get the value of the dealers first card only
            Console.WriteLine($"Your current score is {playerScore}");
            
            if (playerScore == 21 & dealerScore == 21)
            {
                Console.WriteLine("It's a draw. No one wins.");
                playing = false;
            }

            else if (playerScore == 21)
            {
               Console.WriteLine("BlackJack! You win.");
               playing = false;
            }
            
            else if ((!(playerScore == 21) & !(dealerScore == 21)) || (!(playerScore == 21) & dealerScore == 21))
            {
                Console.WriteLine("Dealer is showing:");
                Console.WriteLine($"{dealersHand[0]} ({dealerShowingScore})"); //Show only the first card of the Dealers hand using [0]

            }
            
        }

        public static void PlayerDrawsCards()
        {

            do //do while loop for status "playing"
            {
                Console.WriteLine("Do you want anothter Card? (Y/N)");
                playerDrawing = Console.ReadLine().ToString().ToLower() == "y";

                if (playerDrawing)
                {
                    playersHand = playersHand.Concat(DealCards(1)).ToArray(); //deal another card to player
                    playerScore = ConvertHandofCardsTotalValue(playersHand);  //update players hand total score value.

                    Console.WriteLine("Your cards are:");

                    foreach (var dealCard in playersHand)
                    {
                        Console.WriteLine(dealCard);

                    }
                    Console.WriteLine($"Your total score is {playerScore}");

                    if (playerScore > 21)
                    {
                        Console.WriteLine("Sorry you are bust!");
                        playerDrawing = false;
                        playing = false;

                    }

                    else if (playerScore == 21 & !(dealerScore == 21))
                    {
                        Console.WriteLine("You win.");
                        playerDrawing = false;
                        playing = false;
                    }
                                      

                    
                }

            }
            while (playerDrawing);

        
        }

        public static void DealerDrawsCards()
        {
            dealerDrawing = true;
            if (playing)
            {

                do
                {
                    dealersHand = dealersHand.Concat(DealCards(1)).ToArray(); //deal another card to dealer
                    dealerScore = ConvertHandofCardsTotalValue(dealersHand);  //update dealers hand total score value.

                    if (dealerScore > 16)
                    {
                        dealerDrawing = false; 
                    }

                } while (dealerDrawing);
            }
        }

        public static void DetermineOutcome()
        {
            if (playing)
            {
                //logic for who wins

                if (playerScore ==  dealerScore)
                {
                    Console.WriteLine("It's a draw. No one wins.");
                  
                }

                else if (dealerScore > 21)
                {
                    Console.WriteLine("Dealer Bust! You win.");
                   
                }

                else if (playerScore > dealerScore)
                {
                    Console.WriteLine("You Win!");
                 
                }

                else
                {
                    Console.WriteLine("You Lose");
                }
            }

            
                Console.WriteLine("The dealers cards were:");

                foreach (var dealCard in dealersHand)
                {
                    Console.WriteLine(dealCard);

                }
                Console.WriteLine($"Dealers score was {dealerScore}");


        }


    }


}
