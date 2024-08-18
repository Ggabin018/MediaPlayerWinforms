using System.Data.SQLite;
using System.Diagnostics;

namespace MediaPlayerWinforms
{
    class LocalDatabase
    {
        private readonly string connectionString;
        public LocalDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbDirectory = Path.Combine(appDataPath, "MediaPlayerWinforms");
            string dbFilePath = Path.Combine(dbDirectory, "localdb.db");

            if (!Directory.Exists(dbDirectory))
                Directory.CreateDirectory(dbDirectory);

            connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new(connectionString))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS History (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name BLOB NOT NULL,
                                            Path BLOB NOT NULL,
                                            LastModified DATETIME DEFAULT CURRENT_TIMESTAMP,
                                            UNIQUE(Name, Path)
                                          );";

                using (SQLiteCommand command = new(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }  
            }
        }

        public void AddToHistoric(string name, string path)
        {
            using SQLiteConnection connection = new(connectionString);
            {
                connection.Open();

                // Compress name and path
                byte[] compressedName = Utility.Compress(name);
                byte[] compressedPath = Utility.Compress(path);

                // Check if the entry already exists
                string checkQuery = "SELECT COUNT(*) FROM History WHERE Name = @name AND Path = @path;";

                using (SQLiteCommand checkCommand = new(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@name", compressedName);
                    checkCommand.Parameters.AddWithValue("@path", compressedPath);
                    long count = (long)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertDataQuery = $"INSERT INTO History (Name, Path, LastModified) VALUES (@name, @path, CURRENT_TIMESTAMP);";

                        using (SQLiteCommand insertCommand = new(insertDataQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@name", compressedName);
                            insertCommand.Parameters.AddWithValue("@path", compressedPath);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateDataQuery = $"UPDATE History SET LastModified = CURRENT_TIMESTAMP WHERE Name = @name AND Path = @path;";

                        using (SQLiteCommand updateCommand = new(updateDataQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@name", compressedName);
                            updateCommand.Parameters.AddWithValue("@path", compressedPath);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            DebugHistoric();
        }

        public List<(string Name, string Path, DateTime LastModified)> GetLast10HistoricEntries()
        {
            using SQLiteConnection connection = new(connectionString);
            {
                connection.Open();

                string selectQuery = "SELECT Name, Path, LastModified FROM History ORDER BY LastModified DESC LIMIT 10;";

                using (SQLiteCommand command = new(selectQuery, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<(string Name, string Path, DateTime LastModified)> historyEntries = [];

                    while (reader.Read())
                    {
                        string name = Utility.Decompress((byte[])reader["Name"]);
                        string path = Utility.Decompress((byte[])reader["Path"]);

                        DateTime lastModified = reader.GetDateTime(2);

                        historyEntries.Add((name, path, lastModified));
                    }

                    return historyEntries;
                }
            }
        }

        private void DebugHistoric()
        {
            using SQLiteConnection connection = new(connectionString);
            {
                connection.Open();
                string selectQuery = "SELECT * FROM History;";
                using (SQLiteCommand command = new(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = Utility.Decompress((byte[])reader["Name"]);
                            string path = Utility.Decompress((byte[])reader["Path"]);
                            Debug.WriteLine($"Name: {name}, Path: {path}");
                        }
                    }
                }
            }
        }

    }
}
