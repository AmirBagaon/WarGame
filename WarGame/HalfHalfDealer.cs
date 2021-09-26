using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A Dealer is in charge of distibuting cards to players.
 * This dealer gives each of 2 player half of a shuffled deck.
 */
    public class HalfHalfDealer : IDealer
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
        // We know that a new deck has 52 cards, an even number.
        while (!deck.isEmpty())
        {
            p1.collectCard(deck.takeTopCard());
            p2.collectCard(deck.takeTopCard());
        }
    }
}

}
