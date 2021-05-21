using sample_wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_wpf.ViewModels
{
    class UsersViewModel
    {
        public ObservableCollection<UserVO> AllUsers { get; set; }

        public UsersViewModel() {
            AllUsers = new ObservableCollection<UserVO>();

            using (SQLiteConnection conn = SqliteControll.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM USERS";
                SQLiteCommand command = new SQLiteCommand(sql, conn);

                SQLiteDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    AllUsers.Add(new UserVO(rdr["name"].ToString(), Int32.Parse(rdr["age"].ToString()), rdr["residentNum"].ToString(), rdr["veteranNum"].ToString()));
                }

                rdr.Close();
                command.Dispose();
            }
        }
    }
}
