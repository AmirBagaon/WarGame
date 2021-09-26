using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * A player in the "War" game.
     * Can be used for other similar games.
     */
    public class Player
    {
        /*
         * Internally, the player has two piles of cards, a playing pile which
         * is his main pile, and a winning pile of cards he won. When the playing
         * pile becomes empty, player will switch to playing with the winning pile.
         *
         * Note that externally, player acts as if he has one pile, and the won cards
         * are added at the bottom of the pile.
         * The fact that there are two piles is an implementation detail that is not
         * visible to the outside!
         */
        private String name;
        private Pile playingPile;
        private Pile winPile;
        public Card LastPlayedCard = null;

        /**
         * Initialize a new player with no cards.
         * @param name Player's name.
         */
        public Player(String name)
        {
            this.name = name;
            this.playingPile = new Pile();
            this.winPile = new Pile();
        }

        /**
         * Converts a player to a string.
         * @return a string representation of the player.
         */
        public override string ToString()
        {
            return this.name;
        }

        /**
         * @return true if player has cards left.
         */
        public bool hasCards()
        {
            return (this.numOfCards() > 0);
        }

        /**
         * Number of cards player has.
         * @return number of cards the player has.
         */
        public int numOfCards()
        {
            return (this.playingPile.size() + this.winPile.size());
        }

        /**
         * Play the top card (the card is returned and removed from player).
         * @return the top card, or null if there are no cards.
         */
        public Card playTopCard()
        {
            Card top = this.getTopCard();
            if (top != null)
                LastPlayedCard = top;
            this.removeTopCard();
            return top;
        }

        /**
         * Looks at the top card.
         * @return the top card, or null if player has no cards.
         */
        public Card getTopCard()
        {
            if (!this.hasCards())
            {
                return null;
            }
            if (this.playingPile.isEmpty())
            {
                this.switchToWinningPile();
            }
            return this.playingPile.top();
        }

        /**
         * Removes the top card. Does nothing if no card exists.
         */
        public void removeTopCard()
        {
            if (!this.hasCards())
            {
                return;
            }
            if (this.playingPile.isEmpty())
            {
                this.switchToWinningPile();
            }
            this.playingPile.removeTop();
        }

        /**
         * Switch from using the playing pile to the winning pile.
         */
        private void switchToWinningPile()
        {
            this.winPile.reversePile();
            this.playingPile = this.winPile;
            this.winPile = new Pile();
        }

        /**
         * Collect winning cards.
         * Conceptually, won cards are added to the bottom of the pile.
         * @param pile a pile of winning cards to take.
         */
        public void collectWinningCards(Pile pile)
        {
            this.winPile.addCardsFromPile(pile);
        }

        /**
         * Collect a winning card.
         * Conceptually, the card is added to the bottom of the pile.
         * @param c the card to take.
         */
        public void collecWinningCard(Card c)
        {
            this.winPile.addCard(c);
        }

        /**
         * Collects a card. Conceptually, card is added to the top of the pile.
         * @param c card to take.
         */
        public void collectCard(Card c)
        {
            this.playingPile.addCard(c);
        }
    }

}
