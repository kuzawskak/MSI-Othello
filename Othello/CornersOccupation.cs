using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Othello
{
    class CornersOccupation:Heuristic
    {
        public override Panel Move(Panel[,] Tiles)
        {
            return Tiles[0, 0];
        }
    }
}
