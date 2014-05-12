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
        private int tileCount;
        public string Color { get; set; }
        public string OpponentColor { get; set; }
        public Player Opponent;
        public int Points { get; set; }
        private string heuristic;

        private Heuristic HeuristicFunc;

        public int Evaluate(Panel[,] Tiles)
        {
            return HeuristicFunc.Evaluate(Tiles, this, tileCount);
        }


        /// <summary>
        /// W tej chwili znamy przeciwnika, wiec takze jego heurystyke 
        /// (TODO: czy zmienic na to zeby f heurytycznej zalozyc ze maja taka sama funkcje??)
        /// </summary>
        /// <param name="opponent"></param>
        public void setOpponent(Player opponent)
        {
            Opponent = new Player(heuristic, opponent.Color, tileCount);
        }

        public Player(string heuristic, string color, int tileCount)
        {

            Color = color;
            OpponentColor = color == "W" ? "B" : "W";
            this.tileCount = tileCount;
            this.heuristic = heuristic;
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
                default:
                    HeuristicFunc = new MaxPoints();
                    break;
            }
        }
    }
}
