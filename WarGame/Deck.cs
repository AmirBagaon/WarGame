using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * A Deck of 52 playing Cards.
     */
    public class Deck
    {

        private Card[] cards;
        private int numCards;

        /**
         * Create a new deck with 52 cards (no jokers).
         */
        public Deck()
        {
            this.cards = new Card[52];
            this.fill();
        }

        /**
         * Initializes deck with 52 new cards.
         */
        private void fill()
        {
            int index = 0;
            for (int r = 1; r < 14; r++)
            {
                this.cards[index] = new Card(r, Card.DIAMOND);
                index++;
                this.cards[index] = new Card(r, Card.HEART);
                index++;
                this.cards[index] = new Card(r, Card.CLUB);
                index++;
                this.cards[index] = new Card(r, Card.SPADE);
                index++;
            }
            this.numCards = 52;
        }

        /**
         * @return number of cards remaining in the deck.
         */
        public int getSize()
        {
            return this.numCards;
        }

        /**
         * Look at the top card in the deck.
         * @return the top card in the deck, or null if deck is empty.
         */
        public Card topCard()
        {
            if (this.numCards == 0)
            {
                return null;
            }
            else
            {
                return this.cards[this.numCards - 1];
            }
        }

        /**
         * Removes the top card from the deck if there is one.
         */
        public void removeTop()
        {
            if (this.numCards == 0)
            {
                return;
            }
            else
            {
                this.numCards--;
            }
        }

        /**
         * Remove the top card and return it to caller.
         * A composition of topCard() and removeTop().
         *
         * @return the previously top card in the deck.
         */
        public Card takeTopCard()
        {
            Card top = this.topCard();
            this.removeTop();
            return top;
        }

        /**
         * @return true if the deck is empty.
         */
        public bool isEmpty()
        {
            return this.numCards == 0;
        }

        /**
         * Shuffle the cards.
         *
         * Using the Fisher-Yates shuffling algorithm.
         * (see http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle )
         */
        public void shuffle()
        {
            Random randomness = new Random();
            for (int last = this.numCards - 2; last > 0; last--)
            {
                // from 0 to last inclusive.
                int r = randomness.Next(last + 1);
                // exchange r and last
                Card tmp = this.cards[r];
                this.cards[r] = this.cards[last];
                this.cards[last] = tmp;
            }
        }
    }

}
