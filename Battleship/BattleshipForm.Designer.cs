namespace Battleship
{
    partial class BattleshipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleshipForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.gbLevels = new System.Windows.Forms.GroupBox();
            this.rbDifficult = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.userBoard = new GameLibrary.Battlefield();
            this.computerBoard = new GameLibrary.Battlefield();
            this.menuStrip1.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.gbLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.CadetBlue;
            this.titlePanel.BackgroundImage = global::Battleship.Properties.Resources.title;
            this.titlePanel.Controls.Add(this.gbLevels);
            this.titlePanel.Controls.Add(this.lblCopyright);
            this.titlePanel.Controls.Add(this.btnNewGame);
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(884, 419);
            this.titlePanel.TabIndex = 5;
            // 
            // gbLevels
            // 
            this.gbLevels.Controls.Add(this.rbDifficult);
            this.gbLevels.Controls.Add(this.rbEasy);
            this.gbLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLevels.Location = new System.Drawing.Point(322, 163);
            this.gbLevels.Name = "gbLevels";
            this.gbLevels.Size = new System.Drawing.Size(240, 64);
            this.gbLevels.TabIndex = 2;
            this.gbLevels.TabStop = false;
            this.gbLevels.Text = "Levels";
            // 
            // rbDifficult
            // 
            this.rbDifficult.AutoSize = true;
            this.rbDifficult.Checked = true;
            this.rbDifficult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDifficult.Location = new System.Drawing.Point(133, 23);
            this.rbDifficult.Name = "rbDifficult";
            this.rbDifficult.Size = new System.Drawing.Size(80, 24);
            this.rbDifficult.TabIndex = 1;
            this.rbDifficult.TabStop = true;
            this.rbDifficult.Text = "Difficult";
            this.rbDifficult.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEasy.Location = new System.Drawing.Point(33, 23);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(62, 24);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.Text = "Easy";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(306, 369);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(273, 22);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "© 2016 Srikar Duggempudi";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(352, 245);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(180, 51);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // userBoard
            // 
            this.userBoard.GameController = null;
            this.userBoard.Location = new System.Drawing.Point(12, 29);
            this.userBoard.Name = "userBoard";
            this.userBoard.Size = new System.Drawing.Size(408, 380);
            this.userBoard.TabIndex = 3;
            // 
            // computerBoard
            // 
            this.computerBoard.BoardType = GameLibrary.BoardType.Computer;
            this.computerBoard.GameController = null;
            this.computerBoard.Location = new System.Drawing.Point(468, 29);
            this.computerBoard.Name = "computerBoard";
            this.computerBoard.Size = new System.Drawing.Size(408, 380);
            this.computerBoard.TabIndex = 0;
            // 
            // BattleshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 418);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.userBoard);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.computerBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BattleshipForm";
            this.Text = "Battleship";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.gbLevels.ResumeLayout(false);
            this.gbLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameLibrary.Battlefield computerBoard;
        private GameLibrary.Battlefield userBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.GroupBox gbLevels;
        private System.Windows.Forms.RadioButton rbDifficult;
        private System.Windows.Forms.RadioButton rbEasy;


    }
}

