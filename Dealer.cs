using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneCardGameFinal
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First()); //adding card to hand
            Console.WriteLine(Deck.Cards.First().ToString() + "\n"); //the card we're putting into the deck
            Deck.Cards.RemoveAt(0);
        }
    }
}
