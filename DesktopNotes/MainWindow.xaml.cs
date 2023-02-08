using DesktopNotes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace DesktopNotes
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //将装饰器添加到窗口的Content控件上
            var c = Content as UIElement;
            var layer = AdornerLayer.GetAdornerLayer(c);
            layer.Add(new Utils.WindowResizeAdorner(c));

            DataContext = new MainViewModel();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_NewForm_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
        }

        private void btn_Strikethrough_Click(object sender, RoutedEventArgs e)
        {
            Background = (System.Windows.Media.Brush)(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)));

            var temp = rbx_Content.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection;

            if (temp == null)
            {
                return;
            }

            var textDecorations = temp.CloneCurrentValue();
            var data = DataContext as MainViewModel;

            if (data.IsStrikethrough)
            {
                textDecorations.Add(TextDecorations.Strikethrough[0]);
            }
            else
            {
                if (textDecorations.Count > 1)
                {
                    textDecorations = TextDecorations.Underline;
                }
                else
                {
                    textDecorations = null;
                }
            }

            rbx_Content.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
        }

        private void rbx_Content_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var data = DataContext as MainViewModel;

            var fontWeight = rbx_Content.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            data.IsBold = (fontWeight != DependencyProperty.UnsetValue) && fontWeight.Equals(FontWeights.Bold);

            var fontStyle = rbx_Content.Selection.GetPropertyValue(TextElement.FontStyleProperty);
            data.IsItalic = (fontStyle != DependencyProperty.UnsetValue) && fontStyle.Equals(FontStyles.Italic);

            var textDecorations = rbx_Content.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            var arr = textDecorations as TextDecorationCollection;
            data.IsUnderLine = arr.Any(m => m.Location == TextDecorationLocation.Underline);
            data.IsStrikethrough = arr.Any(m => m.Location == TextDecorationLocation.Strikethrough);
        }
    }
}
