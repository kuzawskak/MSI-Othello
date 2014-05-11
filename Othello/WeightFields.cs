using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Othello
{
    class WeightFields: Heuristic
    {
        public override Panel Move(Panel[,] Tiles)
        {
            return Tiles[0, 0];
        }
    }
}
