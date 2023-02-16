using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Card
    {
        Random rnd;
        public string dealCards()
        {
            rnd = new Random();
            string s = "♠♥♦♣";

            System.Threading.Thread.Sleep(250);
            int value = rnd.Next(2, 14);
            System.Threading.Thread.Sleep(250);
            int suit = rnd.Next(0, 4);

            string card = "";

            switch (value)
            {
                case 11:
                    card = "J" + s[suit];
                    Console.WriteLine("The dealer's first card: " + card);
                    break;
                case 12:
                    card = "Q" + s[suit];
                    Console.WriteLine("The dealer's first card: " + card);
                    break;
                case 13:
                    card = "K" + s[suit];
                    Console.WriteLine("The dealer's first card: " + card);
                    break;
                case 14:
                    card = "A" + s[suit];
                    Console.WriteLine("The dealer's first card: " + card);
                    break;
                default:
                    card = value.ToString() + s[suit];
                    Console.WriteLine("The dealer's first card: " + card);
                    break;
            }

            return card;
        }

        public string dealCards(int playerNumber)
        {
            rnd = new Random();
            string s = "♠♥♦♣";

            System.Threading.Thread.Sleep(250);
            int value = rnd.Next(2, 14);
            System.Threading.Thread.Sleep(250);
            int suit = rnd.Next(0, 4);

            string card = "";

            switch (value)
            {
                case 11:
                    card = "J" + s[suit];
                    Console.WriteLine("Card: " + card);
                    break;
                case 12:
                    card = "Q" + s[suit];
                    Console.WriteLine("Card: " + card);
                    break;
                case 13:
                    card = "K" + s[suit];
                    Console.WriteLine("Card: " + card);
                    break;
                case 14:
                    card = "A" + s[suit];
                    Console.WriteLine("Card: " + card);
                    break;
                default:
                    card = value.ToString() + s[suit];
                    Console.WriteLine("Card: " + card);
                    break;
            }

            return card;
        }
    }
}
