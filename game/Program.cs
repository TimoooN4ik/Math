using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            int bank = 283;

            do
            {
                Console.Clear();
                Croupier leader = new Croupier();
                bank -= leader.startGame(bank);

                Console.WriteLine("\nIf you want play one more press Enter\n");
                key = Console.ReadKey();
            }
            while (key.Key == ConsoleKey.Enter && bank > 100);

            if(bank < 100)
                Console.WriteLine("\nOps... you lost all your money XD\n");
            Console.ReadLine();
        }
    }
}
