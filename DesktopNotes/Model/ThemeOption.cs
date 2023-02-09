using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Model
{
    public class ThemeOption
    {
        public ThemeColor Theme { get; set; }

        public string ToolTip { get; set; }

        public bool IsSelected { get; set; }

        public ThemeOption(ThemeColor theme, string tip, bool selected)
        {
            Theme = theme;
            ToolTip = tip;
            IsSelected = selected;
        }

        public ThemeOption() { }
    }
}
