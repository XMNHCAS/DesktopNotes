using DesktopNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DesktopNotes.Resource.UserControllers
{
    public class ThemeButton : Button
    {
        public static readonly DependencyProperty ColorConfigProperty =
           DependencyProperty.RegisterAttached(nameof(ColorConfig), typeof(ThemeColor), typeof(ThemeButton), new PropertyMetadata());

        public ThemeColor ColorConfig
        {
            get => (ThemeColor)GetValue(ColorConfigProperty);
            set => SetValue(ColorConfigProperty, value);
        }
    }
}
