using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Benjamin Rea
// Organisation: NMIT
// Email: le.benjamin.rea@gmail.com

namespace DAT602_GUI
{
    public class Program
    {
        public FrmLogin LoginForm;
        public FrmDashboard DashboardForm;
        public FrmLobby LobbyForm;
        public ClsPlayer Player;
        private int _PlayerID = -1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program().LoginForm);
        }

        public Program()
        {
            LoginForm = new FrmLogin(this);
            DashboardForm = new FrmDashboard(this);
            LobbyForm = new FrmLobby(this);
            Player = new ClsPlayer(this);
        }

        public void DoCreatePlayer(string prPlayerName, string prPassword)
        {
            using (wamoleEntities Entities = new wamoleEntities())
            {
                Entities.CreatePlayer(prPlayerName, prPassword);
            }
        }

        public void DoLogin(string prPlayerName)
        {
            using (wamoleEntities Entities = new wamoleEntities())
            {
                PlayerID = Player.ForName(prPlayerName);
                LoginForm.Hide();
                DashboardForm.Show();
            }
        }

        public void DoLogout()
        {
            using (wamoleEntities Entities = new wamoleEntities())
            {
                Entities.PlayerLogout(PlayerID);

                DashboardForm.Hide();
                LoginForm.Show();
            }
        }

        public void DoLockPlayer(string prPlayerName)
        {
            using (wamoleEntities Entities = new wamoleEntities())
            {
                Entities.LockPlayer(Player.ForName(prPlayerName));
            }
        }

        public int PlayerID
        {
            get { return _PlayerID; }
            set { _PlayerID = value; }
        }

    }
}
