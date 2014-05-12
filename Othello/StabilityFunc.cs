﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Othello
{
    class StabilityFunc:Heuristic
    {
        public override int Evaluate(Panel[,] board, Player p,int tileCount)
        {
            List<Panel> white_panels = new List<Panel>();
            List<Panel> black_panels = new List<Panel>();

            for (int i = 0; i < tileCount; i++)
                for (int j = 0; j < tileCount; j++)
                {
                    if (board[i, j].Tag.ToString() == "W")
                        white_panels.Add(board[i, j]);
                    else if (board[i, j].Tag.ToString() == "B")
                        black_panels.Add(board[i, j]);

                }
            switch (p.Color)
            {
                case "W":
                    return white_panels.Capacity - black_panels.Capacity;
                case "B":
                    return black_panels.Capacity - white_panels.Capacity;
            }

            return 0;
        }
    }
}
