using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace BibliotecaLivros.DAL.Data
{
    public static class DbHelper
    {
        public delegate void FillList(SQLiteDataReader rdrSelect);
        #region Sql Criação Tabelas
        readonly static string sqlCreateTableBooks = @"CREATE TABLE books
        (
		        Id  VARCHAR(20) NOT NULL PRIMARY KEY, 
		        Title  VARCHAR(50) NULL, 
                Subtitle  VARCHAR(50) NULL,
		        Description  VARCHAR(500) NULL, 
		        ImageLinks  VARCHAR(0) NULL
        )";
        #endregion

        readonly static string sqlCheckTableBookExists = @"SELECT name FROM sqlite_master 
            WHERE type='table' 
            AND name='books'";
        readonly static string dbFilePath = GetAppDataFolder();

        public static bool CreateDataBase()
        {
            bool success = false;
            try
            {
                //string dbfilePath = GetAppDataFolder();
                if (!File.Exists(dbFilePath))
                {
                    SQLiteConnection.CreateFile(dbFilePath);
                    success = CreateTable();
                } else
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return success;
        }

        private static bool CreateTable()
        {
            bool success = false;
            SQLiteConnection dbConnection = null;
            SQLiteDataReader rdrSelect = null;
            try
            {
                dbConnection = OpenConection();

                SQLiteCommand command = new SQLiteCommand(sqlCheckTableBookExists, dbConnection);
                rdrSelect = command.ExecuteReader();
                if (!rdrSelect.HasRows)
                {
                    rdrSelect.Close();
                    command.CommandText = sqlCreateTableBooks;
                    command.ExecuteNonQuery();
                }
                success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                CloseDataReader(rdrSelect);
                CloseConection(dbConnection);
            }
            return success;
        }

        public static bool ExecuteNonQueryCommand(string sql, SQLiteParameter[] parameters = null)
        {
            bool success = false;
            SQLiteConnection dbConnection = null;
            try
            {
                dbConnection = OpenConection();
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                success = command.ExecuteNonQuery() > 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                CloseConection(dbConnection);
            }
            return success;
        }

        public static void ExecuteSelectCommand(string sql, SQLiteParameter[] parameters, FillList fillList)
        {
            SQLiteDataReader rdrSelect = null;
            SQLiteConnection dbConnection = null;
            try
            {
                dbConnection = OpenConection();
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                rdrSelect = command.ExecuteReader();
                fillList(rdrSelect);
                rdrSelect.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                CloseDataReader(rdrSelect);
                CloseConection(dbConnection);
            }
        }

        private static void CloseDataReader(SQLiteDataReader rdrSelect)
        {
            if (rdrSelect != null)
            {
                rdrSelect.Close();
            }
        }

        private static SQLiteConnection OpenConection()
        {
            SQLiteConnection dbConnection = null;
            try
            {
                dbConnection = new SQLiteConnection(string.Concat("Data Source=", dbFilePath, ";Version=3;"));
                dbConnection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return dbConnection;
        }

        private static void CloseConection(SQLiteConnection dbConnection)
        {
            if (dbConnection != null && dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnection.Close();
            }
        }

        public static string GetAppDataFolder()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                                .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;

            var pathDB = Path.Combine(appRoot, "data");
            if (!Directory.Exists(pathDB)) 
            {
                Directory.CreateDirectory(pathDB);
            }
            return Path.Combine(appRoot, "data", "BooksLibrary.sqlite");
        }
    }
}
