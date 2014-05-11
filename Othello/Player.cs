using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    class Player
    {
        public string Color { get; set; }
        public string OpponentColor { get; set; }
        public Player Opponent;
        public int Points { get; set; }

        private Heuristic HeuristicFunc;

        public Panel Move(Panel[,] Tiles)
        {
            return HeuristicFunc.Move(Tiles);
        }

        public void setOpponent(Player opponent)
        {
            Opponent = opponent;
        }

        public Player(string heuristic,string color)
        {
            
            Color = color;
            OpponentColor = color == "W" ? "B" : "W";
           
            switch (heuristic)
            {
                case "MAX LICZBA PUNKTOW":
                    HeuristicFunc = new MaxPoints();
                    break;
                case "POLA WAŻONE":
                    HeuristicFunc = new WeightFields();
                    break;
                case "ZAJECIE NAROZNIKOW":
                    HeuristicFunc = new CornersOccupation();
                    break;
                case "OCENA STABILNOSCI":
                    HeuristicFunc = new StabilityFunc();
                    break;
                case "MIN LICZBA PUNKTOW":
                    HeuristicFunc = new MinPoints();
                    break;
                case "MOZLIWOSC PODJECIA RUCHU":
                    HeuristicFunc = new MoveAbility();
                    break;
            }
        }

      


    }
}
