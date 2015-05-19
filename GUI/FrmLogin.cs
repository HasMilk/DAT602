using System;
using System.Data.Objects;
using System.Drawing;
using System.Windows.Forms;

// Author: Benjamin Rea
// Organisation: NMIT
// Email: le.benjamin.rea@gmail.com

namespace DAT602_GUI
{
    public partial class FrmLogin : Form
    {
        private Program p;
        private string _LastUsername;
        private int _LoginAttempts = 0;

        public FrmLogin(Program p)
        {
            this.p = p;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (wamoleEntities Entities = new wamoleEntities())
            {
                if (txtUsername.Text.Length < 2 || txtPassword.Text.Length < 4)
                {
                    lblDetails.ForeColor = Color.Red;
                    lblDetails.Text = "Invalid username or password!";
                    return;
                }
                ObjectParameter result = new ObjectParameter("prResult", typeof(int));
                btnLogin.Enabled = false;
                Entities.PlayerLogin(result, txtUsername.Text.Trim(), txtPassword.Text);
                btnLogin.Enabled = true;
                switch ((int)result.Value)
                {
                    case 0: //no result
                        Console.WriteLine("Something went wrong");
                        break;

                    case 1: //successful login
                        Console.WriteLine("Success");
                        p.DoLogin(txtUsername.Text);
                        lblDetails.ForeColor = Color.Black;
                        lblDetails.Text = "Please enter username and password:";
                        _LoginAttempts = 0;
                        break;

                    case 2: //incorrect password
                        Console.WriteLine("Incorrect password");
                        _LoginAttempts = _LastUsername == txtUsername.Text.Trim() ? _LoginAttempts + 1 : 0;
                        _LastUsername = txtUsername.Text.Trim();
                        if (_LoginAttempts > 3)
                        {
                            p.DoLockPlayer(_LastUsername);
                            lblDetails.Text = "Your account has been locked due to 5 invalid login attempts";
                        }
                        else
                            lblDetails.Text = "Incorrect username or password!";
                        lblDetails.ForeColor = Color.Red;
                        break;

                    case 3: //player not found
                        Console.WriteLine("Player not found");
                        if (MessageBox.Show(this, "Username does not exist, do you want to create a login with these credentials?", "Player not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            p.DoCreatePlayer(txtUsername.Text, txtPassword.Text);
                            p.DoLogin(txtUsername.Text);
                        }
                        break;

                    case 4: //player not found
                        Console.WriteLine("Player already logged in!");
                        lblDetails.ForeColor = Color.Red;
                        lblDetails.Text = "You are already logged in!";
                        break;

                    case 5: //player locked
                        Console.WriteLine("Player locked");
                        lblDetails.ForeColor = Color.Red;
                        lblDetails.Text = "Your account has been locked";
                        break;

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {

            lblDetails.ForeColor = Color.Black;
            lblDetails.Text = "Please enter username and password:";
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

            lblDetails.ForeColor = Color.Black;
            lblDetails.Text = "Please enter username and password:";
        }
    }
}
