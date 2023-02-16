using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Bot : Gamer
    {
        Card card;
        Hand onHand;
        Random rnd;

        int secondBotFactor = 1, thirdBotFactor = 1;        //флаги, показывающие что бот сделал удовение ставки

        public string[,] firstBot(int person, int minBid, string[,] gameStatus)
        {
            Console.WriteLine("First bot");
            card = new Card();
            onHand = new Hand();
            rnd = new Random();

            string cardSet = "";
            int border = rnd.Next(16, 21), sum = 0;
            
            cardSet += " " + card.dealCards(2);
            sum = onHand.Sum(cardSet);

            while (sum < border)
            {
                cardSet += " " + card.dealCards(2);
                sum = onHand.Sum(cardSet);
            }
            Console.WriteLine("Amount of cards of 1st bot hand = " + sum + " (" + cardSet + ")");

            gameStatus[person, 2] = sum.ToString();
            gameStatus[person, 1] = rnd.Next(minBid, 1000).ToString();
            if (Convert.ToInt32(gameStatus[person, 2]) > 21)
                gameStatus[person, 5] = "Lose";
            if (Convert.ToInt32(gameStatus[person, 2]) == 21)
                gameStatus[person, 5] = "Win";

            return gameStatus;
        }

        public string[,] secondBot(int person, int minBid, string[,] gameStatus)
        {
            Console.WriteLine("\nSecond bot");
            card = new Card();
            onHand = new Hand();
            rnd = new Random();

            bool leave = false;
            int border = rnd.Next(16, 21), sum = 0;

            string cardSet = card.dealCards(3);
            sum = onHand.Sum(cardSet);

            while (sum < 21 && leave == false)
            {
                cardSet += " " + card.dealCards(3);
                sum = onHand.Sum(cardSet);
                
                if (gameStatus[0, 0] == "2")
                {
                    if (sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(3);
                        sum = onHand.Sum(cardSet);
                        secondBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 12)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "3")
                {
                    if (sum == 9 || sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(3);
                        sum = onHand.Sum(cardSet);
                        secondBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 12)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "4" || gameStatus[0, 0] == "5" || gameStatus[0, 0] == "6")
                {
                    if (sum == 9 || sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(3);
                        sum = onHand.Sum(cardSet);
                        secondBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 11)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "7" || gameStatus[0, 0] == "8" || gameStatus[0, 0] == "9")
                {
                    if (sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(3);
                        sum = onHand.Sum(cardSet);
                        secondBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 16)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "J" || gameStatus[0, 0] == "Q" || gameStatus[0, 0] == "K" || gameStatus[0, 0] == "A")
                {
                    if (sum == 11 && gameStatus[0, 0] != "A")
                    {
                        cardSet += " " + card.dealCards(3);
                        sum = onHand.Sum(cardSet);
                        secondBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 16)
                        leave = true;
                }
            }
            Console.WriteLine("Amount of cards on 2nd bot hand = " + sum + " (" + cardSet + ")");

            if (secondBotFactor == 2)
            {
                gameStatus[person, 2] = (sum).ToString();
                gameStatus[person, 1] = (rnd.Next(minBid, 1000) * 2).ToString();
            }
            else
            {
                gameStatus[person, 2] = sum.ToString();
                gameStatus[person, 1] = (rnd.Next(minBid, 1000)).ToString();
            }

            if (Convert.ToInt32(gameStatus[person, 2]) > 21)
                gameStatus[person, 5] = "Lose";
            if (Convert.ToInt32(gameStatus[person, 2]) == 21)
                gameStatus[person, 5] = "Win";

            return gameStatus;
        }

        public string[,] thirdBot(int person, int minBid, string[,] gameStatus)
        {
            Console.WriteLine("\nThird bot");
            card = new Card();
            onHand = new Hand();
            rnd = new Random();

            bool leave = false;
            int border = rnd.Next(16, 21), sum = 0;


            string cardSet = " " + card.dealCards(4);
            sum = onHand.Sum(cardSet);

            string[] cardOneByOne = cardSet.Split(' ');

            while (sum < 21 && leave == false)
            {
                cardSet += " " + card.dealCards(4);
                sum = onHand.Sum(cardSet);

                if (gameStatus[0, 0] == "2")
                {
                    if(stringConsistA(cardOneByOne) && sum > 17)
                    {
                        leave = true;
                    }
                    else if (sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 12)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "3")
                {
                    if (stringConsistA(cardOneByOne) && sum == 17)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (stringConsistA(cardOneByOne) && sum > 17)
                    {
                        leave = true;
                    }
                    else if (sum == 9 || sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 12)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "4")
                {
                    if (stringConsistA(cardOneByOne) && sum > 14 && sum < 18)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (stringConsistA(cardOneByOne) && sum > 17)
                    {
                        leave = true;
                    }
                    else if (sum == 9 || sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 11)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "5" || gameStatus[0, 0] == "6")
                {
                    if (stringConsistA(cardOneByOne) && sum > 12 && sum < 18)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (stringConsistA(cardOneByOne) && sum > 17)
                    {
                        leave = true;
                    }
                    else if (sum == 9 || sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 11)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "7" || gameStatus[0, 0] == "8" || gameStatus[0, 0] == "9")
                {
                    if (stringConsistA(cardOneByOne) && sum > 17)
                    {
                        leave = true;
                    }
                    else if (sum == 10 || sum == 11)
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 16)
                        leave = true;
                }
                else if (gameStatus[0, 0] == "J" || gameStatus[0, 0] == "Q" || gameStatus[0, 0] == "K" || gameStatus[0, 0] == "A")
                {
                    if (sum == 11 && gameStatus[0, 0] != "A")
                    {
                        cardSet += " " + card.dealCards(4);
                        sum = onHand.Sum(cardSet);
                        thirdBotFactor = 2;
                        leave = true;
                    }
                    else if (sum > 16)
                        leave = true;
                }
            }
            Console.WriteLine("Amount of cards on 3rd bot hand = " + sum + " (" + cardSet + ")");

            if (thirdBotFactor == 2)
            {
                gameStatus[person, 2] = (sum).ToString();
                gameStatus[person, 1] = (rnd.Next(minBid, 1000) * 2).ToString();
            }
            else
            {
                gameStatus[person, 2] = sum.ToString();
                gameStatus[person, 1] = (rnd.Next(minBid, 1000)).ToString();
            }
            if (Convert.ToInt32(gameStatus[person, 2]) > 21)
                gameStatus[person, 5] = "Lose";
            if (Convert.ToInt32(gameStatus[person, 2]) == 21)
                gameStatus[person, 5] = "Win";

            return gameStatus;
        }

        bool stringConsistA(string[] cards)
        {
            foreach (string card in cards)
                if (card == "A")
                    return true;
            return false;
        }
    }
}
