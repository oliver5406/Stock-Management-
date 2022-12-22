﻿using System.Data.Entity;
using System.Data.SQLite;

internal class Program
{
    private static void Main(string[] args)
    {
        if (File.Exists("database.db"))
        {
            File.Delete("database.db");
        }
        SQLiteConnection sqlite_conn;
        sqlite_conn = CreateConnection();
        CreateTable(sqlite_conn);
        //InsertData(sqlite_conn);
        ReadData(sqlite_conn);

    }
    static SQLiteConnection CreateConnection()
    {

        SQLiteConnection sqlite_conn;
        // Create a new database connection:
        sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
        try
        {
            sqlite_conn.Open();
        }
        catch (Exception ex)
        {

        }
        return sqlite_conn;
    }

    static void CreateTable(SQLiteConnection conn)
    {

        SQLiteCommand sqlite_cmd;
        string Createsql = "CREATE TABLE Stock " +
            "(ID INTEGER PRIMARY KEY, " +
            "Part_Name TEXT NOT NULL, " +
            "Part_Description TEXT NOT NULL, " +
            "Product_Catergory TEXT NOT NULL, " +
            "Stock_Level INTERGER NOT NULL, " +
            "Minimum_Stock_Level INTERGER NOT NULL)";
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = Createsql;
        sqlite_cmd.ExecuteNonQuery();


    }

    static void InsertData(SQLiteConnection conn)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd=conn.CreateCommand();
    }

    //static void InsertData(SQLiteConnection conn)
    //{
    //    SQLiteCommand sqlite_cmd;
    //    sqlite_cmd = conn.CreateCommand();
    //    sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test Text ', 1); ";
    //     sqlite_cmd.ExecuteNonQuery();
    //    sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test1 Text1 ', 2); ";
    //     sqlite_cmd.ExecuteNonQuery();
    //    sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test2 Text2 ', 3); ";
    //     sqlite_cmd.ExecuteNonQuery();


    //    sqlite_cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
    //     sqlite_cmd.ExecuteNonQuery();

    //}

    static void ReadData(SQLiteConnection conn)
    {
        SQLiteDataReader sqlite_datareader;
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM Stock";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
        }
        conn.Close();
    }
}
