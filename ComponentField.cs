using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System
{
    internal class ComponentField
    {
        private int stockID;
        private string productName;
        private string description;
        private string catergory;
        private int stockLevel;
        private int minStockLevel;

        public int StockID
        {
            get { return stockID; }
            set { stockID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Catergory
        {
            get { return catergory; }
            set { catergory = value; }
        }
        public int StockLevel
        {
            get { return stockLevel; }
            set { stockLevel = value; }
        }
        public int MinStockLevel
        {
            get { return minStockLevel; }
            set { minStockLevel = value; }
        }

        public ComponentField(
            int sID, string name, string description, string catergory, int stockLevel, int minStockLevel)
        {
            StockID = sID;
            ProductName = name;
            Description = description;
            Catergory = catergory;
            StockLevel = stockLevel;
            MinStockLevel = minStockLevel;
        }
    }
}

