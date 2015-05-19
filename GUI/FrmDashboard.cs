using System;
using System.Windows.Forms;

// Author: Benjamin Rea
// Organisation: NMIT
// Email: le.benjamin.rea@gmail.com

namespace DAT602_GUI
{
    public partial class FrmDashboard : Form
    {
        private Program p;

        public FrmDashboard(Program p)
        {
            this.p = p;
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            p.DoLogout();
        }

        private void FrmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show(this, "Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                p.DoLogout();
            }
        }

        private void btnMultiPlayer_Click(object sender, EventArgs e)
        {
            Hide();
            p.LobbyForm.Show(this);
        }
    }
}
