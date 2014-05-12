using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Othello.AI;

namespace Othello
{
    public enum Turn { W, B };
    class Game
    {
        Semaphore WhiteSemaphore;
        Semaphore BlackSemaphore;
        bool game_on = true;
        Searcher searcher;
        /// <summary>
        /// Ktory gracz ma ruch
        /// </summary>
        Turn turn;
        /// <summary>
        /// Gracz z białymi pionkami
        /// </summary>
        private Player whitePlayer;
        /// <summary>
        /// Gracz z czarnymi pionkami
        /// </summary>
        private Player blackPlayer;
        /// <summary>
        /// Rozmiar planszy - jesli n  to ma postac 5 kwadratow o boku n/3 ulozonych w krzyz
        /// </summary>
        private int boardSize;
        /// <summary>
        /// Panel gry
        /// </summary>
        Game_Panel gamePanel;
        /// <summary>
        /// Tablica paneli reprezentujaca planszę
        /// Kazdy z paneli posiada wartość Tag:
        /// B - black (pola zajete przez czarne pionki)
        /// W - White (pola zajete przez biale pionki)
        /// G - pole zielone (nie zajete - mozna stawiac pionki jesli jest w sasiedztwie zajetych i prowadzi do zmiany wyniku)
        /// E - empty (czarne pole - nie ma znaczenia w grze)
        /// 
        /// Tagi sa uzytyeczne przy wyborze punktu do ruchu
        /// W funkcji heurytycznej WYBIERAMY TYLKO SPOSROD POL OZNACZONY jako ZIELONE (G)
        /// 
        /// </summary>
        private Panel[,] Tiles;
        /// <summary>
        /// Rozmiar pojedynczego panelu na planszy
        /// </summary>
        private int tileSize;


