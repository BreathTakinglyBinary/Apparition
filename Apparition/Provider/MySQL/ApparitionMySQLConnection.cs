using MySql.Data.MySqlClient;
using System;

namespace Apparition.Provider.MySQL {
    class ApparitionMySQLConnection {
        private MySqlConnection connection;
        private string databaseName;
        private string host;
        private string password;
        private string port;
        private string userName;

        public ApparitionMySQLConnection() {
            databaseName = Environment.GetEnvironmentVariable("APPARITION_DATABASE_NAME");
            host = Environment.GetEnvironmentVariable("APPARITION_HOST");
            password = Environment.GetEnvironmentVariable("APPARITION_PASSWORD");
            port = Environment.GetEnvironmentVariable("APPARITION_PORT");
            userName = Environment.GetEnvironmentVariable("APPARITION_USER_NAME");

            connection = new MySqlConnection(getConnectionString());
        }

        private string getConnectionString() {
            string Server;

            if (String.IsNullOrEmpty(databaseName)) {
                databaseName = "apparition";
            }
            if (String.IsNullOrEmpty(host)) {
                Server = "localhost";
            } else {
                Server = host;
            }
            if (String.IsNullOrEmpty(password)) {
                password = "password";
            }

            if (String.IsNullOrEmpty(port)) {
                Server += ":3306";
            } else {
                Server += ":" + port;
            }

            if (String.IsNullOrEmpty(userName)) {
                userName = "apparition_user";
            }

            string ConnString = string.Format("Server={0}; database={1}; UID={2}; password={3};", Server, databaseName, userName, password);
            return ConnString;
        }

        private void InitializeDB() {
            string Query = "CREATE TABLE IF NOT EXISTS warps(" +
                "name VARCHAR(32) PRIMARY KEY" +
                "xcoord FLOAT DEFAULT '0.0'," +
                "ycoord FLOAT DEFAULT '0.0'," +
                "zcoord FLOAT DEFAULT '0.0'," +
                "yaw FLOAT DEFAULT 0.0," +
                "pitch FLOAT DEFAULT 0.0," +
                "head FLOAT DEFAULT 0.0" +
                ")";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(Query, connection);
            cmd.ExecuteScalar();
            connection.Close();

        }

        public MySqlConnection GetConnection() {
            if (connection == null) {
                connection = new MySqlConnection(getConnectionString());
            }
            return connection;
        }

    }
}
