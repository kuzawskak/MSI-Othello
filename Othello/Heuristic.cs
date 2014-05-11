using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    class Heuristic
    {

        public virtual Panel Move(Panel[,] Tiles)
        {
            return Tiles[0, 0];
        }

    }
}