        /// <summary>
        /// jesli jest wlaczony modul testowy - gramy za pomoca klikania myszka (bez uzycia heurystyk)
        /// jesli nie - uzywamy heurystyk dla ruchow graczy 
        /// </summary>      
        private bool test_mode;

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_Panel));

        public Game(Game_Panel gamePanel, int boardSize, string FuncW, string FuncB, bool test_mode)
        {
            WhiteSemaphore = new Semaphore(0, 1);
            BlackSemaphore = new Semaphore(1, 1);
            whitePlayer = new Player(FuncW, "W");
            blackPlayer = new Player(FuncB, "B");
            whitePlayer.setOpponent(blackPlayer);
            blackPlayer.setOpponent(whitePlayer);

            this.gamePanel = gamePanel;
            this.boardSize = boardSize;
            this.test_mode = test_mode;
            ///z zasad gry: Czarny zawsze zaczyna gre!
            turn = Turn.B;

            int squareSize = boardSize / 3;
            tileSize = (gamePanel.gameBoard.Width) / boardSize;
            int gridSize = boardSize;
            int half = gridSize / 2;

            // inicjalizacja planszy
            Tiles = new Panel[gridSize, gridSize];

            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m)
                    };

                    Tiles[n, m] = newPanel;

                    // color the backgrounds
                    if (n % 2 == 0)
                    {
                        newPanel.BackgroundImage = (System.Drawing.Image)(Image.FromFile("GreenField.png"));
                        newPanel.Tag = "G";
                    }
                    else
                    {
                        newPanel.BackgroundImage = (System.Drawing.Image)(Image.FromFile("GreenField.png"));
                        newPanel.Tag = "G";
                    }
                    newPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    if ((n < squareSize && m < squareSize) || (n >= 2 * squareSize && m >= 2 * squareSize) || (n < squareSize && m >= 2 * squareSize) || (m < squareSize && n >= 2 * squareSize))
                    {
                        newPanel.BackgroundImage = (System.Drawing.Image)(Image.FromFile("EmptyField.png"));
                        newPanel.Tag = "E";
                    }

                    gamePanel.gameBoard.Controls.Add(newPanel);
                }
            }

            ///ustawienie 4 pionkow na srodku planszy
            Panel p = Tiles[half, half];
            p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("WField.png"));
            p.Tag = "W";
            p = Tiles[half - 1, half - 1];
            whitePlayer.Points++;
            p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("WField.png"));
            p.Tag = "W";
            whitePlayer.Points++;
            p = Tiles[half, half - 1];
            p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("BlackField.png"));
            p.Tag = "B";
            blackPlayer.Points++;
            p = Tiles[half - 1, half];
            p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("BlackField.png"));
            p.Tag = "B";
            blackPlayer.Points++;

            //TEST MODE - testowanie interakcji GUI z logiką gry (naprzemienne klikanie myszką pol)
            if (test_mode)
            {
                for (var n = 0; n < gridSize; n++)
                {
                    for (var m = 0; m < gridSize; m++)
                    {
                        if (Tiles[n, m].Tag.ToString() == "G")
                        {
                            this.Tiles[n, m].Click += new System.EventHandler(this.Tile_Click);
                            this.Tiles[n, m].MouseEnter += new System.EventHandler(this.Tile_Enter);
                            this.Tiles[n, m].MouseLeave += new System.EventHandler(this.Tile_Leave);
                        }
                    }
                }
            }
            //w przeciwnym przypadku naprzemienne uruchamianie graczy
            else
            {
                searcher = new Searcher(tileSize, boardSize);
                Start();
            }

        }

        public void Start()
        {
            Thread black = new Thread(StartBlack);
            Thread white = new Thread(StartWhite);
            black.Start();
            white.Start();
            //black.Join();
           //  white.Join();
            // while (whitePlayer.Points + blackPlayer.Points != (5 * boardSize * boardSize / 9) && whitePlayer.Points != 0 && blackPlayer.Points != 0)
            {

            }
        }

        private void Tile_Enter(object sender, EventArgs e)
        {
            string tag = turn == Turn.W ? "W" : "B";
            if (checkIfAvailable((Panel)sender, tag))
            {
                ((Panel)sender).BorderStyle = BorderStyle.Fixed3D;

            }
        }

        private void Tile_Leave(object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Reakcja na wybor panelu do ruchu
        /// </summary>
        /// <param name="p"></param>
        private void OnPointChoose(Panel p)
        {

            int x = (p).Location.X / tileSize;
            int y = (p).Location.Y / tileSize;
            if (turn == Turn.W)
            {
                gamePanel.pictureBoxWhite.BorderStyle = BorderStyle.Fixed3D;
                gamePanel.pictureBoxBlack.BorderStyle = BorderStyle.None;
                p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("WField.png"));
                p.Tag = "W";
                p.Click += null;
                p.MouseEnter += null;
                p.MouseLeave += null;
                turn = Turn.B;
                updateTiles(x, y, "W");
                whitePlayer.Points++;
            }
            else
            {
                gamePanel.pictureBoxBlack.BorderStyle = BorderStyle.Fixed3D;
                gamePanel.pictureBoxWhite.BorderStyle = BorderStyle.None;
                p.BackgroundImage = (System.Drawing.Image)(Image.FromFile("BlackField.png"));
                p.Tag = "B";
                p.Click += null;
                p.MouseEnter += null;
                p.MouseLeave += null;
                turn = Turn.W;
                updateTiles(x, y, "B");
                blackPlayer.Points++;
            }

            updateGUI();
        }



        bool checkIfAvailable(Panel p, string tag)
        {
            if (p.Tag.ToString() != "G") return false;
            int x = p.Location.X / tileSize;
            int y = p.Location.Y / tileSize;
            int i, j;
            bool avail = false;
            int key = (int)Enum.Parse(typeof(Turn), tag);
            Turn opposite = (Turn)((key + 1) % 2);
            String opposite_tag = opposite.ToString();
            bool result = false;
            //pion
            for (i = y + 1; i < boardSize; i++)
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
            for (i = x + 1; i < boardSize; i++)
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
            for (i = x + 1, j = y + 1; i < boardSize && j < boardSize; i++, j++)
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
            for (i = x + 1, j = y - 1; i < boardSize && j > 0; i++, j--)
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
            for (i = x - 1, j = y + 1; i > 0 && j < boardSize; i--, j++)
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



        /// <summary>
        /// Oznacz odpowiednie pola jako biale/czarne lub odwroc odpowiednie pionki
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tag"></param>
        /// </summary>
        void updateTiles(int x, int y, string tag)
        {
            Player currentPlayer = tag == "W" ? whitePlayer : blackPlayer;
            Player secondPlayer = tag == "W" ? blackPlayer : whitePlayer;
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

            int key = (int)Enum.Parse(typeof(Turn), tag);
            Turn opposite = (Turn)((key + 1) % 2);
            String opposite_tag = opposite.ToString();


            bool avail = false;
            //pion
            for (i = y + 1; i < boardSize; i++)
            {
                if (Tiles[x, i].Tag.ToString() == "E" || Tiles[x, i].Tag.ToString() == "G" ||
               (Tiles[x, i].Tag.ToString() == tag && !avail)) {  break; }

                if (Tiles[x, i].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[x, i].Tag.ToString() == tag && avail)
                {
                    y_down = i;
                    break;
                }
            }

            avail = false;
            for (i = y - 1; i > 0; i--)
            {
                if (Tiles[x, i].Tag.ToString() == "E" || Tiles[x, i].Tag.ToString() == "G" ||
               (Tiles[x, i].Tag.ToString() == tag && !avail)) {  break; }
                if (Tiles[x, i].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[x, i].Tag.ToString() == tag && avail)
                {
                    y_up = i;
                    break;
                }
            }

            //poziom
            avail = false;
            //poziom
            for (i = x + 1; i < boardSize; i++)
            {
                if (Tiles[i, y].Tag.ToString() == "E" || Tiles[i, y].Tag.ToString() == "G" ||
               (Tiles[i, y].Tag.ToString() == tag && !avail)) { break; }
                if (Tiles[i, y].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, y].Tag.ToString() == tag && avail)
                {
                    x_right = i;
                    break;
                }

            }

            avail = false;
            for (i = x - 1; i > 0; i--)
            {
                if (Tiles[i, y].Tag.ToString() == "E" || Tiles[i, y].Tag.ToString() == "G" ||
               (Tiles[i, y].Tag.ToString() == tag && !avail)) {  break; }
                if (Tiles[i, y].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, y].Tag.ToString() == tag && avail)
                {
                    x_left = i;
                    break;
                }
            }
            //skos

            avail = false;
            for (i = x + 1, j = y + 1; i < boardSize && j < boardSize; i++, j++)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) {  break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    x_down_right = i;
                    y_down_right = j;
                    break;
                }
            }

            avail = false;
            for (i = x + 1, j = y - 1; i < boardSize && j > 0; i++, j--)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) {  break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    x_up_right = i;
                    y_up_right = j;
                    break;
                }
            }

            avail = false;
            for (i = x - 1, j = y + 1; i > 0 && j < boardSize; i--, j++)
            {
                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    x_down_left = i;
                    y_down_left = j;
                    break;
                }
            }
            avail = false;
            for (i = x - 1, j = y - 1; i > 0 && j > 0; i--, j--)
            {

                if (Tiles[i, j].Tag.ToString() == "E" || Tiles[i, j].Tag.ToString() == "G" ||
               (Tiles[i, j].Tag.ToString() == tag && !avail)) { break; }
                if (Tiles[i, j].Tag.ToString() == opposite_tag)
                {
                    avail = true;
                }
                else if (Tiles[i, j].Tag.ToString() == tag && avail)
                {
                    x_up_left = i;
                    y_up_left = j;
                    break;
                }
            }

         //   int key = (int)Enum.Parse(typeof(Turn), tag);
          //  Turn opposite = (Turn)((key + 1) % 2);
         //   String opposite_tag = opposite.ToString();
            string file = tag == "W" ? "WField.png" : "BlackField.png";

            //Reverse
            if (y_down >= 0)
            {
                for (i = y + 1; i < y_down; i++)
                {
                    Reverse(Tiles[x, i], tag, opposite_tag, secondPlayer, currentPlayer, file);

                }
            }
            if (y_up >= 0)
            {
                for (i = y - 1; i > y_up; i--)
                {
                    Reverse(Tiles[x, i], tag, opposite_tag, secondPlayer, currentPlayer, file);

                }
            }
            if (x_right >= 0)
            {
                for (i = x + 1; i < x_right; i++)
                {
                    Reverse(Tiles[i, y], tag, opposite_tag, secondPlayer, currentPlayer, file);

                }
            }
            if (x_left >= 0)
            {
                for (i = x - 1; i > x_left; i--)
                {
                    Reverse(Tiles[i, y], tag, opposite_tag, secondPlayer, currentPlayer, file);

                }
            }

            if (x_up_left >= 0)
            {
                for (i = x - 1, j = y - 1; i > x_up_left && j > y_up_left; i--, j--)
                {
                    Reverse(Tiles[i, j], tag, opposite_tag, secondPlayer, currentPlayer, file);
                }
            }
            if (x_up_right >= 0)
            {
                for (i = x + 1, j = y - 1; i < x_up_right && j > y_up_right; i++, j--)
                {
                    Reverse(Tiles[i, j], tag, opposite_tag, secondPlayer, currentPlayer, file);
                }
            }
            if (x_down_left >= 0)
            {
                for (i = x - 1, j = y + 1; i > x_down_left && j < y_down_left; i--, j++)
                {
                    Reverse(Tiles[i, j], tag, opposite_tag, secondPlayer, currentPlayer, file);

                }
            }
            if (x_down_right >= 0)
            {
                for (i = x + 1, j = y + 1; i < x_down_right && j < y_down_right; i++, j++)
                {
                    Reverse(Tiles[i, j], tag, opposite_tag, secondPlayer, currentPlayer, file);
                }
            }

        }

        /// <summary>
        /// odwroc kolor pionka zgodnie z obecnym ruchem (czy bialy czy czarny)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tag"></param>
        /// <param name="opposite_tag"></param>
        /// <param name="secondPlayer"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="file"></param>
        private void Reverse(Panel p, string tag, string opposite_tag, Player secondPlayer, Player currentPlayer, string file)
        {

            if (p.Tag.ToString() == opposite_tag)
            {
                secondPlayer.Points--;
                
                p.Tag = tag;
                p.BackgroundImage = (System.Drawing.Image)(Image.FromFile(file));
                p.Click += null;
                p.MouseEnter += null;
                p.MouseLeave += null;
                currentPlayer.Points++;  
            }

            
            
        }


        /// <summary>
        /// Obsluga klikniecia (tylko dla niezajetych pol)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_Click(object sender, EventArgs e)
        {

            string tag = turn == Turn.W ? "W" : "B";
            if (checkIfAvailable((Panel)sender, tag))
            {
                int x = ((Panel)sender).Location.X / tileSize;
                int y = ((Panel)sender).Location.Y / tileSize;
                MessageBox.Show("RESULT = " + x + ", " + y);
                if (turn == Turn.W)
                {
                    ((Panel)sender).BackgroundImage = (System.Drawing.Image)(Image.FromFile("WField.png"));
                    ((Panel)sender).Tag = "W";
                    ((Panel)sender).Click += null;
                    ((Panel)sender).MouseEnter += null;
                    ((Panel)sender).MouseLeave += null;
                    turn = Turn.B;
                    updateTiles(x, y, "W");
                    whitePlayer.Points++;
                }
                else
                {
                    ((Panel)sender).BackgroundImage = (System.Drawing.Image)(Image.FromFile("BlackField.png"));
                    ((Panel)sender).Tag = "B";
                    ((Panel)sender).Click += null;
                    ((Panel)sender).MouseEnter += null;
                    ((Panel)sender).MouseLeave += null;
                    turn = Turn.W;
                    updateTiles(x, y, "B");
                    blackPlayer.Points++;
                }

                updateGUI();
            }
        }


        private void Tile_Choose(Point point)
        {
            int x = point.X;
            int y = point.Y;
            //            int squareSize = boardSize / 3;
           // if ((x < squareSize && y < squareSize) || (x >= 2 * squareSize && y >= 2 * squareSize) || (x < squareSize && y >= 2 * squareSize) || (x < squareSize && y >= 2 * squareSize)) return;
            string tag = turn == Turn.W ? "W" : "B";
            
            Panel chosen_panel = Tiles[x, y];

            if (turn == Turn.W)
            {
                chosen_panel.BackgroundImage = (System.Drawing.Image)(Image.FromFile("WField.png"));
                chosen_panel.Tag = "W";

                turn = Turn.B;
                updateTiles(x, y, "W");
                whitePlayer.Points++;
            }
            else
            {
                chosen_panel.BackgroundImage = (System.Drawing.Image)(Image.FromFile("BlackField.png"));
                chosen_panel.Tag = "B";
                turn = Turn.W;
                updateTiles(x, y, "B");
                blackPlayer.Points++;
            }

            updateGUI();

        }

        /// <summary>
        /// aktualizacja punktow na panelu gry
        /// </summary>
        private void updateGUI()
        {
            
            gamePanel.whitePoints.Text = whitePlayer.Points.ToString();
            gamePanel.blackPoints.Text = blackPlayer.Points.ToString();
            if (turn == Turn.W)
            {
                gamePanel.whitePoints.BackColor = Color.Red;
                gamePanel.blackPoints.BackColor = Color.Transparent;
            }
            else
            {
                gamePanel.whitePoints.BackColor = Color.Transparent;
                gamePanel.blackPoints.BackColor = Color.Red;
            }
            gamePanel.SUM.Text = (whitePlayer.Points + blackPlayer.Points).ToString();
            checkIfFinished();
        }

        /// <summary>
        /// Rozpoczecie automatycznej gry (naprzemienne ruchy przeciwnikow az do momentu zakonczenia gry)
        /// </summary>
        public void StartBlack()
        {
            while (whitePlayer.Points + blackPlayer.Points != (5 * boardSize * boardSize / 9))
            {
                Point found_point = new Point(-1, -1);
                Point? point;
                BlackSemaphore.WaitOne();
                Thread.Sleep(1000);
                point = (Point?)searcher.Search(Tiles, blackPlayer,Int16.MinValue,Int16.MaxValue,1).Point;
                //point = (Point)searcher.simpleSearch(Tiles, whitePlayer, 1).Point;
                if (point != null)
                {
                    found_point = (Point)point;
                    
                    if (found_point.X >= 0 && found_point.Y >= 0)
                        Tile_Choose(found_point);
                }
                updateGUI();

                turn = Turn.W;
                WhiteSemaphore.Release();
            }
            game_on = false;
        }


        public void StartWhite()
        {
           
            while (whitePlayer.Points + blackPlayer.Points != (5 * boardSize * boardSize / 9) && whitePlayer.Points != 0 && blackPlayer.Points != 0)
            {
                WhiteSemaphore.WaitOne();
                Point found_point = new Point(-1, -1);
                Point? point;
                Thread.Sleep(1000);
                point =(Point) searcher.Search(Tiles, whitePlayer,Int16.MinValue,Int16.MaxValue, 1).Point;
               // point = (Point)searcher.simpleSearch(Tiles, whitePlayer, 1).Point;
                if (point != null)
                {

                    found_point = (Point)point;

                    if (found_point.X >= 0 && found_point.Y >= 0)
                        Tile_Choose(found_point);
                }
                updateGUI();
                turn = Turn.B;
                BlackSemaphore.Release();
            }
            game_on = false;

        }

        /// <summary>
        /// Sprawdzenie czy gra sie zakonczyla, jesli tak - wyswietlenia MessageBoxa z informacja o punktach
        /// </summary>
        public void checkIfFinished()
        {
            if (whitePlayer.Points + blackPlayer.Points == (5 * boardSize * boardSize / 9))
            {
                MessageBox.Show("GAME FINISHED!\n Result is : \n White: " + whitePlayer.Points.ToString() + "\n Black: " + blackPlayer.Points.ToString());
                Application.Exit();
            }
            //TODO:
            //dodac powrot do menu glownego po zakonczeniu gry?
        }

    }
}

