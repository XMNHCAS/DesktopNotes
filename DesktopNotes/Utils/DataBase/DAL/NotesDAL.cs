using DesktopNotes.Utils.DataBase.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Utils.DataBase.DAL
{
    public class NotesDAL
    {
        private SqlSugarClient DB;

        public NotesDAL()
        {
            DB = Instance.CreateDBInstance();
        }

        public List<Notes> RetrieveNoteList()
        {
            return DB.Queryable<Notes>().ToList();
        }

        public Notes RetrieveNoteContent(string id)
        {
            return DB.Queryable<Notes>().First(m => m.ID == id);
        }

        public string CreateNote(string note)
        {
            var res = DB.Insertable(new Notes()
            {
                ID = Guid.NewGuid().ToString(),
                Content = note,
                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            }).IgnoreColumns(m => new { m.DeleteTime }).ExecuteReturnEntity();

            return res.ID;
        }

        public void UpdateNote(string id, string note)
        {
            DB.Updateable(new Notes()
            {
                ID = id,
                Content = note,
                UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                DeleteTime = null
            }).IgnoreColumns(m => new { m.CreateTime, m.DeleteTime }).WhereColumns(m => new { m.ID }).ExecuteCommand();
        }

        public void DeleteNote(string id)
        {
            DB.Updateable(new Notes()
            {
                ID = id,
                DeleteTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            }).IgnoreColumns(m => new { m.Content, m.CreateTime, m.UpdateTime }).WhereColumns(m => new { m.ID }).ExecuteCommand();
        }
    }
}
