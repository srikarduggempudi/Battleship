namespace GameLibrary
{
    partial class UserShipPlacementForm
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
            this.btnPlaceShips = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.battlefield = new GameLibrary.Battlefield();
            this.SuspendLayout();
            // 
            // btnPlaceShips
            // 
            this.btnPlaceShips.Location = new System.Drawing.Point(426, 67);
            this.btnPlaceShips.Name = "btnPlaceShips";
            this.btnPlaceShips.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceShips.TabIndex = 1;
            this.btnPlaceShips.Text = "Place Ships";
            this.btnPlaceShips.UseVisualStyleBackColor = true;
            this.btnPlaceShips.Click += new System.EventHandler(this.btnPlaceShips_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(185, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // battlefield
            // 
            this.battlefield.GameController = null;
            this.battlefield.Location = new System.Drawing.Point(12, 12);
            this.battlefield.Name = "battlefield";
            this.battlefield.Size = new System.Drawing.Size(408, 371);
            this.battlefield.TabIndex = 0;
            // 
            // UserShipPlacementForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 428);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPlaceShips);
            this.Controls.Add(this.battlefield);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserShipPlacementForm";
            this.Text = "Place your ships";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserShipPlacementForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Battlefield battlefield;
        private System.Windows.Forms.Button btnPlaceShips;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}