using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsNPCGameSession : ClsTable
    {
        private Program p;
        private DbSet<npc_game_session> _GameSessionList;

        public ClsNPCGameSession(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "NPC Game Session";
            DefaultID = "NPC_Game_Session_ID";
            DefaultDisplay = new string[] { "NPC_Game_Session_ID", "Game_Session_ID", "NPC_ID" };
            DefaultRead = new string[] { "NPC_Game_Session_ID", "Game_Session_ID", "NPC_ID", "NPC_X", "NPC_Y", "NPC_Z", "NPC_TTL" };
            DefaultFind = new string[] { "NPC_Game_Session_ID" };
            Console.WriteLine(_GameSessionList.Count() + " npc_game_session records found."); // display the number of records

            CloseConnection();
        }

        public override bool Create(string[] args)
        {
            if (args.Length < 2) // check there is enough arguments
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            // select the game object
            p.Games.OpenConnection();
            object lcGameObject = p.Games.TFind(new string[] { p.Games.DefaultID, args[0] });
            p.Games.CloseConnection();

            if (lcGameObject == null)
            {
                Console.Write("Error: Game" + args[0] + " not found.");
                return false;
            }

            // select the npc object
            p.NPCs.OpenConnection();
            object lcNPCObject = p.NPCs.TFind(new string[] { p.NPCs.DefaultID, args[1] });
            p.NPCs.CloseConnection();

            if (lcNPCObject == null)
            {
                Console.Write("Error: NPC" + args[1] + " not found.");
                return false;
            }

            int lcGameID = base.GetID(lcGameObject);
            int lcNPCID = base.GetID(lcGameObject);

            //Entities.CreateNPCGameSession(lcGameID, lcNPCID); // create the record
            RecordList = _GameSessionList = Entities.npc_game_session; // reset the record list
            //Console.WriteLine("NPC " + lcNPCName + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object lcObject)
        {
            npc_game_session lcGS = (npc_game_session)lcObject;
            //Entities.UpdateNPCGS(lcGS.NPC_Game_Session_ID, lcGS.Game_ID, lcGS.NPC_ID);
            RecordList = _GameSessionList = Entities.npc_game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prGSID)
        {
            //Entities.RemoveNPCGS(prGSID); // delete the record
            RecordList = _GameSessionList = Entities.npc_game_session; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _GameSessionList = Entities.npc_game_session; // reset the npc list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }
    }
}