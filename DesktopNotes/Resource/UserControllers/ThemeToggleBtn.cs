using DesktopNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DesktopNotes.Resource.UserControllers
{
    public class ThemeToggleBtn : ToggleButton
    {
        public static readonly DependencyProperty ThemeConfigProperty =
           DependencyProperty.RegisterAttached(nameof(ThemeConfig), typeof(ThemeColor), typeof(ToggleButton), new PropertyMetadata());

        public ThemeColor ThemeConfig
        {
            get => (ThemeColor)GetValue(ThemeConfigProperty);
            set => SetValue(ThemeConfigProperty, value);
        }
    }
}
