using DesktopNotes.Model;
using DesktopNotes.Utils;
using DesktopNotes.Utils.DataBase.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.ViewModel
{

    public class NoteListViewModel : BaseViewModel
    {
        private ObservableCollection<ViewNote> _notes;

        public ObservableCollection<ViewNote> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }


        public NoteListViewModel()
        {
            var dal = new NotesDAL();
            var list = dal.RetrieveNoteList().Select(m => new ViewNote
            {
                ID = m.ID,
                Content = m.Content,
                UpdateTime = m.UpdateTime,
                Theme = new ThemeColor()
            }).ToList();

            Notes = new ObservableCollection<ViewNote>(list);

            MainViewModel.OnAddNewNote += OnAddNewNote;
            MainViewModel.OnUpdateNote += OnUpdateNote;
            MainViewModel.ChageItemTheme += ChangeItemTheme;
        }

        internal void OnAddNewNote(object sender, string e)
        {
            var dal = new NotesDAL();
            var item = dal.RetrieveNoteContent(e);
            var note = new ViewNote()
            {
                ID = item.ID,
                Content = item.Content,
                UpdateTime = item.UpdateTime,
                Theme = new ThemeColor()
            };

            Notes.Add(note);
        }

        internal void OnUpdateNote(object sender, string e)
        {
            var dal = new NotesDAL();
            var item = dal.RetrieveNoteContent(e);

            var note = Notes.First(m => m.ID == item.ID);
            note.Content = item.Content;
            note.UpdateTime = item.UpdateTime;
        }

        internal void ChangeItemTheme(object sender, Tuple<string, ThemeColor> e)
        {
            var temp = Notes.FirstOrDefault(m => m.ID == e.Item1);
            if (!string.IsNullOrWhiteSpace(e.Item1) && temp != null)
            {
                Notes.First(m => m.ID == e.Item1).Theme = e.Item2;
            }
        }
    }
}
