using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * A CardComparator compares two cards.
 */
    public interface ICardComparator
    {
        /**
         * @param c1 First card.
         * @param c2 Second card.
         * @return 0 if cards are of equal strength, \
         *         positive if this c1 is stronger, \
         *         negative if c2 is stronger
         */
        int compare(Card c1, Card c2);
    }
}
