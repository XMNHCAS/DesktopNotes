using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Utils.DataBase
{
    public class Instance
    {
        public static SqlSugarClient CreateDBInstance()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "notes.db";

            var DB = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = $@"DataSource={path};Version=3",
                DbType = DbType.Sqlite,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });

            if (!File.Exists(path))
            {
                DB.DbMaintenance.CreateDatabase();
                DB.CodeFirst.InitTables(typeof(Models.Notes));
            }

            return DB;
        }
    }
}
