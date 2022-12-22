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
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Stock Mangement System!");
        Console.WriteLine("Please select an operation you would like to perform:");
        Console.WriteLine(
            "1: Add a component to the system" +
            "\n2: Update a field for a specifc component");

        int optionSelected = int.Parse(Console.ReadLine());

        switch (optionSelected)
        {
            case 1:
                Console.WriteLine("1");
                break;
            case 2:
                Console.WriteLine("2");
                break;
            default:
                Console.WriteLine("Invalid Number");
                break;
        }
        ComponentField Screw = new ComponentField(
            name: "Screw", description: "A small metal fastener.",
            catergory: "Hardware", stockLevel: 100, minStockLevel: 50);
        ComponentField Bolt = new ComponentField(
            name: "Bolt", description: "A small metal fastener.",
            catergory: "Hardware", stockLevel: 300, minStockLevel: 100);

        List<ComponentField> components = new List<ComponentField>();

        components.Add(Screw);
        components.Add(Bolt);


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