using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * A Dealer is in charge of distibuting cards to players.
     * This dealer gives each of 2 player half of a shuffled deck -- player 1 gets
     * all the red cards, player 2 all the black ones.
     */
    public class RedBlackDealer : IDealer
    {

   /**
    * Give each player half a shuffled deck.
    * @param p1 first player
    * @param p2 second player
    */
   public void deal(Player p1, Player p2)
    {
        Deck deck = new Deck();
        deck.shuffle();
        while (!deck.isEmpty())
        {
            Card c = deck.takeTopCard();
            if (c.isRed())
            {
                p1.collectCard(c);
            }
            else
            {
                p2.collectCard(c);
            }
        }
    }
}

}
