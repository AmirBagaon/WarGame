using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: need to supply two player names.");
                //return;
            }
            //WarGame game = new WarGame(args[0], args[1]);
            string[] names = new string [] { "A", "B" };
            WarGame.run(names);
        }
    }
}
