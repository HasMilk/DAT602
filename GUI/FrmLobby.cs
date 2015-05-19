using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;

namespace DAT602_GUI
{
    public partial class FrmLobby : Form
    {
        private Program p;

        public FrmLobby(Program p)
        {
            this.p = p;
            InitializeComponent();
        }

        public void Show(IWin32Window owner)
        {
            UpdateDisplay();
            base.Show(owner);
        }
        
        private void FrmLobby_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            PopulateList();
        }

        private void PopulateList()
        {
            using (var Entities = new wamoleEntities())
            {
                Entities.player_session.ToList();
                lstPlayers.DataSource = null;

                List<string> list = new List<string>();
                foreach (player_session lcPS in Entities.player_session.Local) {
                    string lcStr = lcPS.player.Player_Name;
                    lcStr += "\t\t" + (lcPS.player.player_game_session.Count > 0 ? "IN GAME" : "AVAILABLE");
                    list.Add(lcStr);
                    //Console.WriteLine(lcPS.player.player_game_session.Count);
                }
                lstPlayers.DataSource = list;
            }
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            ChallengePlayer();
        }

        private void ChallengePlayer()
        {
            if (lstPlayers.SelectedValue == null)
            {
                Console.WriteLine("No player selected to challenge.");
                return;
            }
            
            using (var Entities = new wamoleEntities())
            {
                string selected = (string) lstPlayers.SelectedValue;
                int lcPID = p.Player.ForName(selected.Split('\t')[0]);
                ObjectParameter lcResult = new ObjectParameter("prResult", typeof(int));
                Entities.ChallengePlayer(p.PlayerID, lcPID, lcResult);
                switch ((int)lcResult.Value)
                {
                    case 0: //no result
                        Console.WriteLine("Something went wrong");
                        break;

                    case 1: //challenge made
                        Console.WriteLine("Challenge was made");
                        break;

                    case 2: //challenge accepted
                        Console.WriteLine("Challenge was accepted");
                        break;

                    case 3: //challenge declined
                        Console.WriteLine("Challenge was declined");
                        break;

                    case 4: //other play busy
                        Console.WriteLine("Other player busy");
                        break;
                }
            }

        }

        private void btnQuick_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            p.DashboardForm.Show();
        }

        private void lstPlayers_DoubleClick(object sender, EventArgs e)
        {
            ChallengePlayer();
        }
    }
}
