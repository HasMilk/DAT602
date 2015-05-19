using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsPlayerGameSession : ClsTable
    {
        private Program p;
        private DbSet<player_game_session> _GameSessionList;

        public ClsPlayerGameSession(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Player Game Session";
            DefaultID = "Player_ID";
            DefaultDisplay = new string[] { "Game_Session_ID", "Player_ID" };
            DefaultRead = new string[] { "Game_Session_ID", "Player_ID", "Player_X", "Player_Y", "Player_Hits", "Player_Misses" };
            DefaultFind = new string[] { "Game_Session_ID", "Player_ID" };
            Console.WriteLine(_GameSessionList.Count() + " player_game_session records found."); // display the number of records

            CloseConnection();
        }

        public override bool Create(string[] args)
        {
            if (args.Length < 2) // check there is enough arguments
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            // select the game session object
            p.GameSessions.OpenConnection();
            object lcGameObject = p.GameSessions.TFind(new string[] { p.GameSessions.DefaultID, args[0] });
            p.GameSessions.CloseConnection();

            if (lcGameObject == null)
            {
                Console.Write("Error: Game" + args[0] + " not found.");
                return false;
            }

            // select the player object
            p.Players.OpenConnection();
            object lcPlayerObject = p.Players.TFind(new string[] { p.Players.DefaultID, args[1] });
            p.Players.CloseConnection();

            if (lcPlayerObject == null)
            {
                Console.Write("Error: Player" + args[1] + " not found.");
                return false;
            }

            int lcGameSessionID = base.GetID(lcGameObject);
            int lcPlayerID = base.GetID(lcPlayerObject);

            //Entities.CreatePlayerGameSession(prGameSessionID, prPlayerID); // create the record
            RecordList = _GameSessionList = Entities.player_game_session; // reset the record list
            //Console.WriteLine("Player Game Session " + lcGameSessionID + ", " + lcPlayerID + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object lcObject)
        {
            player_game_session lcGS = (player_game_session)lcObject;
            //Entities.UpdatePGS(lcGS.Game_Session_ID, lcGS.Player_ID);
            RecordList = _GameSessionList = Entities.player_game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prGSID)
        {
            //Entities.RemovePGS(prGSID); // delete the record
            RecordList = _GameSessionList = Entities.player_game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _GameSessionList = Entities.player_game_session; // reset the record list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }
    }
}