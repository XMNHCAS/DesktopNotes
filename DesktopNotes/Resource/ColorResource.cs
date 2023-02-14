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
            Yellow = new ThemeColor("#FFF7D1", "#FFE66E", "#EED767", "#FFF2AB", "#DCD194", "#000000", "#EEE7C3", "#DCD5B4");
            Green = new ThemeColor("#E4F9E0", "#CBF1C4", "#96DF91", "#A1EF9B", "#8BCE86", "#000000", "#D5E8D1", "#C5D7C1");
            Pink = new ThemeColor("#FFE4F1", "#FFAFDF", "#EEA3D0", "#FFCCE5", "#DC97C0", "#000000", "#EED5E1", "#DCC5D0");
            Purple = new ThemeColor("#F2E6FF", "#D7AFFF", "#C9A3EE", "#E7CFFF", "#B997DC", "#000000", "#E2D7EE", "#D1C6DC");
            Blue = new ThemeColor("#E2F1FF", "#9EDFFF", "#93D0EE", "#CDE9FF", "#88C0DC", "#000000", "#D3E1EE", "#C3D0DC");
            Grey = new ThemeColor("#F3F2F1", "#E0E0E0", "#D1D1D1", "#E1DFDD", "#C1C1C1", "#000000", "#E3E2E1", "#D2D1D0");
            Charcoal = new ThemeColor("#696969", "#767676", "#7F7F7F", "#494745", "#898989", "#FFFFFF", "#737373", "#7E7E7E");
        }
    }
}
