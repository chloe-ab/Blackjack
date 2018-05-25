using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneCardGameFinal
{
    class TwentyOneRules
    {
        //private dictionary of card values
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,  //in twenty one, all face cards are worth 10
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };
        //returns an integer array which represents all possible hand values, depending on the number of aces in the hand.
        private static int[] GetAllPossibleHandValues(List<Card> Hand)  //this is needed because Ace can represent either a 1 or a 10
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);  //get the number of aces in the hand
            int[] result = new int[aceCount + 1];                //result array is (# of aces) + 1
            int value = Hand.Sum(x => _cardValues[x.Face]);      //sum the values of the cards in the hand
            result[0] = value;                                   //set that sum to the first item in the result array
            if (result.Length == 1) return result;               //if there are no aces, the result is complete, as the sum of the card values in the hand
            for (int i = 1; i < result.Length; i++)              //if there is at least one ace, 
            {                                                    // i (the counter) represents each ace in the hand
                value += (i * 10);                               //then the next integer in the result array is assigned; adding 10, not 11, 
                result[i] = value;                               //because the '1' of the Ace was already added in the Hand.Sum() method.
            }
            return result;                                       //the result array represents all the possible hand values depending on the number of aces;
        }                                                        //e.g. say hand = 3, ace, ace. result = [5, 15, 25]

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] possibleValues = GetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool isBusted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResults = GetAllPossibleHandValues(DealerHand);

            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;
            else return null;

        }
    }
}
