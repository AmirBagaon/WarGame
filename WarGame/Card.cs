using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * A Playing card.
     */
    public class Card
    {
        public static int DIAMOND = 1;
        public static int HEART = 2;
        public static int SPADE = 3;
        public static int CLUB = 4;

        private static String[] SUITE_NAMES =
                  {"", "Diamonds", "Hearts", "Spades", "Clubs"};

        private int rank;
        private int suit;

        /**
         * Constructor.
         * @param rank can be 1 to 13
         * @param suit can be one of Card.DIAMOND Card.HEART Card.SPADE Card.CLUB
         */
        public Card(int rank, int suit)
        {
            if (rank < 1 || rank > 13 || suit < 1 || suit > 4)
            {
                throw new SystemException("Bad Card initialization value.");
            }
            this.rank = rank;
            this.suit = suit;
        }

        /**
         * Returns the rank of the card.
         * @return the card rank.
         */
        public int getRank()
        {
            return this.rank;
        }


        /**
         * @return true if suit is a Diamond.
         */
        public bool isDiamond()
        {
            return this.suit == Card.DIAMOND;
        }

        /**
         * @return true if suit is a Heart.
         */
        public bool isHeart()
        {
            return this.suit == Card.HEART;
        }

        /**
         * @return true if suit is a Spade.
         */
        public bool isSpade()
        {
            return this.suit == Card.SPADE;
        }

        /**
         * @return true if suit is a Club.
         */
        public bool isClub()
        {
            return this.suit == Card.CLUB;
        }

        /**
         * @return true if card is Red.
         */
        public bool isRed()
        {
            return (this.isHeart() || this.isDiamond());
        }

        /**
         * @return true if card is Black.
         */
        public bool isBlack()
        {
            return (!this.isRed());
        }

        /**
         * @return a string representation of this card.
         */
        public override String ToString()
        {
            String stringRank = "";
            if (this.rank == 1)
            {
                stringRank = "Ace";
            }
            else if (this.rank == 11)
            {
                stringRank = "Prince";
            }
            else if (this.rank == 12)
            {
                stringRank = "Queen";
            }
            else if (this.rank == 13)
            {
                stringRank = "King";
            }
            else
            {
                stringRank = this.rank.ToString();
            }
            return stringRank;
            //Optional - with SUITE NAME
            String cardName = stringRank + " of " + Card.SUITE_NAMES[this.suit];

            return cardName;
        }

        /**
         * Compare Cards in the order needed for the WAR card-game:
         * ignoring the suit and looking only at the rank.
         *
         * @param other the card to compare to.
         * @return 0 if cards are of equal strength, \
         *         positive if this card is stronger, \
         *         negative if other card is stronger
         */
        public int compareTo(Card other)
        {
            if (other == null)
            {
                return 1;
            }
            int thisRank = this.getRank();
            int otherRank = other.getRank();
            if (thisRank == 1)
            {
                thisRank = 14;
            }
            if (otherRank == 1)
            {
                otherRank = 14;
            }
            return thisRank - otherRank;
        }
    }

}
