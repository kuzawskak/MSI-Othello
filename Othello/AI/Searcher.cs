using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Othello.AI
{
    class Searcher
    {
        int tileSize;
        int tileCount;
        public Searcher(int tileSize, int tileCount)
        {
            this.tileSize = tileSize;
            this.tileCount = tileCount;
        }

        int PlayersDiffCount(Panel[,] board, Player p)
        {

            int count = 0;
            for (int i = 0; i < tileCount; i++)
                for (int j = 0; j < tileCount; j++)
                {
                    if (board[i, j].Tag.ToString() == p.Color)
                        count++;
                    else if (board[i, j].Tag.ToString() == p.OpponentColor)
                        count--;
                }
            return count;
        }

        int whitePlayersCount(Panel[,] board)
        {
            List<Panel> black_panels = new List<Panel>();
            for (int i = 0; i < tileCount; i++)
                for (int j = 0; j < tileCount; j++)
                {
                    if (board[i, j].Tag.ToString() == "B")
                        black_panels.Add(board[i, j]);
                }
            return black_panels.Capacity;
        }

        int Evaluate(Panel[,] board, Player p)
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



        private bool isEndState(Panel[,] board)
        {
            int full_capacity = (tileCount * tileCount * 5) / 9;
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

            return white_panels.Capacity + black_panels.Capacity == full_capacity || white_panels.Capacity == 0 || black_panels.Capacity == 0;

        }


     



        bool checkIfAvailable(Panel[,] Tiles, Panel p, string tag)
        {
            if (p.Tag.ToString() != "G" ) return false;
            int x = p.Location.X / tileSize;
            int y = p.Location.Y / tileSize;
            int i, j;
            bool avail = false;
            int key = (int)Enum.Parse(typeof(Turn), tag);
            Turn opposite = (Turn)((key + 1) % 2);
            String opposite_tag = opposite.ToString();
            bool result = false;
            //pion
            for (i = y + 1; i < tileCount; i++)
            {
                if (Tiles[x, i].Tag.ToString() == "E" || Tiles[x, i].Tag.ToString() == "G" ||
               (Tiles[x, i].Tag.ToString() == tag && !avail)) { result = false; break; }

                if (Tiles[x, i].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[x, i].Tag.ToString() == tag && avail)
                {
                    return true;
                }

            }
            avail = false;
            for (i = y - 1; i > 0; i--)
            {
                if (Tiles[x, i].Tag.ToString() == "E" || Tiles[x, i].Tag.ToString() == "G" ||
               (Tiles[x, i].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[x, i].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[x, i].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }

            avail = false;
            //poziom
            for (i = x + 1; i < tileCount; i++)
            {
                if (Tiles[i, y].Tag.ToString() == "E" || Tiles[i, y].Tag.ToString() == "G" ||
               (Tiles[i, y].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, y].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, y].Tag.ToString() == tag && avail)
                {
                    return true;
                }

            }
            avail = false;
            for (i = x - 1; i > 0; i--)
            {
                if (Tiles[i, y].Tag.ToString() == "E" || Tiles[i, y].Tag.ToString() == "G" ||
               (Tiles[i, y].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, y].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, y].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }
            //skos
            avail = false;
            for (i = x + 1, j = y + 1; i < tileCount && j < tileCount; i++, j++)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }
            avail = false;
            for (i = x + 1, j = y - 1; i < tileCount && j > 0; i++, j--)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }
            avail = false;
            for (i = x - 1, j = y + 1; i > 0 && j < tileCount; i--, j++)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }
            avail = false;
            for (i = x - 1, j = y - 1; i > 0 && j > 0; i--, j--)
            {

                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { result = false; break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    return true;
                }
            }

            return result;

        }



        List<Point> Explore(Panel[,] board, string color)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < tileCount; i++)
                for (int j = 0; j < tileCount; j++)
                {
                    if (board[i, j].Tag.ToString() == "G")
                    {
                        if (checkIfAvailable(board, board[i, j], color))
                        {
                            points.Add(new Point(board[i, j].Location.X / tileSize, board[i, j].Location.Y / tileSize));
                        }
                    }
                }
            return points;
        }

        public void makeMove(ref Panel[,] board, Point p, string color)
        {
            int x = p.X;
            int y = p.Y;

            Panel panel = board[p.X, p.Y];

            if (color == "W")
            {
                panel.Tag = "W";
            }
            else
            {
                panel.Tag = "B";
            }


            int i, j;
            int y_down = -1;
            int y_up = -1;
            int x_left = -1;
            int x_right = -1;
            int x_up_right = -1;
            int y_up_right = -1;
            int x_down_right = -1;
            int y_down_right = -1;
            int x_up_left = -1;
            int y_up_left = -1;
            int x_down_left = -1;
            int y_down_left = -1;


            //pion
            for (i = y + 1; i < tileCount; i++)
            {
                if (board[x, i].Tag.ToString() == "E") break;
                if (board[x, i].Tag.ToString() == color)
                {
                    y_down = i;
                    break;
                }
            }

            for (i = y - 1; i > 0; i--)
            {
                if (board[x, i].Tag.ToString() == "E") break;
                if (board[x, i].Tag.ToString() == color)
                {
                    y_up = i;
                    break;
                }
            }


            //poziom
            for (i = x + 1; i < tileCount; i++)
            {
                if (board[i, y].Tag.ToString() == "E") break;
                if (board[i, y].Tag.ToString() == color)
                {
                    x_right = i;
                    break;
                }
            }

            for (i = x - 1; i > 0; i--)
            {
                if (board[i, y].Tag.ToString() == "E") break;
                if (board[i, y].Tag.ToString() == color)
                {
                    x_left = i;
                    break;
                }
            }
            //skos

            for (i = x + 1, j = y + 1; i < tileCount && j < tileCount; i++, j++)
            {
                if (board[i, j].Tag.ToString() == "E") break;
                if (board[i, j].Tag.ToString() == color)
                {
                    x_down_right = i;
                    y_down_right = j;
                    break;
                }
            }

            for (i = x + 1, j = y - 1; i < tileCount && j > 0; i++, j--)
            {
                if (board[i, j].Tag.ToString() == "E") break;
                if (board[i, j].Tag.ToString() == color)
                {
                    x_up_right = i;
                    y_up_right = j;
                    break;
                }
            }

            for (i = x - 1, j = y + 1; i > 0 && j < tileCount; i--, j++)
            {
                if (board[i, j].Tag.ToString() == "E") break;
                if (board[i, j].Tag.ToString() == color)
                {
                    x_down_left = i;
                    y_down_left = j;
                    break;
                }
            }
            for (i = x - 1, j = y - 1; i > 0 && j > 0; i--, j--)
            {

                if (board[i, j].Tag.ToString() == "E") break;
                else if (board[i, j].Tag.ToString() == color)
                {
                    x_up_left = i;
                    y_up_left = j;
                    break;
                }
            }

            //Reverse
            if (y_down >= 0)
            {
                for (i = y + 1; i < y_down; i++)
                {
                    board[x, i].Tag = color;

                }
            }
            if (y_up >= 0)
            {
                for (i = y - 1; i > y_up; i--)
                {
                    board[x, i].Tag = color;


                }
            }
            if (x_right >= 0)
            {
                for (i = x + 1; i < x_right; i++)
                {
                    board[i, y].Tag = color;


                }
            }
            if (x_left >= 0)
            {
                for (i = x - 1; i > x_left; i--)
                {
                    board[i, y].Tag = color;


                }
            }

            if (x_up_left >= 0)
            {
                for (i = x - 1, j = y - 1; i > x_up_left && j > y_up_left; i--, j--)
                {
                    board[i, j].Tag = color;

                }
            }
            if (x_up_right >= 0)
            {
                for (i = x + 1, j = y - 1; i < x_up_right && j > y_up_right; i++, j--)
                {
                    board[i, j].Tag = color;
                }
            }
            if (x_down_left >= 0)
            {
                for (i = x - 1, j = y + 1; i > x_down_left && j < y_down_left; i--, j++)
                {
                    board[i, j].Tag = color;

                }
            }
            if (x_down_right >= 0)
            {
                for (i = x + 1, j = y + 1; i < x_down_right && j < y_down_right; i++, j++)
                {
                    board[i, j].Tag = color;
                }
            }


        }

        public SearchResult Search(Panel[,] board, Player player, int alpha, int beta, int depth)
        {
            if (depth <= 0 || isEndState(board))
            {
                return new SearchResult(null, Evaluate(board, player));
            }
            else /* wiecej do sparwdzenia*/
            {
                List<Point> possible_moves = Explore(board, player.Color);
                SearchResult best = new SearchResult(null, alpha);
                if (possible_moves.Capacity == 0)
                {
                    /* turn is lost  - chceck next player*/
                    possible_moves = Explore(board, player.OpponentColor);
                    if (possible_moves.Capacity == 0)
                    {
                        //koniec gry - psrawdzenie czy jest zwyciezca
                        switch (Math.Sign(PlayersDiffCount(board, player)))
                        {
                            case -1:
                                best = new SearchResult(null, Int16.MinValue);
                                break;
                            case 0:
                                best = new SearchResult(null, 0);
                                break;
                            case 1:
                                best = new SearchResult(null, Int16.MaxValue);
                                break;
                        }

                    }
                    else
                    { /* gra trwa nadal - brak ruchow do sprawdzenia*/
                        best = Search(board, player.Opponent, -beta, -alpha, depth - 1);
                    }
                }
                else
                {//spardzenie wyniku dla kazdego ruchu na liscie

                    foreach (Point p in possible_moves)
                    {
                        Panel[,] subBoard = new Panel[tileCount, tileCount];
                        for(int i=0;i<tileCount;i++)
                            for (int j = 0; j < tileCount; j++)
                            {
                                subBoard[i, j] = new Panel();
                                subBoard[i, j].Bounds = board[i, j].Bounds;
                                subBoard[i, j].Tag = board[i, j].Tag;

                            }
                           // (Panel[,])board.Clone();
                        makeMove(ref subBoard, p, player.Color);
                        int score = Search(subBoard, player.Opponent, -beta, -alpha, depth - 1).Score;
                        if (alpha < score)
                        {
                            alpha = score;
                            best = new SearchResult(p, score);
                        }
                        /**alpha beta prunning**/
                        if (alpha >= beta)
                        {
                            return best;
                        }
                    }

                }
                return best;

            }
        }


        public SearchResult simpleSearch(Panel[,] board, Player player, int depth)
        {
            if (depth <= 0 || isEndState(board))
            {
                return new SearchResult(null, Evaluate(board, player));
            }
            else
            {
                List<Point> possible_moves = Explore(board, player.Color);
                SearchResult best = new SearchResult(null, Int16.MinValue);
                if (possible_moves.Capacity == 0)
                {
                    possible_moves = Explore(board, player.OpponentColor);
                    if (possible_moves.Capacity == 0)
                    {
                        switch (Math.Sign(PlayersDiffCount(board, player)))
                        {
                            case -1:
                                best = new SearchResult(null, Int16.MinValue);
                                break;
                            case 0:
                                best = new SearchResult(null, 0);
                                break;
                            case 1:
                                best = new SearchResult(null, Int16.MaxValue);
                                break;
                        }


                    }
                    else
                    {
                        best = simpleSearch(board, player.Opponent, depth - 1);
                    }
                }
                else
                {
                    foreach (Point p in possible_moves)
                    {
                        //Panel[,] subBoard = (Panel[,])board.Clone();
                        Panel[,] subBoard = new Panel[tileCount, tileCount];
                        for (int i = 0; i < tileCount; i++)
                            for (int j = 0; j < tileCount; j++)
                            {
                                subBoard[i, j] = new Panel();
                                subBoard[i, j].Bounds = board[i, j].Bounds;
                                subBoard[i, j].Tag = board[i, j].Tag;

                            }
                        makeMove(ref subBoard, p, player.Color);
                        int score = simpleSearch(subBoard, player.Opponent, depth - 1).Score;
                        if (best.Score < score)
                        {
                            best = new SearchResult(p, score);
                        }

                    }
                }
                return best;
            }

        }
    }
}

