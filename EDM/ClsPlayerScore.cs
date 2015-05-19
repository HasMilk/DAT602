using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsPlayerScore : ClsTable
    {
        private Program p;
        private DbSet<player_score> _PlayerScoreList;

        public ClsPlayerScore(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Player_Score";
            DefaultID = "Player_ID";
            DefaultDisplay = new string[] { "Player_ID", "Player_Hits", "Player_Misses" };
            DefaultRead = new string[] { "Player_ID", "Player_Hits", "Player_Misses", "Player_Wins", "Player_Losses", "Player_Ties" };
            DefaultFind = new string[] { "Player_ID" };
            Console.WriteLine(_PlayerScoreList.Count() + " player_score records found."); // display the number of records

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

            //Entities.CreatePlayerScore(lcPlayerID); // create the record
            RecordList = _PlayerScoreList = Entities.player_score; // reset the record list
            //Console.WriteLine("Player score" + lcPlayerID + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object prPlayerObject)
        {
            player lcPlayer = (player)prPlayerObject;
            player_session lcSession = (player_session)prPlayerObject;
            //Entities.UpdatePlayerScore(lcSession.Player_ID, Player_Hits, Player_Misses, Player_Wins, Player_Losses, Player_Ties); // Update the record
            RecordList = _PlayerScoreList = Entities.player_score; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prPlayerID)
        {
            //Entities.RemovePlayerScore(prPlayerID); // delete the record
            RecordList = _PlayerScoreList = Entities.player_score; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _PlayerScoreList = Entities.player_score; // reset the player list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }
    }
}
