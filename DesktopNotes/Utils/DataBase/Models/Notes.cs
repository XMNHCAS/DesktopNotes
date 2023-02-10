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
        [SugarColumn(ColumnDataType = "varchar(255)", IsPrimaryKey = true, ColumnDescription = "主键")]
        public string ID { get; set; }

        [SugarColumn(ColumnDataType = "varchar(255)", IsNullable = true, ColumnDescription = "笔记内容")]
        public string Content { get; set; }

        [SugarColumn(ColumnDataType = "datetime", IsNullable = true, ColumnDescription = "创建时间")]
        public string CreateTime { get; set; }

        [SugarColumn(ColumnDataType = "datetime", IsNullable = true, ColumnDescription = "修改时间")]
        public string UpdateTime { get; set; }

        [SugarColumn(ColumnDataType = "datetime", IsNullable = true, ColumnDescription = "删除时间")]
        public string DeleteTime { get; set; }
    }
}
