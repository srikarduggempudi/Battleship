using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GameLibrary
{
    public class Scoreboard : Panel
    {
        private const int SHIP_STATE_CELL_SIZE = 7;
        private const int SHIP_STATE_CELL_VGAP = 5;
        private const int SHIP_STATE_CELL_HGAP = 3;

        public Battlefield Battlefield { get; set; }
        public Scoreboard()
        {
            //this.BackColor = Color.CornflowerBlue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle clientRect = ClientRectangle;

            if (Battlefield != null)
            {
                int xPos = 5;
                int yPos = 5 - Scoreboard.SHIP_STATE_CELL_SIZE - Scoreboard.SHIP_STATE_CELL_VGAP;
                for (int i = 0; i < Battlefield.Ships.Count; i++)
                {
                    xPos = 5;
                    yPos += Scoreboard.SHIP_STATE_CELL_SIZE + Scoreboard.SHIP_STATE_CELL_VGAP;
                    Ship ship = Battlefield.Ships[i];
                    for (int j = 0; j < ship.Length; j++)
                    {
                        Brush brush = Brushes.LightBlue;
                        if (ship.Sunken)
                        {
                            brush = Brushes.Tomato;
                        }
                        e.Graphics.FillRectangle(brush, xPos, yPos, Scoreboard.SHIP_STATE_CELL_SIZE, Scoreboard.SHIP_STATE_CELL_SIZE);
                        xPos += Scoreboard.SHIP_STATE_CELL_SIZE + Scoreboard.SHIP_STATE_CELL_HGAP;
                    }
                }

            }
        }
    }
}
