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
    public class ThemeRbtn : RadioButton
    {
        public static readonly DependencyProperty OptionItemProperty =
           DependencyProperty.RegisterAttached(nameof(OptionItem), typeof(ThemeOption), typeof(ThemeRbtn), new PropertyMetadata());

        public ThemeOption OptionItem
        {
            get => (ThemeOption)GetValue(OptionItemProperty);
            set => SetValue(OptionItemProperty, value);
        }
    }
}
