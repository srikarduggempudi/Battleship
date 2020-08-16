using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameLibrary;

namespace Battleship
{
    public partial class BattleshipForm : Form
    {
        private GameController gameController;

        public BattleshipForm()
        {
            InitializeComponent();

            gameController = new GameController();
            gameController.ComputerBoard = this.computerBoard;
            gameController.UserBoard = this.userBoard;
            this.userBoard.GameController = gameController;
            this.computerBoard.GameController = gameController;
            this.Icon = ImageUtil.GetEmbeddedIcon("Images.Ship.ico");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (rbEasy.Checked)
            {
                gameController.EasyMode = true;
            }
            else
            {
                gameController.EasyMode = false;
            }
            StartNewGame();
        }

        private void StartNewGame()
        {
            UserShipPlacementForm placementForm = new UserShipPlacementForm();
            placementForm.StartPosition = FormStartPosition.CenterParent;
            placementForm.ShowDialog(this);
            if (placementForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //clear field
                userBoard.ClearBattlefield();
                // get the ships from placement form and add them to the user board
                List<Ship> placedShips = placementForm.Ships;
                foreach (Ship ship in placedShips)
                {
                    userBoard.AddShip(ship, ship.X, ship.Y);
                }

                // place the ships on computer board
                computerBoard.AddAllShips();
                gameController.GameOver = false;
                titlePanel.Visible = false;
            }
        }
    }
}
