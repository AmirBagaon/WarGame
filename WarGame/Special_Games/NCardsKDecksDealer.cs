using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{

    /**
     * A Dealer is in charge of distibuting cards to players.
     * This dealer gives each of 2 player N cards out of K decks.
     */
    public class NCardsKDecksDealer : IDealer
    {
   private int ncards;
    private int kdecks;

    /**
     * @param n how many cards to give each player.
     * @param k how many decks to use.
     */
    public NCardsKDecksDealer(int n, int k)
    {
        this.ncards = n;
        this.kdecks = k;
    }

    /**
     * Give each player N cards from K decks.
     * @param p1 first player
     * @param p2 second player
     */
    public void deal(Player p1, Player p2)
    {
        Random rand = new Random();
        int k = this.kdecks;
        Deck[] decks = new Deck[k];
        for (int i = 0; i < k; ++i)
        {
            decks[i] = new Deck();
            decks[i].shuffle();
        }
        for (int i = 0; i < this.ncards; ++i)
        {
            Deck deck = decks[rand.Next(k)];
            int d = rand.Next(k);
            p1.collectCard(decks[d].takeTopCard());
            d = rand.Next(k);
            p2.collectCard(decks[d].takeTopCard());
        }
    }
}

}
