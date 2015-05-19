using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{
    public class Program
    {
        public ClsPlayer Players;
        public ClsPlayerScore PlayerScore;
        public ClsPlayerSession PlayerSessions;
        public ClsGame Games;
        public ClsGameSession GameSessions;
        public ClsPlayerGameSession PlayerGameSessions;
        public ClsNPC NPCs;
        public ClsNPCGameSession NPCGameSessions;
        
        static void Main(string[] args)
        {
            new Program().run();
        }

        private Program()
        {
            Console.Title = "EDMTest";
            Console.WriteLine("Starting up...");
            Console.WriteLine();
            Players = new ClsPlayer(this);
            PlayerScore = new ClsPlayerScore(this);
            PlayerSessions = new ClsPlayerSession(this);
            Games = new ClsGame(this);
            GameSessions = new ClsGameSession(this);
            PlayerGameSessions = new ClsPlayerGameSession(this);
            NPCs = new ClsNPC(this);
            NPCGameSessions = new ClsNPCGameSession(this);
            Console.WriteLine();
            Console.WriteLine("Ready.");
        }

        private void run()
        {
            bool running = true;
            while (running)
            {

                Console.WriteLine("");
                string input = Console.ReadLine().Trim();
                string cmd = input.Split(' ')[0].ToLower();
                string[] args = input.Substring(cmd.Length).Trim().Split(' ');
                
                using (wamoleEntities Entities = new wamoleEntities())
                {
                    switch (cmd)
                    {
                        case "":
                            break;

                        case "exit":
                            running = false;
                            break;

                        case "cls":
                            Console.Clear();
                            break;

                        case "test":
                            ObjectParameter result = new ObjectParameter("prResult", -1);
                            Entities.PlayerLogin("1", "pass", result);
                            Console.WriteLine(result.Value);
                            break;

                        case "help":
                            Console.WriteLine();
                            Console.WriteLine("Help menu:");
                            Console.WriteLine();
                            Console.WriteLine("Console commands:");
                            Console.WriteLine("exit\t\texit the program");
                            Console.WriteLine("cls\t\tclear the console");
                            Console.WriteLine();
                            Console.WriteLine("EDM commands:");
                            Console.WriteLine(".display\tDisplay the records of a table");
                            Console.WriteLine(".create\t\tCreate a new record in the table");
                            Console.WriteLine(".read\t\tRead a record of a table");
                            Console.WriteLine(".update\t\tUpdate a record in the table");
                            Console.WriteLine(".delete\t\tDelete a record from the table");
                            Console.WriteLine(".clear\t\tDelete ALL records from the table");
                            Console.WriteLine(".find\t\tFind a record in the table");
                            Console.WriteLine();
                            Console.WriteLine("EDM command usage:");
                            Console.WriteLine("Begin with the name of a table, followed by the EDM command");
                            Console.WriteLine("eg\tplayers.display");
                            Console.WriteLine("or\tplayers.create HasMilk pass123");
                            Console.WriteLine();
                            Console.WriteLine("EDM tables:");
                            Console.WriteLine("Table name\t\tAccessor");
                            Console.WriteLine("Player\t\t\tplayers");
                            Console.WriteLine("Player_Score\t\tscores");
                            Console.WriteLine("Player_Session\t\tp_sessions");
                            Console.WriteLine("Game\t\t\tgames");
                            Console.WriteLine("Game_Session\t\tg_sessions");
                            Console.WriteLine("Player_Game_Session\tpg_sessions");
                            Console.WriteLine("NPC\t\t\tnpcs");
                            Console.WriteLine("NPC_Game_Session\tnpcg_sessions");
                            Console.WriteLine();
                            break;

                        case "players.display":
                        case "players.create":
                        case "players.read":
                        case "players.update":
                        case "players.delete":
                        case "players.clear":
                        case "players.find":
                            Players.Handle(input.Substring("players.".Length));
                            break;

                        case "scores.display":
                        case "scores.create":
                        case "scores.read":
                        case "scores.update":
                        case "scores.delete":
                        case "scores.clear":
                        case "scores.find":
                            PlayerScore.Handle(input.Substring("scores.".Length));
                            break;

                        case "p_sessions.display":
                        case "p_sessions.create":
                        case "p_sessions.read":
                        case "p_sessions.update":
                        case "p_sessions.delete":
                        case "p_sessions.clear":
                        case "p_sessions.find":
                            PlayerSessions.Handle(input.Substring("p_sessions.".Length));
                            break;

                        case "games.display":
                        case "games.create":
                        case "games.read":
                        case "games.update":
                        case "games.delete":
                        case "games.clear":
                        case "games.find":
                            Games.Handle(input.Substring("games.".Length));
                            break;

                        case "g_sessions.display":
                        case "g_sessions.create":
                        case "g_sessions.read":
                        case "g_sessions.update":
                        case "g_sessions.delete":
                        case "g_sessions.clear":
                        case "g_sessions.find":
                            GameSessions.Handle(input.Substring("g_sessions.".Length));
                            break;

                        case "pg_sessions.display":
                        case "pg_sessions.create":
                        case "pg_sessions.read":
                        case "pg_sessions.update":
                        case "pg_sessions.delete":
                        case "pg_sessions.clear":
                        case "pg_sessions.find":
                            PlayerGameSessions.Handle(input.Substring("pg_sessions.".Length));
                            break;

                        case "npcs.display":
                        case "npcs.create":
                        case "npcs.read":
                        case "npcs.update":
                        case "npcs.delete":
                        case "npcs.clear":
                        case "npcs.find":
                            NPCs.Handle(input.Substring("npcs.".Length));
                            break;

                        case "npcg_sessions.display":
                        case "npcg_sessions.create":
                        case "npcg_sessions.read":
                        case "npcg_sessions.update":
                        case "npcg_sessions.delete":
                        case "npcg_sessions.clear":
                        case "npcg_sessions.find":
                            NPCGameSessions.Handle(input.Substring("npcg_sessions.".Length));
                            break;

                        default:
                            Console.WriteLine("Unrecognized command.");
                            break;

                    }
                }
            }

            Environment.Exit(0);
        }

    }
}