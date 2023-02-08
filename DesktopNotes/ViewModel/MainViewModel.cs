using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderLine;
        private bool _isStrikethrough;

        public bool IsBold
        {
            get => _isBold;
            set
            {
                _isBold = value;
                OnPropertyChanged(nameof(IsBold));
            }
        }

        public bool IsItalic
        {
            get => _isItalic;
            set
            {
                _isItalic = value;
                OnPropertyChanged(nameof(IsItalic));
            }
        }

        public bool IsUnderLine
        {
            get => _isUnderLine;
            set
            {
                _isUnderLine = value;
                OnPropertyChanged(nameof(IsUnderLine));
            }
        }

        public bool IsStrikethrough
        {
            get => _isStrikethrough;
            set
            {
                _isStrikethrough = value;
                OnPropertyChanged(nameof(IsStrikethrough));
            }
        }
    }
}
