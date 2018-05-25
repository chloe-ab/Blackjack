using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneCardGameFinal
{
    public class Player
    {
        public Player(string name, int beginningBalance)  //constructor
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }

        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }
        public static Game operator+ (Game game, Player player) //parameters are the 2 operands
        {
            game.Players.Add(player);
            return game;
        }
        public static Game operator- (Game game, Player player) //one of the parameters must be of the return type
        {
            game.Players.Remove(player);
            return game;
        }
    }
}
