using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System.SQL
{
    public class SQLFunctions
    {
        public static SQLiteConnection CreateConnection()
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
        public static void CreateTable(SQLiteConnection conn)
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
        public static void InsertData(SQLiteConnection conn, List<ComponentField> components)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Stock (Part_Name, Part_Description, Product_Catergory, Stock_Level, Minimum_Stock_Level) " +
                "VALUES (@PartName, @PartDescription, @ProductCategory, @StockLevel, @MinimumStockLevel)";

            foreach (ComponentField component in components)
            {
                sqlite_cmd.Parameters.AddWithValue("@PartName", component.ProductName);
                sqlite_cmd.Parameters.AddWithValue("@PartDescription", component.Description);
                sqlite_cmd.Parameters.AddWithValue("@ProductCategory", component.Catergory);
                sqlite_cmd.Parameters.AddWithValue("@StockLevel", component.StockLevel);
                sqlite_cmd.Parameters.AddWithValue("@MinimumStockLevel", component.MinStockLevel);
                sqlite_cmd.ExecuteNonQuery();
            }
        }
        public static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Stock";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int id = sqlite_datareader.GetInt32(0);
                string partName = sqlite_datareader.GetString(1);
                string partDescription = sqlite_datareader.GetString(2);
                string productCategory = sqlite_datareader.GetString(3);
                int stockLevel = sqlite_datareader.GetInt32(4);
                int minimumStockLevel = sqlite_datareader.GetInt32(5);
                Console.WriteLine($"{id}: {partName} ({productCategory}), Stock Level: {stockLevel}, Minimum Stock Level: {minimumStockLevel}");
                Console.WriteLine(sqlite_datareader);
            }
        }
    }
}