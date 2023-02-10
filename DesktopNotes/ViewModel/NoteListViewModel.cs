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
                UpdateTime = m.UpdateTime
            });

            Notes = new ObservableCollection<ViewNote>(list);
        }
    }
}
