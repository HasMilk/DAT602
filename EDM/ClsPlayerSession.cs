using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsPlayerSession : ClsTable
    {
        private Program p;
        private DbSet<player_session> _SessionList;
        
        public ClsPlayerSession(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Player Session";
            DefaultID = "Player_ID";
            DefaultDisplay = new string[] { "Player_ID", "Player_Start_Time" };
            DefaultRead = new string[] { "Player_ID", "Player_Start_Time", "Player_End_Time" };
            DefaultFind = new string[] { "Player_ID" };
            Console.WriteLine(_SessionList.Count() + " player_session records found."); // display the number of records

            CloseConnection();
        }

        public override Boolean Create(string[] args)
        {
            if (args.Length < 1) // check there is enough arguments
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            // select the player object
            p.Players.OpenConnection();
            object lcObject = p.Players.TFind(new string[] { p.Players.DefaultID, args[0] });
            p.Players.CloseConnection();

            if (lcObject == null)
            {
                Console.Write("Error: Player" + args[0] + " not found.");
                return false;
            }

            int lcPlayerID = base.GetID(lcObject);

            //Entities.PlayerLogin("" + lcPlayerID); // create the record
            RecordList = _SessionList = Entities.player_session; // reset the record list
            //Console.WriteLine("Player session " + lcPlayerID + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object prPlayerObject)
        {
            player_session lcSession = (player_session)prPlayerObject;
            //Entities.UpdatePlayerSession(lcSession.Player_ID, lcSession.Player_Start_Time, lcSession.Player_End_Time); // Update the record
            RecordList = _SessionList = Entities.player_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prPlayerID)
        {
            //Entities.PlayerLogout("" + prPlayerID); // delete the record
            RecordList = _SessionList = Entities.player_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _SessionList = Entities.player_session; // reset the player list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }
    }
}
