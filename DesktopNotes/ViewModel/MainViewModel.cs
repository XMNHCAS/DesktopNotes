using DesktopNotes.Model;
using DesktopNotes.Resource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopNotes.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderLine;
        private bool _isStrikethrough;
        private string _toolbarSwitchIcon;
        private string _toolbarSwitchToopTip;
        private Visibility _toolbarVisibility;
        private ObservableCollection<ThemeOption> _themeOptions;
        private ThemeColor _selectedTheme;
        private Visibility _settingVisibility;
        private bool _isAlwaysTopMost;
        private bool _useLocalStorage;
        private Visibility _canSaveNote;
        private string _noteID;

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

        public string ToolbarSwitchIcon
        {
            get => _toolbarSwitchIcon;
            set
            {
                _toolbarSwitchIcon = value;
                OnPropertyChanged(nameof(ToolbarSwitchIcon));
            }
        }

        public string ToolbarSwitchToopTip
        {
            get => _toolbarSwitchToopTip;
            set
            {
                _toolbarSwitchToopTip = value;
                OnPropertyChanged(nameof(ToolbarSwitchToopTip));
            }
        }

        public Visibility ToolbarVisibility
        {
            get => _toolbarVisibility;
            set
            {
                _toolbarVisibility = value;
                ToolbarSwitchToopTip = value == Visibility.Visible ? "折叠工具栏" : "显示工具栏";
                OnPropertyChanged(nameof(ToolbarVisibility));
            }
        }

        public ObservableCollection<ThemeOption> ThemeOptions
        {
            get => _themeOptions;
            set
            {
                _themeOptions = value;
                OnPropertyChanged(nameof(ThemeOptions));
            }
        }

        public ThemeColor SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged(nameof(SelectedTheme));
            }
        }

        public Visibility SettingVisibility
        {
            get => _settingVisibility;
            set
            {
                _settingVisibility = value;
                OnPropertyChanged(nameof(SettingVisibility));
            }
        }

        public bool IsAlwaysTopMost
        {
            get => _isAlwaysTopMost;
            set
            {
                _isAlwaysTopMost = value;
                OnPropertyChanged(nameof(IsAlwaysTopMost));
            }
        }

        public bool UseLocalStorage
        {
            get => _useLocalStorage;
            set
            {
                _useLocalStorage = value;
                CanSaveNote = value ? Visibility.Visible : Visibility.Hidden;
                OnPropertyChanged(nameof(UseLocalStorage));
            }
        }

        public Visibility CanSaveNote
        {
            get => _canSaveNote;
            set
            {
                _canSaveNote = value;
                OnPropertyChanged(nameof(CanSaveNote));
            }
        }

        public string NoteID
        {
            get => _noteID;
            set
            {
                _noteID = value;
                OnPropertyChanged(nameof(NoteID));
            }
        }

        public MainViewModel()
        {
            ToolbarSwitchIcon = "\ue7f4";
            ToolbarVisibility = Visibility.Hidden;

            var colorRes = new ColorResource();
            List<ThemeOption> optionList = new List<ThemeOption>()
            {

                new ThemeOption(colorRes.Yellow,"黄色",true),
                new ThemeOption(colorRes.Green,"绿色",false),
                new ThemeOption(colorRes.Pink,"粉色",false),
                new ThemeOption(colorRes.Purple,"紫色",false),
                new ThemeOption(colorRes.Blue,"蓝色",false),
                new ThemeOption(colorRes.Grey,"灰色",false),
                new ThemeOption(colorRes.Charcoal,"炭笔",false),
            };
            ThemeOptions = new ObservableCollection<ThemeOption>(optionList);

            IsAlwaysTopMost = true;
            CanSaveNote = Visibility.Hidden;
        }
    }
}
