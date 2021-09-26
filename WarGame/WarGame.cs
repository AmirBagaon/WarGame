using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    /**
 * The card game of "war".
 */
    public class WarGame
    {

        private IDealer dealer;
        private Player playerOne;
        private Player playerTwo;
        private int numRounds;
        private WarGameLogic logic;

        /**
         * Initilize a game form two player names. A default dealer and default
         * card comparator are used.
         *
         * @param playerOneName name of first player.
         * @param playerTwoName name of second player.
         */
        public WarGame(String playerOneName, String playerTwoName) : this(playerOneName, playerTwoName,
                 new HalfHalfDealer(), new WarGameCardComparator())
        {
            
        }

        /**
         * Initialize a game from two player names, a dealer and a card comparator.
         *
         * @param playerOneName name of first player.
         * @param playerTwoName name of second player.
         * @param dealer the dealer used to give cards to player.
         * @param cardCompare the card comparator strategy.
         */
        public WarGame(String playerOneName,
                       String playerTwoName,
                       IDealer dealer,
                       ICardComparator cardCompare)
        {
            this.logic = new WarGameLogic(cardCompare);
            this.dealer = dealer;
            this.playerOne = new Player(playerOneName);
            this.playerTwo = new Player(playerTwoName);
            this.numRounds = 0;
        }

        /**
         * Play a new game with at most a given number of rounds.
         * @param maxRounds maximum number of rounds to play.
         */
        public void play(int maxRounds)
        {
            this.numRounds = 0;
            this.dealer.deal(this.playerOne, this.playerTwo);
            while (!this.isGameOver() && this.numRounds < maxRounds)
            {
                Player winner = logic.playOneTurn(this.playerOne, this.playerTwo);
                //Console.WriteLine("Round winner is: " + winner);
                this.numRounds++;
            }
        }

        /**
         * Checks if game is over.
         * @return true if gave is over (if either player has no cards).
         */
        public bool isGameOver()
        {
            return !(this.playerOne.hasCards() && this.playerTwo.hasCards());
        }

        /**
         * Determine the current winner.
         * @return the playe with most cards, or null in case of a draw.
         */
        public Player getWinner()
        {
            if (this.playerOne.numOfCards() > this.playerTwo.numOfCards())
            {
                return this.playerOne;
            }
            else if (this.playerOne.numOfCards() < this.playerTwo.numOfCards())
            {
                return this.playerTwo;
            }
            else
            {
                return null;
            }
        }

        /**
         * Number of rounds already played.
         * @return numberOfRounds.
         */
        public int numberOfRounds()
        {
            return this.numRounds;
        }

        /**
         * Main method: Initialize and run a game, and announce the winner
         * and number of rounds.
         * @param args expected args[0] and args[1] to be names of players.
         */
        public static void run(String[] args)
        {
            String playerOneName = args[0];
            String playerTwoName = args[1];
            IDealer dealer = new HalfHalfDealer();
            ICardComparator cardCmp = new WarGameCardComparator();

            //Dealer dealer = new NCardsKDecksDealer(10, 3);
            //ICardComparator cardCmp = new RedWinsCardComparator();

            WarGame game = new WarGame(playerOneName, playerTwoName, dealer, cardCmp);
            game.play(100000);
            Player winner = game.getWinner();
            Console.WriteLine("The winner is: " + winner
                               + " with " + winner.numOfCards() + " cards.");
            Console.WriteLine("The game lasted: " + game.numberOfRounds()
                               + " rounds.");
        }
    }

}
