using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Model
{
    public class ThemeColor
    {
        public string Theme { get; set; }

        public string Title { get; set; }

        public string Option { get; set; }

        public string Hover { get; set; }

        public string Click { get; set; }

        public string Foreground { get; set; }

        public string ButtonHover { get; set; }

        public string ButtonClick { get; set; }

        public ThemeColor()
        {
            Theme = "#FFF7D1";
            Option = "#FFE66E";
            Hover = "#EED767";
            Title = "#FFF2AB";
            Click = "#DCD194";
            Foreground = "#000000";
            ButtonHover = "#EEE7C3";
            ButtonClick = "#DCD5B4";
        }

        public ThemeColor(params string[] parameters)
        {
            Theme = parameters[0];
            Option = parameters[1];
            Hover = parameters[2];
            Title = parameters[3];
            Click = parameters[4];
            Foreground = parameters[5];
            ButtonHover = parameters[6];
            ButtonClick = parameters[7];
        }
    }
}
