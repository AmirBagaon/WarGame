using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
    * A stack of playing cards.
    */
    public class StackOfCards
    {
        static int DEFAULT_NEW_STACK_SIZE = 52;

        // array of elements
        private Card[] cards;

        // number of elements in our stack
        private int numOfCards;

        /**
         * constructor with configurable max stack size.
         *
         * @param maxSize maximum number of elements in stack.
         */
        public StackOfCards(int maxSize)
        {
            // create a new array
            this.cards = new Card[maxSize];
            // initialize number of elements to 0 (empty stack)
            this.numOfCards = 0;
        }

        /**
         * constructor with default max stack size of 52 cards.
         */
        public StackOfCards() : this(DEFAULT_NEW_STACK_SIZE)
        {
            
        }

        /**
         * push a card into the stack.
         *
         * @param card the element to push into the stack.
         * @return 'true' if card was added to the stack, 'false' otherwise.
         */
        public bool push(Card card)
        {
            // check if we have space to add a new element,
            // and the element is indeed positive
            if (this.numOfCards < this.cards.Length)
            {
                // add the new element
                this.cards[this.numOfCards] = card;
                this.numOfCards += 1;
                // return success of adding the element
                return true;
            }
            else
            {
                // return failure since we have no more space left
                return false;
            }
        }

        /**
         * Pop element from the stack.
         *
         * @return top element, or EMPTY_STACK if nothing is the stack.
         */
        public Card pop()
        {
            // get the element on top of the stack
            Card top = this.top();
            this.removeTop();
            return top;
        }

        /**
         * Remove the top card.
         */
        public void removeTop()
        {
            if (this.numOfCards > 0)
            {
                this.numOfCards -= 1;
            }
        }

        /**
         * The top element in the stack.
         *
         * @return top element, or null if nothing is the stack.
         */
        public Card top()
        {
            // check if we have any elements in the stack
            if (this.numOfCards == 0)
            {
                // return an indication that the stack is empty
                return null;
            }
            else
            {
                // return the correct element
                return this.cards[this.numOfCards - 1];
            }
        }

        /**
         * The number of elements currently in the stack.
         *
         * @return number of elements.
         */
        public int size()
        {
            return this.numOfCards;
        }

        /**
         * Check if the stack is empty.
         *
         * @return 'true' if stack is empty, 'false' otherwise.
         */
        public bool isEmpty()
        {
            return size() == 0;
        }

    }

}
