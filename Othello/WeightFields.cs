using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Othello
{
    class WeightFields: Heuristic
    {
        public override int Evaluate(Panel[,] board, Player p,int tileCount)
        {
            return 0;
        }
    }
}
