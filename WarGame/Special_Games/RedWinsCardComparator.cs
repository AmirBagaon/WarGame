using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A RedWinsCardComparator compares two cards: red wins over black.
 * If both same color, "regular" order is assumed.
 */
    public class RedWinsCardComparator : ICardComparator
    {
   /**
    * @param c1 First card.
    * @param c2 First card.
    * @return 0 if cards are of equal strength, \
    *         positive if this c1 is stronger, \
    *         negative if c2 is stronger
    */
   public int compare(Card c1, Card c2)
    {
        if (c1.isRed() && c2.isBlack())
        {
            return 1;
        }
        if (c2.isRed() && c1.isBlack())
        {
            return -1;
        }
        return c1.compareTo(c2);
    }
}

}
