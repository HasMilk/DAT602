using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class ClsNPC : ClsTable
    {
        private Program p;
        private DbSet<npc> _NPCList;

        public ClsNPC(Program p)
        {
            this.p = p;
            OpenConnection();

            TableName = "NPC";
            DefaultID = "NPC_ID";
            DefaultDisplay = new string[] { "NPC_ID", "NPC_Name", "NPC_Type" };
            DefaultRead = new string[] { "NPC_ID", "NPC_Name", "NPC_Type" };
            DefaultFind = new string[] { "NPC_ID" };
            Console.WriteLine(_NPCList.Count() + " npc records found."); // display the number of records

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
            string lcNPCName = args[0].Trim();
            string lcNPCType = args[1].Trim();

            if (ForName(lcNPCName) != -1) // check npc name exists
            {
                Console.WriteLine("Error: npc name is already used.");
                return false;
            }

            if (lcNPCName.Length < 2) // check npc name length
            {
                Console.WriteLine("Error: npc name is too short.");
                return false;
            }

            if (lcNPCType.Length < 4) // check npc password length
            {
                Console.WriteLine("Error: npc type is too short.");
                return false;
            }

            //Entities.CreateNPC(lcNPCName, lcNPCType); // create the record
            RecordList = _NPCList = Entities.npcs; // reset the record list
            //Console.WriteLine("NPC " + lcNPCName + " successfully created.");
            Console.Write("This function does not currently do anything.");
            return true;
        }

        public override void Update(object lcObject)
        {
            npc lcNPC = (npc)lcObject;
            //Entities.UpdateNPC(lcNPC.NPC_ID, lcNPC.NPC_Name, lcNPC.NPC_Type);
            RecordList = _NPCList = Entities.npcs; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void Remove(int prNPCID)
        {
            //Entities.RemoveNPC(prNPCID); // delete the record
            RecordList = _NPCList = Entities.npcs; // reset the record list
            Console.Write("This function does not currently do anything.");
        }

        public override void OpenConnection()
        {
            Entities = new wamoleEntities(); // create the connection
            RecordList = _NPCList = Entities.npcs; // reset the npc list
        }

        public override void CloseConnection()
        {
            if (Entities != null)
                Entities.Dispose(); // dispose the connection
        }

        public int ForName(string prNPCName)
        {
            foreach (var npc in _NPCList) // loop the table
                if (npc.NPC_Name.ToLower() == prNPCName.ToLower()) // check the name
                    return npc.NPC_ID;
            return -1;
        }

    }
}