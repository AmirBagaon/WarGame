using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A WarGameCardComparator compares two cards according to default
 * card order.
 */
    public class WarGameCardComparator : ICardComparator
    {
   /**
    * @param c1 First card.
    * @param c2 Second card.
    * @return 0 if cards are of equal strength, \
    *         positive if this c1 is stronger, \
    *         negative if c2 is stronger
    */
   public int compare(Card c1, Card c2)
    {
        return c1.compareTo(c2);
    }
}

}
