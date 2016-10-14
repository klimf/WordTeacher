using System;
using System.Linq;
using MySql.Data.MySqlClient;

namespace WordTeacher
{
    public class MySQL : IConnect
    {
        string dateBase;
        string serverAdress;
        string user;
        string password;
        public string connect;
        public int maxElems = 100;

        public MySQL(string dateBase, string serverAdress, string user, string password)
        {
            this.dateBase = dateBase;
            this.serverAdress = serverAdress;
            this.user = user;
            this.password = password;
            connect = "Database=" + dateBase + ";Data Source=" + serverAdress + ";User Id=" + user + ";Password=" + password;
        }
        public string Connect(string commandText, string GetOrSet)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(commandText, connection);
            string result = commandText;
            connection.Open();
            if (GetOrSet == "get")
                result = command.ExecuteScalar().ToString();
            else if (GetOrSet == "set")
                command.ExecuteNonQuery();
            else
                result = "error";
            connection.Close();
            return result;
        }
        public string AddString(string table, params string[] array)
        {
            if (array.Length % 2 == 0)
            {
                var id = GetMaxId(table) + 1;
                string command = "INSERT INTO " + table + " ( ";// + "a1, a2, a3 ) VALUES('" + id + "')";
                int i;
                for (i = 0; i < array.Length-2; i++)
                    if (i % 2 == 0) command += array[i] + ", ";
                command += array[i] + " ) VALUES(";
                for (i = 0; i < array.Length-2; i++)
                    if (i % 2 != 0) command += "'" + array[i] + "', ";
                command += "'" + array[i + 1] + "')";
                Connect(command, "set");
                return command;
            }
            else
                return "error";
        }
        
        public string GetFieldValueById(string table, string field, int id)
        {
            return GetFieldValueByField(table, field, "id", id + "");
        }
        public string SetFieldValue(string table, string field, string value)
        {
            return Connect("INSERT INTO " + table + " (" + field + ") VALUES('" + value + "')", "set");
        }
        public string SetFieldValueById(string table, int id, string field, string value)
        {
            return Connect("UPDATE " + table + " SET " + field + " = '" + value + "' WHERE id = '" + id + "'", "set");
        }
        public string UpdateFieldValueById(string table, int id, string field, string value)
        {
            return Connect("UPDATE " + table + " SET " + field + " = CONCAT(" + field + ", '" + value + "') WHERE id = '" + id + "'", "set");
        }
        public string GetFieldValueByField(string table, string field, string fieldFind, string fieldValue)
        {
            return Connect("SELECT " + field + " FROM " + table + " WHERE " + fieldFind + " = '" + fieldValue + "'", "get");
        }
        public int GetMaxId(string table)
        {
            return int.Parse(Connect("SELECT COUNT(*) FROM " + table, "get"));
        }
        public string DeleteValue(string nameOfValue)
        {
            return Connect("DELETE FROM Variations WHERE name = '" + nameOfValue + "'", "set");
        }
        public override string ToString()
        {
            return string.Format("User:{0}, Password:{1}", user, password);
        }
    }
}
