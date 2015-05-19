using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Benjamin Rea
// Organisation: NMIT
// Email: le.benjamin.rea@gmail.com

namespace DAT602_GUI
{
    public class ClsPlayer : ClsTable
    {
        private Program p;
        private DbSet<player> _PlayerList;

        public ClsPlayer(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Player";
            DefaultID = "Player_ID";
            DefaultDisplay = new string[] { "Player_ID", "Player_Name" };
            DefaultRead = new string[] { "Player_ID", "Player_Name", "Player_Password", "Player_Login_Attempts", "Player_Locked" };
            DefaultFind = new string[] { "Player_ID", "Player_Name" };
            Console.WriteLine(_PlayerList.Count() + " player records found."); // display the number of records

            CloseConnection();
        }

        public override Boolean Create(string[] args)
        {
            if (args.Length < 2) // check there is enough arguments
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            // set local variables from arguments
            string lcPlayerName = args[0].Trim();
            string lcPlayerPassword = args[1].Trim();

            if (ForName(lcPlayerName) != -1) // check player name exists
            {
                Console.WriteLine("Error: player name is already used.");
                return false;
            }

            if (lcPlayerName.Length < 2) // check player name length
            {
                Console.WriteLine("Error: player name is too short.");
                return false;
            }

            if (lcPlayerPassword.Length < 4) // check player password length
            {
                Console.WriteLine("Error: player password is too short.");
                return false;
            }

            Entities.CreatePlayer(lcPlayerName, lcPlayerPassword); // create the record
            RecordList = _PlayerList = Entities.players; // reset the record list
            Console.WriteLine("Player " + lcPlayerName + " successfully created.");
            return true;
        }

        public override void Update(object prPlayerObject)
        {
            player lcPlayer = (player)prPlayerObject;
            Entities.UpdatePlayer(lcPlayer.Player_ID, lcPlayer.Player_Name, lcPlayer.Player_Password, lcPlayer.Player_Login_Attempts, Convert.ToSByte(lcPlayer.Player_Locked)); // Update the record
            RecordList = _PlayerList = Entities.players; // reset the record list
        }

        public override void Remove(int prPlayerID)
        {
            Entities.RemovePlayer(prPlayerID); // delete the record
            RecordList = _PlayerList = Entities.players; // reset the record list
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _PlayerList = Entities.players; // reset the player list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }

        public int ForName(string prPlayerName)
        {
            OpenConnection();
            foreach (var player in _PlayerList) // loop the player table
                if (player.Player_Name.ToLower() == prPlayerName.ToLower()) // check the name
                    return player.Player_ID;
            CloseConnection();
            return -1;
        }

    }
}
