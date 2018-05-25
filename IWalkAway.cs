using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneCardGameFinal
{
    interface IWalkAway  //say there's a legal regulation that any player should be allowed to walk away at any moment with their current balace
    {
        void WalkAway(Player player);
    }
}
