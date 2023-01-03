using Microsoft.VisualBasic;
using Stock_Management_System;
using Stock_Management_System.SQL;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SQLite;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Xml.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Welcome to the Stock Mangement System!");
            Console.WriteLine("Please select an operation you would like to perform:");
            Console.WriteLine(
                "1: Add a component to the system" +
                "\n2: Update a field for a specifc component" +
                "\n3: Quit");

            int optionSelected = int.Parse(Console.ReadLine());
            List<ComponentField> components = new List<ComponentField>();

            switch (optionSelected)
            {
                case 1:
                    Console.WriteLine("Enter a Component:\n" +
                        "Name | Description | Catergory | Stock Level | Minimum Stock Level");
                    string enteredComponent = Console.ReadLine();
                    char[] delimiters = { ',', '|' };
                    string[] partField = enteredComponent.Split(delimiters);

                    //ComponentField Screw = new ComponentField(
                    //    name: partField[0], description: partField[1],
                    //    catergory: partField[2], stockLevel: int.Parse(partField[3]), minStockLevel: int.Parse(partField[4]));
                    ComponentField Bolt = new ComponentField(
                        name: "Bolt", description: "A small metal fastener.",
                        catergory: "Hardware", stockLevel: 300, minStockLevel: 100);
                    components.Add(Bolt);
                    Console.WriteLine("Components Added");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Number");
                    break;
            }


            if (File.Exists("database.db"))
            {
                File.Delete("database.db");
            }
            SQLiteConnection sqlite_conn;
            sqlite_conn = SQLFunctions.CreateConnection();
            SQLFunctions.CreateTable(sqlite_conn);
            SQLFunctions.InsertData(sqlite_conn, components);
            SQLFunctions.ReadData(sqlite_conn);



            updateField(sqlite_conn, "Product_Catergory", "H");
            SQLFunctions.ReadData(sqlite_conn);
            sqlite_conn.Close();
        }

    }
    public static void updateField(SQLiteConnection conn, string column, object value)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();

        sqlite_cmd.CommandText = "UPDATE Stock SET " + column + " = @NewStockLevel WHERE ID = @ID";
        sqlite_cmd.Parameters.AddWithValue("@NewStockLevel", value);
        sqlite_cmd.Parameters.AddWithValue("@ID", 2);
        sqlite_cmd.ExecuteNonQuery();
    }
}
//"(ID INTEGER PRIMARY KEY, " +
//"Part_Name TEXT NOT NULL, " +
//"Part_Description TEXT NOT NULL, " +
//"Product_Catergory TEXT NOT NULL, " +
//"Stock_Level INTERGER NOT NULL, " +
//"Minimum_Stock_Level INTERGER NOT NULL)";