using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_wpf.Models
{
    class SqliteControll
    {
        static string sqliteFile = Environment.CurrentDirectory + "\\" + @"sqlite.db";
        static string connString = @"data source=" + sqliteFile;

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(SqliteControll.connString);
        }
    }
}
