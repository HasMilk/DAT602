using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsGame : ClsTable
    {
        private Program p;
        private DbSet<game> _GameList;

        public ClsGame(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "Game";
            DefaultID = "Game_ID";
            DefaultDisplay = new string[] { "Game_ID", "Game_Name", "Game_Type", "Game_TTL" };
            DefaultRead = new string[] { "Game_ID", "Game_Name" };
            DefaultFind = new string[] { "Game_ID" };
            Console.WriteLine(_GameList.Count() + " game records found."); // display the number of records

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
            string lcGameName = args[1].Trim();
            string lcGameType = args[2].Trim();

            if (ForName(lcGameName) != -1) // check game name exists
            {
                Console.WriteLine("Error: game name is already used.");
                return false;
            }

            if (lcGameName.Length < 2) // check game name length
            {
                Console.WriteLine("Error: game name is too short.");
                return false;
            }

            if (lcGameType.Length < 2) // check game password length
            {
                Console.WriteLine("Error: game password is too short.");
                return false;
            }

            //Entities.CreateGame(lcGameName, lcGameType, lcGameTTL); // create the record
            RecordList = _GameList = Entities.games; // reset the record list
            //Console.WriteLine("Game " + lcGameName + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object lcObject)
        {
            game lcGame = (game)lcObject;
            //Entities.UpdateGame(lcGame.Game_ID, lcGame.Game_Name, lcGame.Game_Type, lcGame.Game_TTL);
            RecordList = _GameList = Entities.games; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prGameID)
        {
            //Entities.RemoveGame(prGameID); // delete the record
            RecordList = _GameList = Entities.games; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _GameList = Entities.games; // reset the game list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }

        public int ForName(string prGameName)
        {
            foreach (var game in _GameList) // loop the table
                if (game.Game_Name.ToLower() == prGameName.ToLower()) // check the name
                    return game.Game_ID;
            return -1;
        }

    }
}