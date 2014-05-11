using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Othello
{
    class MaxPoints : Heuristic
    {

        public override Panel Move(Panel[,] Tiles)
        {
            return Tiles[0, 0];
        }
    }
}
