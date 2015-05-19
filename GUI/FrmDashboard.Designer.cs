namespace DAT602_GUI
{
    partial class FrmDashboard
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
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.btnMultiPlayer = new System.Windows.Forms.Button();
            this.btnHiscores = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnVisitStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(12, 9);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(118, 26);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Enabled = false;
            this.btnSinglePlayer.Location = new System.Drawing.Point(12, 50);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(100, 23);
            this.btnSinglePlayer.TabIndex = 1;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = true;
            // 
            // btnMultiPlayer
            // 
            this.btnMultiPlayer.Location = new System.Drawing.Point(12, 79);
            this.btnMultiPlayer.Name = "btnMultiPlayer";
            this.btnMultiPlayer.Size = new System.Drawing.Size(100, 23);
            this.btnMultiPlayer.TabIndex = 2;
            this.btnMultiPlayer.Text = "Multiplayer";
            this.btnMultiPlayer.UseVisualStyleBackColor = true;
            this.btnMultiPlayer.Click += new System.EventHandler(this.btnMultiPlayer_Click);
            // 
            // btnHiscores
            // 
            this.btnHiscores.Enabled = false;
            this.btnHiscores.Location = new System.Drawing.Point(12, 108);
            this.btnHiscores.Name = "btnHiscores";
            this.btnHiscores.Size = new System.Drawing.Size(100, 23);
            this.btnHiscores.TabIndex = 3;
            this.btnHiscores.Text = "Hiscores";
            this.btnHiscores.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 137);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnVisitStore
            // 
            this.btnVisitStore.Enabled = false;
            this.btnVisitStore.Location = new System.Drawing.Point(12, 166);
            this.btnVisitStore.Name = "btnVisitStore";
            this.btnVisitStore.Size = new System.Drawing.Size(100, 23);
            this.btnVisitStore.TabIndex = 5;
            this.btnVisitStore.Text = "Visit Store";
            this.btnVisitStore.UseVisualStyleBackColor = true;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 209);
            this.Controls.Add(this.btnVisitStore);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHiscores);
            this.Controls.Add(this.btnMultiPlayer);
            this.Controls.Add(this.btnSinglePlayer);
            this.Controls.Add(this.lblDashboard);
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDashboard_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnSinglePlayer;
        private System.Windows.Forms.Button btnMultiPlayer;
        private System.Windows.Forms.Button btnHiscores;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnVisitStore;
    }
}