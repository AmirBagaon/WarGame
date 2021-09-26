using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A pile (collection) of cards.
 * Acts like a stack (add to top, take from top), but can also be reversed.
 */
    public class Pile
    {

        private StackOfCards cards;

        /**
         * Create a new empty pile.
         */
        public Pile()
        {
            this.cards = new StackOfCards();
        }

        /**
         * Pile size.
         *
         * @return number of cards.
         */
        public int size()
        {
            return this.cards.size();
        }

        /**
         * Top card in pile.
         *
         * @return top card in pile.
         */
        public Card top()
        {
            return this.cards.top();
        }

        /**
         * Removes the top card from the pile.
         */
        public void removeTop()
        {
            this.cards.removeTop();
        }

        /**
         * @return true iff pile is empty.
         */
        public bool isEmpty()
        {
            return this.cards.isEmpty();
        }

        /**
         * Reverses the order of the cards in the pile.
         */
        public void reversePile()
        {
            StackOfCards newStack = new StackOfCards();
            while (!this.cards.isEmpty())
            {
                newStack.push(this.cards.pop());
            }
            this.cards = newStack;
        }

        /**
         * Add card to top of pile.
         * @param c card to add.
         */
        public void addCard(Card c)
        {
            this.cards.push(c);
        }

        /**
         * Add all the cards from the given pile.
         * @param other pile to add cards from.
         */
        public void addCardsFromPile(Pile other)
        {
            while (!other.isEmpty())
            {
                this.cards.push(other.top());
                other.removeTop();
            }
        }
    }



}
