using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_EDM
{

    public abstract class ClsTable
    {

        private wamoleEntities _Entities;
        private DbSet _RecordList;
        private String _TableName;
        private String _DefaultID;
        private String[] _DefaultDisplay;
        private String[] _DefaultRead;
        private String[] _DefaultFind;

        public bool Test<E>(E thing) where E : class
        {
            return false;
        }

        public int GetID(object lcObject)
        {
            return Convert.ToInt32(lcObject.GetType().GetProperty(DefaultID).GetValue(lcObject).ToString());
        }

        public void Handle(String prInput)
        {
            string input = prInput;
            string cmd = input.Trim().Split(' ')[0].ToLower();
            string[] args = input.Length == cmd.Length ? new string[0] : input.Substring(cmd.Length).Trim().Split(' ');

            OpenConnection();
            switch (cmd)
            {
                case "display":
                    this.TDisplay(args);
                    break;
                case "create":
                    this.TCreate(args);
                    break;
                case "read":
                    this.TRead(args);
                    break;
                case "update":
                    this.TUpdate(args);
                    break;
                case "delete":
                    this.TDelete(args);
                    break;
                case "find":
                    this.TFind(args);
                    break;
                case "clear":
                    this.TClear();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
            CloseConnection();
        }

        public abstract bool Create(string[] args);
        public abstract void Update(object prObject);
        public abstract void Remove(int prRecordID);
        public abstract void OpenConnection();
        public abstract void CloseConnection();

        public wamoleEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }

        public DbSet RecordList
        {
            get { return _RecordList; }
            set { _RecordList = value; }
        }

        public String TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        public String DefaultID
        {
            get { return _DefaultID; }
            set { _DefaultID = value; }
        }

        public String[] DefaultDisplay
        {
            get { return _DefaultDisplay; }
            set { _DefaultDisplay = value; }
        }

        public String[] DefaultRead
        {
            get { return _DefaultRead; }
            set { _DefaultRead = value; }
        }

        public String[] DefaultFind
        {
            get { return _DefaultFind; }
            set { _DefaultFind = value; }
        }
    }

    public static class ClsUtility
    {
        internal static int Count(this DbSet dbSet)
        {
            int count = 0;
            foreach (var record in dbSet)
                count += 1;
            return count;
        }

        internal static void TDisplay(this ClsTable table, string[] cols)
        {
            if (cols.Length == 0)
                cols = table.DefaultDisplay;

            Console.WriteLine();
            Console.WriteLine(table.TableName + "s : " + table.RecordList.Count() + " records");

            Console.WriteLine();
            foreach (string col in cols)
                Console.Write(col + "\t");

            Console.WriteLine();
            foreach (var record in table.RecordList)
            {
                foreach (string col in cols)
                    Console.Write(record.GetType().GetProperty(col).GetValue(record) + "\t");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        internal static bool TCreate(this ClsTable table, string[] args)
        {
            try
            {
                return table.Create(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": please check arguments.");
            }

            return false;
        }

        internal static bool TRead(this ClsTable table, string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            object lcObject = table.TFind(args);

            if (lcObject == null)
                return false;

            Console.WriteLine();
            Console.WriteLine(table.TableName + " : " + table.GetID(lcObject));
            Console.WriteLine();
            foreach (string prop in table.DefaultRead)
            {
                Console.WriteLine(prop + ":\t" + lcObject.GetType().GetProperty(prop).GetValue(lcObject).ToString());
            }

            return true;
        }

        internal static bool TUpdate(this ClsTable table, string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            object lcObject = table.TFind(args);
            if (lcObject == null)
                return false;

            int lcID = table.GetID(lcObject);
            string lcType = args[args.Length < 3 ? 1 : 2].Trim();
            string lcValue = args[args.Length < 3 ? 2 : 3].Trim();

            try
            {
                lcObject.GetType().GetProperty(lcType).SetValue(lcObject, lcValue);
                table.Update(lcObject);
                Console.WriteLine(table.TableName + " " + lcID + " successfully updated.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": please check arguments.");
            }

            return false;
        }

        internal static Boolean TDelete(this ClsTable table, string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return false;
            }

            object lcObject = table.TFind(args);
            if (lcObject == null)
                return false;

            int lcID = table.GetID(lcObject);

            Console.WriteLine("Warning: are you sure you want to delete " + table.TableName + " record " + lcID + "? Y or N:"); // confirm the record deletion
            if (Console.ReadLine().ToLower() != "y")
            {
                Console.WriteLine(table.TableName + " deletion aborted.");
                return false;
            }

            table.Remove(lcID);
            Console.WriteLine(table.TableName + " " + lcID + " successfully deleted.");
            return true;
        }

        internal static object TFind(this ClsTable table, string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Inccorect syntax: argument(s) missing.");
                return null;
            }

            if (args.Length < 2)
                Console.WriteLine("Using Default ID.");

            string lcType = args.Length < 2 ? table.DefaultID : args[0].Trim();
            string lcValue = args[args.Length < 2 ? 0 : 1].Trim().ToLower();
            object lcObject = null;


            // check the property is allowed to be used
            if (!table.DefaultFind.Contains(lcType))
            {
                Console.WriteLine("'" + lcType + "' cannot be used: please check arguments.");
                return null;
            }

            try
            {
                foreach (var record in table.RecordList)
                    if (record.GetType().GetProperty(lcType).GetValue(record).ToString().ToLower() == lcValue)
                        lcObject = record;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": please check arguments.");
            }

            Console.WriteLine(lcObject == null ?
                table.TableName + " not found." :
                table.TableName + " " + table.GetID(lcObject) + " found.");

            return lcObject;
        }

        internal static void TClear(this ClsTable table)
        {
            Console.WriteLine("Warning: are you sure you want to clear all " + table.TableName + " records? Y or N:");
            if (Console.ReadLine().ToLower() != "y")
            {
                Console.WriteLine(table.TableName + " deletion aborted.");
                return;
            }

            using (table.Entities = new wamoleEntities())
            {
                foreach (var record in table.RecordList)
                {
                    table.Remove(table.GetID(record));
                }
                Console.WriteLine("All " + table.TableName + " records cleared successfully.");
                table.CloseConnection();
            }
        }

    }
}
