using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameLibrary
{
    public enum BoardType { User = 0, Computer = 1 }
    public class Battlefield : Panel
    {
        public const int FIELD_SIZE = 10;
        public const int CELL_SIZE = 30;
        private Cell[,] cells;
        private List<Ship> ships;
        private BoardType boardType;
        private Scoreboard scoreboard;
        private Label[] rowLabels;
        private Label[] columnLabels;
        private Panel boardPanel;
        private Label boardTypeLabel;
        public GameController GameController { get; set; }

        [DefaultValue(BoardType.User)]
        [Description("Whose board it is")]
        public BoardType BoardType
        {
            get
            {
                return boardType;
            }
            set
            {
                boardType = value;

                UnregisterCellClick();
                if (boardType == GameLibrary.BoardType.Computer)
                {
                    RegisterCellClick();
                }
                boardTypeLabel.Text = boardType.ToString();
                ResetBoardLayout();
                this.Refresh();
            }
        }

        public List<Ship> Ships
        {
            get
            {
                return ships;
            }
        }

        public Battlefield()
        {
            boardPanel = new Panel();

            ships = new List<Ship>();
            cells = new Cell[FIELD_SIZE, FIELD_SIZE];
            rowLabels = new Label[FIELD_SIZE];
            columnLabels = new Label[FIELD_SIZE];
            int rowLabelSize = CELL_SIZE;
            int columnLabelSize = CELL_SIZE;
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                rowLabels[i] = new Label();
                rowLabels[i].Text = Convert.ToString(i + 1);
                rowLabels[i].Location = new Point(1, (i + 1) * CELL_SIZE);
                rowLabels[i].Size = new Size(rowLabelSize, CELL_SIZE);
                rowLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                boardPanel.Controls.Add(rowLabels[i]);
            }

            for (int i = 0; i < FIELD_SIZE; i++)
            {
                char columnLabelChar = (char)('A' + i);
                columnLabels[i] = new Label();
                columnLabels[i].Text = Convert.ToString(columnLabelChar);
                columnLabels[i].Location = new Point((i + 1) * CELL_SIZE, 1);
                columnLabels[i].Size = new Size(columnLabelSize, CELL_SIZE);
                columnLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                boardPanel.Controls.Add(columnLabels[i]);
            }

            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].RowNumber = i;
                    cells[i, j].ColumnNumber = j;
                    cells[i, j].Location = new Point(rowLabelSize + i * Battlefield.CELL_SIZE, columnLabelSize + j * Battlefield.CELL_SIZE);
                    cells[i, j].Battlefield = this;
                    boardPanel.Controls.Add(cells[i, j]);
                }
            }

            boardTypeLabel = new Label();
            boardTypeLabel.Text = BoardType.ToString();
            boardTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            boardTypeLabel.Size = new Size(CELL_SIZE * (FIELD_SIZE + 1), 24);
            boardTypeLabel.Location = new Point(0, 0);
            boardTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(boardTypeLabel);

            boardPanel.Size = new Size(CELL_SIZE * (FIELD_SIZE + 1), CELL_SIZE * (FIELD_SIZE + 1));
            boardPanel.Location = new Point(0, boardTypeLabel.Size.Height + 1);
            this.Controls.Add(boardPanel);

            scoreboard = new Scoreboard();
            scoreboard.Size = new Size(60, 70);
            scoreboard.Location = new Point(boardPanel.Size.Width + 10, boardTypeLabel.Size.Height + 1 + columnLabelSize + 1);
            scoreboard.Battlefield = this;
            this.Controls.Add(scoreboard);

            this.BoardType = GameLibrary.BoardType.User;
        }

        public bool AddShip(Ship ship, int x, int y)
        {
            //Make sure x and y coordinates are positive
            if (x < 0 || y < 0)
            {
                return false;
            }

            //Make sure that the ship doesn't go out of the grid
            if (ship.Direction == Direction.Horizontal)
            {
                if (x > (FIELD_SIZE - ship.Length))
                {
                    return false;
                }
                for (int i = x; i < x + ship.Length; i++)
                {
                    if (cells[i, y].Ship != null)
                    {
                        return false;
                    }
                }

            }

            if (ship.Direction == Direction.Vertical)
            {
                if (y > (FIELD_SIZE - ship.Length))
                {
                    return false;
                }
                for (int i = y; i < y + ship.Length; i++)
                {
                    if (cells[x, i].Ship != null)
                    {
                        return false;
                    }
                }
            }

            // Add ship and set the cells as occupied
            ships.Add(ship);
            ship.X = x;
            ship.Y = y;
            int fragmentNumber = 0;
            if (ship.Direction == Direction.Horizontal)
            {
                for (int i = x; i < x + ship.Length; i++)
                {
                    cells[i, y].ShipCropImage = ship.ShipImage[fragmentNumber++];
                    cells[i, y].Ship = ship;
                }
            }
            else
            {
                for (int i = y; i < y + ship.Length; i++)
                {
                    cells[x, i].ShipCropImage = ship.ShipImage[fragmentNumber++];
                    cells[x, i].Ship = ship;
                }
            }

            scoreboard.Invalidate();
            this.Invalidate();
            return true;
        }

        public FireMissileStatus FireMissile(int x, int y)
        {
            if (x < 0 || x >= FIELD_SIZE
                || y<0 || y>= FIELD_SIZE)
            {
                return FireMissileStatus.Illegal;
            }
            
            if (cells[x, y].State != CellState.Idle)
            {
                return FireMissileStatus.AlreadyFired;
            }

            FireMissileStatus status;
            if (cells[x, y].Ship == null)
            {
                cells[x, y].State = CellState.Miss;
                status = FireMissileStatus.Miss;
            }
            else
            {
                cells[x, y].State = CellState.Hit;
                cells[x, y].Ship.Hits++;
                status = FireMissileStatus.Hit;
            }

            scoreboard.Invalidate();
            this.Invalidate();
            return status;
        }

        public int GetSunkenShipCount()
        {
            int numberOfSunkenShips = 0;
            foreach (Ship s in ships)
            {
                if (s.Sunken)
                {
                    numberOfSunkenShips++;
                }
            }
            return numberOfSunkenShips;
        }

        public bool AreAllShipsSunken()
        {
            foreach (Ship s in ships)
            {
                if (!s.Sunken)
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearBattlefield()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    cells[i, j].Ship = null;
                    cells[i, j].State = CellState.Idle;
                }
            }

            ships.Clear();
        }

        public void AddAllShips()
        {
            ClearBattlefield();

            Random rand = new Random();
            Ship[] allShips = Ship.GetAllShips();
            // for each ship in array, try to place it on battle field
            foreach (Ship ship in allShips)
            {
                bool added = false;
                while (added == false)
                {
                    if (rand.Next(2) == 0)
                    {
                        ship.Direction = Direction.Horizontal;
                    }
                    else
                    {
                        ship.Direction = Direction.Vertical;
                    }

                    int rowNumber = rand.Next(Battlefield.FIELD_SIZE);
                    int columnNumber = rand.Next(Battlefield.FIELD_SIZE);
                    added = this.AddShip(ship, columnNumber, rowNumber);
                }
            }

        }

        private void UnregisterCellClick()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    cells[i, j].Click -= new EventHandler(Cell_Click);
                }
            }
        }

        private void ResetBoardLayout()
        {
            int yOffset = boardTypeLabel.Size.Height + 1;
            if (boardType == GameLibrary.BoardType.Computer)
            {
                boardTypeLabel.Location = new Point(0, 0);
                boardPanel.Location = new Point(0, yOffset);
                scoreboard.Location = new Point(boardPanel.Size.Width + 10, scoreboard.Location.Y);
            }
            else
            {
                boardTypeLabel.Location = new Point(scoreboard.Size.Width + 10, 0);
                boardPanel.Location = new Point(scoreboard.Size.Width + 10, yOffset);
                scoreboard.Location = new Point(0, scoreboard.Location.Y);
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (GameController.GameOver == false)
            {
                //Console.WriteLine("Cell clicked");
                Cell clickedCell = (Cell)sender;
                FireMissile(clickedCell.RowNumber, clickedCell.ColumnNumber);

                GameController.FireOpponentMissile();
            }
        }

        private void RegisterCellClick()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    cells[i, j].Click += new EventHandler(Cell_Click);
                }
            }
        }

    }
}
