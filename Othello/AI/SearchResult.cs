using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Othello.AI
{
    class SearchResult
    {

        public Point? Point { get; set; }
        public int Score { get; set; }
        public SearchResult negate()
        {
            return new SearchResult(Point, -Score);
        }
        public SearchResult(Point? point, int score)
        {
            if (point != null)
                Point = (Point)point;
            else Point = null;//new Point(-1, -1);
            Score = score;
        }
    }
}
