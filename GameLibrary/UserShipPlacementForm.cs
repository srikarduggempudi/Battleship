using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameLibrary
{
    public partial class UserShipPlacementForm : Form
    {
        public List<Ship> Ships
        {
            get
            {
                return battlefield.Ships;
            }
        }

        public UserShipPlacementForm()
        {
            InitializeComponent();
            battlefield.AddAllShips();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnPlaceShips_Click(object sender, EventArgs e)
        {
            battlefield.AddAllShips();
        }

        private void UserShipPlacementForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
