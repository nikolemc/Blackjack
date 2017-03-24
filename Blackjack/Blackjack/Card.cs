using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public Suits Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suits s, Rank r)
        {
            this.Suit = s;
            this.Rank = r;
        }

        public int GetCardValue()
        {
            var rv = 0;
            switch (this.Rank)
            {
                case Rank.ACE:
                    rv = 11;
                    break;
                case Rank.TWO:
                    rv = 2;
                    break;
                case Rank.THREE:
                    rv = 3;
                    break;
                case Rank.FOUR:
                    rv = 4;
                    break;
                case Rank.FIVE:
                    rv = 5;
                    break;
                case Rank.SIX:
                    rv = 6;
                    break;
                case Rank.SEVEN:
                    rv = 7;
                    break;
                case Rank.EIGHT:
                    rv = 8;
                    break;
                case Rank.NINE:
                    rv = 9;
                    break;
                case Rank.TEN:
                    rv = 10;
                    break;
                case Rank.JACK:
                    rv = 10;
                    break;
                case Rank.QUEEN:
                    rv = 10;
                    break;
                case Rank.KING:
                    rv = 10;
                    break;
                default:
                    break;
            }
            return rv;
        }
        public override string ToString()
        {
            return $"The {this.Rank} of {this.Suit}";
        }
    }
}