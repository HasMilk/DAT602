using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsGameSession : ClsTable
    {
        private Program p;
        private DbSet<game_session> _SessionList;

        public ClsGameSession(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Game_Session";
            DefaultID = "Game_Session_ID";
            DefaultDisplay = new string[] { "Game_Session_ID", "Game_ID", "Game_Start_Time", "Game_End_Time" };
            DefaultRead = new string[] { "Game_Session_ID", "Game_ID", "Game_Start_Time" };
            DefaultFind = new string[] { "Game_Session_ID" };
            Console.WriteLine(_SessionList.Count() + " game_session records found."); // display the number of records
            CloseConnection();
        }

        public override bool Create(string[] args)
        {
            if (args.Length < 2) // check there is enough arguments
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            // set local variables from arguments
            object lcObject = this.TFind(args);

            if (lcObject == null)
                return false;

            //Entities.CreateGameSession(lcGameSessionID, lcGameID); // create the record
            RecordList = _SessionList = Entities.game_session; // reset the record list
            //Console.WriteLine("Game Session " + lcGameName + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object lcObject)
        {
            game lcGame = (game)lcObject;
            //Entities.UpdateGame(lcGame.Game_ID, lcGame.Game_Name, lcGame.Game_Type, lcGame.Game_TTL);
            RecordList = _SessionList = Entities.game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prPlayerID)
        {
            //Entities.RemoveGame(prPlayerID); // delete the record
            RecordList = _SessionList = Entities.game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _SessionList = Entities.game_session; // reset the game list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }
    }
}
