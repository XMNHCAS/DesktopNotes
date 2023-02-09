using DesktopNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopNotes.Resource
{
    public class ColorResource
    {
        /// <summary>
        /// 黄色
        /// </summary>
        public ThemeColor Yellow { get; private set; }

        /// <summary>
        /// 绿色
        /// </summary>
        public ThemeColor Green { get; private set; }

        /// <summary>
        /// 粉色
        /// </summary>
        public ThemeColor Pink { get; private set; }

        /// <summary>
        /// 紫色
        /// </summary>
        public ThemeColor Purple { get; private set; }

        /// <summary>
        /// 蓝色
        /// </summary>
        public ThemeColor Blue { get; private set; }

        /// <summary>
        /// 灰色
        /// </summary>
        public ThemeColor Grey { get; private set; }

        /// <summary>
        /// 炭笔
        /// </summary>
        public ThemeColor Charcoal { get; private set; }

        public ColorResource()
        {
            Yellow = new ThemeColor() { Theme = "#FFF7D1", Option = "#FFE66E", Hover = "#EED767", Title = "#FFF2AB", Click = "#DCD194", Foreground = "#000000", ButtonHover = "#EEE7C3", ButtonClick = "#DCD5B4" };
            Green = new ThemeColor() { Theme = "#E4F9E0", Option = "#CBF1C4", Hover = "#96DF91", Title = "#A1EF9B", Click = "#8BCE86", Foreground = "#000000", ButtonHover = "#D5E8D1", ButtonClick = "#C5D7C1" };
            Pink = new ThemeColor() { Theme = "#FFE4F1", Option = "#FFAFDF", Hover = "#EEA3D0", Title = "#FFCCE5", Click = "#DC97C0", Foreground = "#000000", ButtonHover = "#EED5E1", ButtonClick = "#DCC5D0" };
            Purple = new ThemeColor() { Theme = "#F2E6FF", Option = "#D7AFFF", Hover = "#C9A3EE", Title = "#E7CFFF", Click = "#B997DC", Foreground = "#000000", ButtonHover = "#E2D7EE", ButtonClick = "#D1C6DC" };
            Blue = new ThemeColor() { Theme = "#E2F1FF", Option = "#9EDFFF", Hover = "#93D0EE", Title = "#CDE9FF", Click = "#88C0DC", Foreground = "#000000", ButtonHover = "#D3E1EE", ButtonClick = "#C3D0DC" };
            Grey = new ThemeColor() { Theme = "#F3F2F1", Option = "#E0E0E0", Hover = "#D1D1D1", Title = "#E1DFDD", Click = "#C1C1C1", Foreground = "#000000", ButtonHover = "#E3E2E1", ButtonClick = "#D2D1D0" };
            Charcoal = new ThemeColor() { Theme = "#696969", Option = "#767676", Hover = "#7F7F7F", Title = "#494745", Click = "#898989", Foreground = "#FFFFFF", ButtonHover = "#737373", ButtonClick = "#7E7E7E" };
        }
    }
}
