using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Gamer
    {
        public string[,] humanStrategy(int person, int minBid, string[,] gameStatus)
        {
            Card card = new Card();
            Hand onHand = new Hand();

            int sum = 0;
            ConsoleKeyInfo key;
            gameStatus[person, 1] = placeBet(Convert.ToInt32(gameStatus[person, 3]), minBid).ToString();

            gameStatus[person, 3] = (Convert.ToInt32(gameStatus[person, 3]) - Convert.ToInt32(gameStatus[person, 1])).ToString();

            gameStatus[person, 0] += card.dealCards(1) + " ";
            sum = onHand.Sum(gameStatus[person, 0]);

            do
            {
                gameStatus[person, 0] += card.dealCards(1) + " ";
                sum = onHand.Sum(gameStatus[person, 0]);

                Console.WriteLine("Amount of cards in your hand = " + sum + " ( " + gameStatus[person, 0] + ")");

                Console.WriteLine("Deal next card: +\nDouble down: *\nStop: Enter");

                key = Console.ReadKey();
                Console.WriteLine("\n");

                if (key.Key == ConsoleKey.Multiply)
                {
                    Console.WriteLine("Double down");
                    int doubleBet = Convert.ToInt32(gameStatus[person, 1]) * 2;
                    gameStatus[person, 1] = doubleBet.ToString();

                    gameStatus[person, 0] += card.dealCards(1) + " ";
                    sum = onHand.Sum(gameStatus[person, 0]);

                    Console.WriteLine("Amount of cards in your hand = " + sum + " ( " + gameStatus[person, 0] + ")");
                    break;
                }
            }
            while (key.Key != ConsoleKey.Enter && sum < 21);

            if (sum == 21)
                Console.WriteLine("BlackJack!");

            gameStatus[person, 2] = sum.ToString();

            return gameStatus;
        }
        public int placeBet(int bank, int minBid)
        {
            int gamerBet = 0;
            do
            {
                Console.WriteLine("Minimal bet = " + minBid + ". Place your bet. Ur bank = " + bank);
                try
                {
                    gamerBet = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error. Place ur bet again");
                    gamerBet = 0;
                    continue;
                }

                if(gamerBet < minBid)
                {
                    Console.WriteLine("Your bid is less than the minimum. Repeat input");
                    gamerBet = 0;
                }

                if(gamerBet > bank)
                {
                    Console.WriteLine("Your bid is more than your bank. Repeat input");
                    gamerBet = 0;
                }
            }
            while (gamerBet == 0);

            return gamerBet;
        }

        int nextAction()
        {
            return 0;
        }
    }
}
