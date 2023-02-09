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
        public static readonly DependencyProperty ColorConfigProperty =
           DependencyProperty.RegisterAttached(nameof(ColorConfig), typeof(ThemeColor), typeof(ToggleButton), new PropertyMetadata());

        public ThemeColor ColorConfig
        {
            get => (ThemeColor)GetValue(ColorConfigProperty);
            set => SetValue(ColorConfigProperty, value);
        }
    }
}
