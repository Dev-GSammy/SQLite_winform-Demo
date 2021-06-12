using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FoodMataDemo
{
    class Database
    {
        public SQLiteConnection myConn;
       
        string dataBaseName = "Foodmata.sqlite";
        public Database()
        {
            myConn = new SQLiteConnection("Data Source = " + dataBaseName);
            if (!File.Exists("./"+ dataBaseName))
            {
                SQLiteConnection.CreateFile(dataBaseName);
            }
        }
        public void openConnection()
        {
            if (myConn.State != System.Data.ConnectionState.Open)
            {
                myConn.Open();
            }
        }
        public void closeConnection()
        {
            if (myConn.State != System.Data.ConnectionState.Closed)
            {
                myConn.Close();
            }
        }
       
        public void InsertData(string name, string location, string phoneNo, string accountName, long accountNo, string bank, string website )
        {
            string query = "INSERT INTO Restaurants ('Name', 'Location', 'Phone No', " +
                "'Account Name', 'Account No', 'Bank', 'Website') VALUES (@N, @L, @P, @AN, @AC, @B, @W);";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(query, myConn);
            openConnection();

            sQLiteCommand.Parameters.AddWithValue("@N",name);
            sQLiteCommand.Parameters.AddWithValue("@L",location);
            sQLiteCommand.Parameters.AddWithValue("@P",phoneNo);
            sQLiteCommand.Parameters.AddWithValue("@AN",accountName);
            sQLiteCommand.Parameters.AddWithValue("@AC",accountNo);
            sQLiteCommand.Parameters.AddWithValue("@B",bank);
            sQLiteCommand.Parameters.AddWithValue("@W",website);

            sQLiteCommand.ExecuteNonQuery().ToString();
            closeConnection();
        }
    }
}
