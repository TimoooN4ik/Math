using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Hand
    {
        public int Sum(string cardSet)
        {
            int sum = 0;
            string[] cards = cardSet.Split(' ');

            foreach(string card in cards)
            {
                if (card != "")
                {
                    if (card[0].ToString() == "J" || card[0].ToString() == "Q" || card[0].ToString() == "K")
                        sum += 10;
                    else if (card[0].ToString() == "A")
                    {
                        if (sum + 11 > 21)
                            sum++;
                        else
                            sum += 11;
                    }
                    else
                        sum += Convert.ToInt32(card[0].ToString());
                }
            }
            return sum;
        }
    }
}
