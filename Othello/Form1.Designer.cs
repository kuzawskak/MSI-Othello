namespace Othello
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FirstComputerLabel = new System.Windows.Forms.Label();
            this.SecondComputerLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.FirstComputerHeuristic = new System.Windows.Forms.ComboBox();
            this.SecondComputerHeuristic = new System.Windows.Forms.ComboBox();
            this.playerModesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.testMode = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.boardSizeCombo = new System.Windows.Forms.ComboBox();
            this.WhitePlayerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.WhitePictureBox = new System.Windows.Forms.PictureBox();
            this.BlackPlayerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BlackPictureBox = new System.Windows.Forms.PictureBox();
            this.BlackPoints = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.playerModesPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.WhitePlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhitePictureBox)).BeginInit();
            this.BlackPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel.BackgroundImage")));
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.FirstComputerLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.SecondComputerLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.StartButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.FirstComputerHeuristic, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.SecondComputerHeuristic, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.playerModesPanel, 0, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(766, 553);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // FirstComputerLabel
            // 
            this.FirstComputerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstComputerLabel.AutoSize = true;
            this.FirstComputerLabel.BackColor = System.Drawing.Color.Transparent;
            this.FirstComputerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FirstComputerLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.FirstComputerLabel.Location = new System.Drawing.Point(106, 138);
            this.FirstComputerLabel.Name = "FirstComputerLabel";
            this.FirstComputerLabel.Size = new System.Drawing.Size(274, 138);
            this.FirstComputerLabel.TabIndex = 0;
            this.FirstComputerLabel.Text = "Computer I (white)";
            this.FirstComputerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondComputerLabel
            // 
            this.SecondComputerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondComputerLabel.AutoSize = true;
            this.SecondComputerLabel.BackColor = System.Drawing.Color.Transparent;
            this.SecondComputerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SecondComputerLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SecondComputerLabel.Location = new System.Drawing.Point(100, 276);
            this.SecondComputerLabel.Name = "SecondComputerLabel";
            this.SecondComputerLabel.Size = new System.Drawing.Size(280, 138);
            this.SecondComputerLabel.TabIndex = 1;
            this.SecondComputerLabel.Text = "Computer II (black)";
            this.SecondComputerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.BackColor = System.Drawing.Color.Green;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartButton.Location = new System.Drawing.Point(506, 464);
            this.StartButton.Margin = new System.Windows.Forms.Padding(120, 50, 120, 40);
            this.StartButton.MaximumSize = new System.Drawing.Size(140, 50);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 49);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FirstComputerHeuristic
            // 
            this.FirstComputerHeuristic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FirstComputerHeuristic.BackColor = System.Drawing.SystemColors.MenuText;
            this.FirstComputerHeuristic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FirstComputerHeuristic.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FirstComputerHeuristic.ForeColor = System.Drawing.SystemColors.Window;
            this.FirstComputerHeuristic.FormattingEnabled = true;
            this.FirstComputerHeuristic.Items.AddRange(new object[] {
            "MAX LICZBA PUNKTOW",
            "POLA WAŻONE",
            "ZAJECIE NAROZNIKOW",
            "OCENA STABILNOSCI",
            "MIN LICZBA PUNKTOW",
            "MOZLIWOSC PODJECIA RUCHU"});
            this.FirstComputerHeuristic.Location = new System.Drawing.Point(483, 188);
            this.FirstComputerHeuristic.Margin = new System.Windows.Forms.Padding(100, 50, 100, 50);
            this.FirstComputerHeuristic.Name = "FirstComputerHeuristic";
            this.FirstComputerHeuristic.Size = new System.Drawing.Size(183, 25);
            this.FirstComputerHeuristic.TabIndex = 3;
            this.FirstComputerHeuristic.Text = "MAX LICZBA PUNKTOW";
            // 
            // SecondComputerHeuristic
            // 
            this.SecondComputerHeuristic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SecondComputerHeuristic.BackColor = System.Drawing.SystemColors.MenuText;
            this.SecondComputerHeuristic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SecondComputerHeuristic.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SecondComputerHeuristic.ForeColor = System.Drawing.SystemColors.Window;
            this.SecondComputerHeuristic.FormattingEnabled = true;
            this.SecondComputerHeuristic.Items.AddRange(new object[] {
            "MAX LICZBA PUNKTOW",
            "POLA WAŻONE",
            "ZAJECIE NAROZNIKOW",
            "OCENA STABILNOSCI",
            "MIN LICZBA PUNKTOW",
            "MOZLIWOSC PODJECIA RUCHU"});
            this.SecondComputerHeuristic.Location = new System.Drawing.Point(483, 326);
            this.SecondComputerHeuristic.Margin = new System.Windows.Forms.Padding(100, 50, 100, 50);
            this.SecondComputerHeuristic.Name = "SecondComputerHeuristic";
            this.SecondComputerHeuristic.Size = new System.Drawing.Size(183, 25);
            this.SecondComputerHeuristic.TabIndex = 4;
            this.SecondComputerHeuristic.Text = "MAX LICZBA PUNKTOW";
            // 
            // playerModesPanel
            // 
            this.playerModesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerModesPanel.BackColor = System.Drawing.Color.Transparent;
            this.playerModesPanel.ColumnCount = 2;
            this.playerModesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerModesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerModesPanel.Controls.Add(this.testMode, 0, 0);
            this.playerModesPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.playerModesPanel.Location = new System.Drawing.Point(3, 417);
            this.playerModesPanel.Name = "playerModesPanel";
            this.playerModesPanel.RowCount = 1;
            this.playerModesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerModesPanel.Size = new System.Drawing.Size(377, 133);
            this.playerModesPanel.TabIndex = 5;
            // 
            // testMode
            // 
            this.testMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testMode.AutoSize = true;
            this.testMode.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.testMode.Location = new System.Drawing.Point(59, 3);
            this.testMode.Name = "testMode";
            this.testMode.Size = new System.Drawing.Size(126, 127);
            this.testMode.TabIndex = 0;
            this.testMode.Text = "test mode";
            this.testMode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.boardSizeCombo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(191, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(183, 127);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board size:";
            // 
            // boardSizeCombo
            // 
            this.boardSizeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardSizeCombo.BackColor = System.Drawing.SystemColors.MenuText;
            this.boardSizeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boardSizeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.boardSizeCombo.ForeColor = System.Drawing.SystemColors.Window;
            this.boardSizeCombo.FormattingEnabled = true;
            this.boardSizeCombo.Items.AddRange(new object[] {
            "12",
            "15"});
            this.boardSizeCombo.Location = new System.Drawing.Point(3, 66);
            this.boardSizeCombo.Name = "boardSizeCombo";
            this.boardSizeCombo.Size = new System.Drawing.Size(177, 33);
            this.boardSizeCombo.TabIndex = 1;
            this.boardSizeCombo.Text = "12";
            // 
            // WhitePlayerPanel
            // 
            this.WhitePlayerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WhitePlayerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WhitePlayerPanel.Controls.Add(this.WhitePictureBox);
            this.WhitePlayerPanel.Location = new System.Drawing.Point(691, 3);
            this.WhitePlayerPanel.Name = "WhitePlayerPanel";
            this.WhitePlayerPanel.Size = new System.Drawing.Size(33, 547);
            this.WhitePlayerPanel.TabIndex = 0;
            // 
            // WhitePictureBox
            // 
            this.WhitePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WhitePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WhitePictureBox.BackgroundImage")));
            this.WhitePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.WhitePictureBox.Location = new System.Drawing.Point(3, 3);
            this.WhitePictureBox.Name = "WhitePictureBox";
            this.WhitePictureBox.Size = new System.Drawing.Size(71, 50);
            this.WhitePictureBox.TabIndex = 0;
            this.WhitePictureBox.TabStop = false;
            // 
            // BlackPlayerPanel
            // 
            this.BlackPlayerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BlackPlayerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BlackPlayerPanel.Controls.Add(this.BlackPictureBox);
            this.BlackPlayerPanel.Controls.Add(this.BlackPoints);
            this.BlackPlayerPanel.Location = new System.Drawing.Point(3, 3);
            this.BlackPlayerPanel.Name = "BlackPlayerPanel";
            this.BlackPlayerPanel.Size = new System.Drawing.Size(31, 547);
            this.BlackPlayerPanel.TabIndex = 1;
            // 
            // BlackPictureBox
            // 
            this.BlackPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BlackPictureBox.BackgroundImage")));
            this.BlackPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BlackPictureBox.Location = new System.Drawing.Point(3, 3);
            this.BlackPictureBox.Name = "BlackPictureBox";
            this.BlackPictureBox.Size = new System.Drawing.Size(69, 50);
            this.BlackPictureBox.TabIndex = 0;
            this.BlackPictureBox.TabStop = false;
            // 
            // BlackPoints
            // 
            this.BlackPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlackPoints.AutoSize = true;
            this.BlackPoints.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlackPoints.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BlackPoints.Location = new System.Drawing.Point(3, 56);
            this.BlackPoints.Name = "BlackPoints";
            this.BlackPoints.Size = new System.Drawing.Size(35, 37);
            this.BlackPoints.TabIndex = 1;
            this.BlackPoints.Text = "0";
            this.BlackPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.playerModesPanel.ResumeLayout(false);
            this.playerModesPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.WhitePlayerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WhitePictureBox)).EndInit();
            this.BlackPlayerPanel.ResumeLayout(false);
            this.BlackPlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label FirstComputerLabel;
        private System.Windows.Forms.Label SecondComputerLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox FirstComputerHeuristic;
        private System.Windows.Forms.ComboBox SecondComputerHeuristic;
        private System.Windows.Forms.FlowLayoutPanel WhitePlayerPanel;
        public System.Windows.Forms.PictureBox WhitePictureBox;
        private System.Windows.Forms.FlowLayoutPanel BlackPlayerPanel;
        public System.Windows.Forms.PictureBox BlackPictureBox;
        private System.Windows.Forms.Label BlackPoints;
        private System.Windows.Forms.TableLayoutPanel playerModesPanel;
        private System.Windows.Forms.CheckBox testMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boardSizeCombo;
    }
}

