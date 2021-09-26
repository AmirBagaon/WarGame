using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * Encapsulates the logic of the game of war (playing a single turn,
     * including a situation of a "war").
     */
    public class WarGameLogic
    {
        private ICardComparator cardCompare;

        /**
         * Create a WarGameLogic with the default card comparator.
         */
        public WarGameLogic()
        {
            this.cardCompare = new WarGameCardComparator();
        }

        /**
         * Create a WarGameLogic with the givne card comparator.
         * @param cardCompare the CardComparator to use.
         */
        public WarGameLogic(ICardComparator cardCompare)
        {
            this.cardCompare = cardCompare;
        }

        /**
         * Player one round and return the winner.
         * After the round, the winner has more cards and the loser has less.
         *
         * @param p1 the first player.
         * @param p2 the second player.
         * @return the winning player for this round (one of p1, p2)
         */
        public Player playOneTurn(Player p1, Player p2)
        {
            Pile pile = new Pile();
            Player winner = this.drawCardsAndAnnounceWinner(p1, p2, pile);
            winner.collectWinningCards(pile);
            return winner;
        }

        /**
         * Each player draws a card, and the winning player is returned.
         * The won cards are collected in pile.
         *
         * @param p1 the first player.
         * @param p2 the second player.
         * @param pile a pile of card to store the card to be won by the winner.
         * @return the winning player for this round (one of p1, p2)
         */
        private Player drawCardsAndAnnounceWinner(Player p1, Player p2, Pile pile, bool fromWar = false)
        {
            if (!p1.hasCards())
            {
                if (!fromWar)
                    return p2;
            }
            if (!p2.hasCards())
            {
                if (!fromWar)
                    return p1;
            }
            Card c1 = p1.playTopCard();
            if( c1 == null)
            {
                c1 = p1.LastPlayedCard;
            }
            Card c2 = p2.playTopCard();
            if (c2 == null)
            {
                c2 = p2.LastPlayedCard;
            }
            pile.addCard(c1);
            pile.addCard(c2);
            int compare = this.cardCompare.compare(c1, c2);
            if (compare == 0)
            {
                Console.WriteLine($"{c1} == {c2}, War!");
                return doWar(p1, p2, pile);
            }
            else if (compare > 0)
            {
                Console.WriteLine($"{c1} > {c2}, {p1} wins!");
                return p1;
            }
            else
            {
                Console.WriteLine($"{c1} < {c2}, {p2} wins!");
                return p2;
            }
        }

        /**
         * Handle the "War" scenario.
         * Each player adds two cards to the pile. Then they draw an extra
         * card, and the decide the winner (or initiate another round).
         * This method is recusrive with drawCardsAndAnnounceWinner().
         * The won cards are collected in pile.
         *
         * @param p1 the first player.
         * @param p2 the second player.
         * @param pile a pile of card to store the card to be won by the winner.
         * @return the winning player for this round (one of p1, p2)
         */
        private Player doWar(Player p1, Player p2, Pile pile)
        {
            //Console.WriteLine();
            Console.Write($"{p1} put:");
            for (int i = 0; i < 2; ++i)
            {
                Card c = p1.playTopCard();
                if (c != null)
                {
                    pile.addCard(c);
                    Console.Write($" {c}");
                    if ((i + 1) < 2)
                        Console.Write(",");
                }
            }
            Console.Write(". ");
            Console.Write($" {p2} put:");
            for (int i = 0; i < 2; ++i)
            {
                Card c = p2.playTopCard();
                if (c != null)
                {
                    pile.addCard(c);
                    Console.Write($" {c}");
                    if ((i + 1) < 2)
                        Console.Write(",");
                }
            }
            Console.Write(". Final Cards:");
            return this.drawCardsAndAnnounceWinner(p1, p2, pile, true);
        }

    }


}
