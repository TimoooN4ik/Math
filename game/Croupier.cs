using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Croupier
    {
        Random rnd;
        string[,] gameStatus = new string[5, 6];                                           //0 - крупье, 1 -игрок, 2 - 1й бот, 3 - 2й бот, 4 - 3й бот
        //0 - карты на руке, 1 - ставка, 2 - сумма карт на руке, 3 - банк, 4 - имена, 5 - статус вин/луз

        Card card = new Card();
        Hand onHand = new Hand();
        Gamer u = new Gamer();
        Bot bot = new Bot();

        public int startGame(int playerBank)
        {
            gameStatus[0, 4] = "Croupier";
            gameStatus[1, 4] = "Player";
            gameStatus[2, 4] = "1st bot";
            gameStatus[3, 4] = "2nd bot";
            gameStatus[4, 4] = "3rd bot";

            gameStatus[1, 3] = playerBank.ToString();

            rnd = new Random();
            int minBid = 100;

            for (int i = 2; i < 5; i++)
                gameStatus[i, 3] = rnd.Next(minBid * 3, minBid * 30).ToString();

            gameStatus[0, 0] = card.dealCards();

            //ход игрока
            u.humanStrategy(1, minBid, gameStatus);

            //ход первого бота
            bot.firstBot(2, minBid, gameStatus);

            //ход второго бота
            bot.secondBot(3, minBid, gameStatus);

            //ход третьего бота
            bot.thirdBot(4, minBid, gameStatus);

            //крупье, конец игры
            croupierActs();

            printResult();

            return Convert.ToInt32(gameStatus[1, 1]);
        }

        void printResult()
        {
            int max = 0, winer = 0;
            //вывод результата. + сделать столбец выйграл проиграл, + столбец с именами крупье, игрок,...
            Console.WriteLine("\n" + gameStatus[0, 4] + " has cards sum " + gameStatus[0, 2] + ". Cards: " + gameStatus[0, 0] + "\n");
            for (int i = 0; i < 5; i++)
            {
                if (Convert.ToInt32(gameStatus[i, 2]) > max && Convert.ToInt32(gameStatus[i, 2]) < 22)
                {
                    max = Convert.ToInt32(gameStatus[i, 2]);
                    winer = i;// gameStatus[i, 4];
                }

                if (i != 0)
                    Console.WriteLine(gameStatus[i, 4] + " has cards sum " + gameStatus[i, 2] + " and bet " + gameStatus[i, 1]);
            }

            string res = "\nWinner is " + gameStatus[winer, 4];

            for (int i = 0; i < 5; i++)
                if (max == Convert.ToInt32(gameStatus[i, 2]) && i != winer)
                    res += " and " + gameStatus[i, 4];

            Console.WriteLine(res + "\n");
        }
        
        void croupierActs()
        {
            int border = rnd.Next(17, 21);
            int sumCroupies = onHand.Sum(gameStatus[0, 0]);

            Console.WriteLine("\nCroupier");
            while (sumCroupies < border)
            {
                gameStatus[0, 0] += " " + card.dealCards(1);
                sumCroupies = onHand.Sum(gameStatus[0, 0]);
            }
            Console.WriteLine("Amount of cards in croupier hand = " + sumCroupies + " ( " + gameStatus[0, 0] + ")");

            gameStatus[0, 2] = sumCroupies.ToString();

            Console.WriteLine();

        }
    }
}
