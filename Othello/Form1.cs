using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            tableLayoutPanel.Visible = false;
            Game_Panel game = new Game_Panel();
  
           
            Game g = new Game(game, Int16.Parse(boardSizeCombo.Text),FirstComputerHeuristic.Text,SecondComputerHeuristic.Text,testMode.Checked);
            game.Dock = DockStyle.Fill;
            this.Controls.Add(game);

        }
    }
}
