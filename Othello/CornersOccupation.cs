﻿using System;
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
        public override  int Evaluate(Panel[,] board, Player p,int tileCount)
        {
            return 0;
        }
    }
}
