using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;


namespace DATA_C_
{
    internal class DataBase
    {
        private static DataBase instance;
        private string connectionString;

        private DataBase(string connectionString) // Теперь принимает connection string
        {
            this.connectionString = connectionString; // Сохраняем строку подключения
        }

        public static DataBase GetInstance(string connectionString = "Data Source=C:\\Users\\Lemon_Russ\\Desktop\\БД\\Приложение\\DATA C#\\first10.db;") // замените строку подключения
        {
            if (instance == null)
            {
                instance = new DataBase(connectionString);
            }
            return instance;
        }

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString); // Создаем новое соединение каждый раз

            // Включение поддержки внешних ключей
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
            {
                command.ExecuteNonQuery();
            }
            return connection;  // Возвращаем новое соединение
        }
    }
}