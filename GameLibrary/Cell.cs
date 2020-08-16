using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameLibrary
{
    public enum CellState
    {
        Idle = 0,
        Hit = 1,
        Miss = 2
    }

    public class Cell : Panel
    {
        private Ship ship;
        private CellState cellState;

        [DefaultValue(0)]
        [Description("Column in which the cell is located")]
        public int ColumnNumber { get; set; }

        [DefaultValue(0)]
        [Description("Row in which the cell is located")]
        public int RowNumber { get; set; }

        [Description("The ship occupying this cell")]
        public Ship Ship 
        { 
            get
            {
                return ship;
            }

            set
            {
                ship = value;
                this.Refresh();
            }
        }

        [DefaultValue(CellState.Idle)]
        [Description("Is the cell a hit, miss, or idle by the missile")]
        public CellState State
        {
            get
            {
                return cellState;
            }

            set
            {
                cellState = value;
                this.Refresh();
            }
        }

        public Image ShipCropImage { get; set; }
        public Battlefield Battlefield { get; set; }

        public Cell()
        {
            this.RowNumber = 0;
            this.ColumnNumber = 0;
            this.State = CellState.Idle;
            this.Size = new Size(30, 30);
            this.BackColor = Color.DodgerBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle clientRect = ClientRectangle;

            // draw the ship
            if (this.Ship != null && this.Battlefield.BoardType == BoardType.User)
            {
                e.Graphics.DrawImage(this.ShipCropImage, clientRect);
            }

            if (this.State == CellState.Hit)
            {
                //int x1 = clientRect.X;
                //int y1 = clientRect.Y;
                //int x2 = clientRect.X + clientRect.Width;
                //int y2 = clientRect.Y + clientRect.Height;
                //using (Pen pen = new Pen(Color.Tomato, 2))
                //{
                //    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                //    e.Graphics.DrawLine(pen, x2, y1, x1, y2);
                //}

                ImageUtil.DrawBlast(e.Graphics, this);
            }
            else if (this.State == CellState.Miss)
            {
                //using (Pen pen = new Pen(Color.Tomato, 2))
                //{
                //    e.Graphics.DrawEllipse(pen, clientRect);
                //}
                ImageUtil.DrawMiss(e.Graphics, this);
            }
        }
    }
}
