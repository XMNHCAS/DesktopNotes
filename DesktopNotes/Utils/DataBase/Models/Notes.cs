using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Utils.DataBase.Models
{
    public class Notes
    {
        [SugarColumn(ColumnDataType = "varchar(255)", IsPrimaryKey = true)]
        public string ID { get; set; }

        [SugarColumn(ColumnDataType = "varchar(255)", IsNullable = true)]
        public string Content { get; set; }

        [SugarColumn(ColumnDataType = "varchar(255)", IsNullable = true)]
        public string CreateTime { get; set; }

        [SugarColumn(ColumnDataType = "varchar(255)", IsNullable = true)]
        public string UpdateTime { get; set; }

        [SugarColumn(ColumnDataType = "varchar(255)", IsNullable = true)]
        public string DeleteTime { get; set; }
    }
}
