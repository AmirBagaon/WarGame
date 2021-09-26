using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A Dealer is in charge of distibuting cards to players.
 */
    public interface IDealer
    {

        /**
         * Distribute cards to the players.
         * @param p1 first player
         * @param p2 second player
         */
        void deal(Player p1, Player p2);
    }
}
