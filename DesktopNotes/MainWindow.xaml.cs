using DesktopNotes.Model;
using DesktopNotes.Resource.UserControllers;
using DesktopNotes.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DesktopNotes
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isInitTheme = true;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //将装饰器添加到窗口的Content控件上
            var c = Content as UIElement;
            var layer = AdornerLayer.GetAdornerLayer(c);
            layer.Add(new Utils.WindowResizeAdorner(c));

            var data = DataContext as MainViewModel;
            for (int i = 0; i < data.ThemeOptions.Count; i++)
            {
                theme_grid.ColumnDefinitions.Add(new ColumnDefinition());
                var rbtn = new ThemeRbtn() { GroupName = "theme" };
                rbtn.Checked += ThemeRbtn_Checked;
                rbtn.SetBinding(ThemeRbtn.OptionItemProperty, new Binding() { Path = new PropertyPath($"ThemeOptions[{i}]") });
                rbtn.SetBinding(ThemeRbtn.IsCheckedProperty, new Binding() { Path = new PropertyPath($"ThemeOptions[{i}].IsSelected") });
                Grid.SetColumn(rbtn, i);
                theme_grid.Children.Add(rbtn);
            }
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
            var data = DataContext as MainViewModel;

            (form.DataContext as MainViewModel).ThemeOptions[0].IsSelected = false;
            for (int i = 0; i < data.ThemeOptions.Count; i++)
            {
                if (data.ThemeOptions[i].IsSelected)
                {
                    (form.DataContext as MainViewModel).ThemeOptions[i].IsSelected = true;
                    break;
                }
            }

            form.Show();
        }

        private void btn_Strikethrough_Click(object sender, RoutedEventArgs e)
        {
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

        private void rbx_Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textRange = new TextRange(rbx_Content.Document.ContentStart, rbx_Content.Document.ContentEnd);

            if (string.IsNullOrWhiteSpace(textRange.Text))
            {
                placeholder.Visibility = Visibility.Visible;
            }
            else
            {
                placeholder.Visibility = Visibility.Hidden;
            }
        }

        private void btnToolbarSwitch_Click(object sender, RoutedEventArgs e)
        {
            btnToolbarSwitch.IsEnabled = false;
            bool isShow = false;
            var storyboard = new Storyboard();

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                DecelerationRatio = 0.9f
            };

            var data = DataContext as MainViewModel;

            void callback(object obj, EventArgs arge)
            {
                Dispatcher.Invoke(() =>
                {
                    if (isShow)
                    {
                        data.ToolbarVisibility = Visibility.Hidden;
                    }

                    btnToolbarSwitch.IsEnabled = true;
                });

            }

            if (data.ToolbarVisibility == Visibility.Hidden)
            {
                data.ToolbarVisibility = Visibility.Visible;
                data.ToolbarSwitchIcon = "\ue7f3";

                animation.From = new Thickness(Width, 0, 0, 0);
                animation.To = new Thickness(0);
            }
            else
            {
                data.ToolbarSwitchIcon = "\ue7f4";
                isShow = true;
                animation.From = new Thickness(0, 0, 0, 0);
                animation.To = new Thickness(Width, 0, 0, 0);
            }

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            Storyboard.SetTarget(animation, toolbarContainer);
            storyboard.Completed += callback;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void btn_Config_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).SettingVisibility = Visibility.Visible;
            var storyboard = new Storyboard();

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                DecelerationRatio = 0.9f,
                From = new Thickness(0, -200, 0, 0),
                To = new Thickness(0, 0, 0, 0)
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            Storyboard.SetTarget(animation, settingPanel);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void ThemeRbtn_Checked(object sender, RoutedEventArgs e)
        {
            var controller = sender as Resource.UserControllers.ThemeRbtn;
            (DataContext as MainViewModel).SelectedTheme = controller.OptionItem.Theme;

            if (!isInitTheme)
            {
                CloseSettingPanel();
            }
            else
            {
                (DataContext as MainViewModel).SettingVisibility = Visibility.Hidden;
                isInitTheme = false;
            }
        }

        private void btn_CloseSetting_Click(object sender, RoutedEventArgs e)
        {
            CloseSettingPanel();
        }

        private void CloseSettingPanel()
        {
            var storyboard = new Storyboard();

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                DecelerationRatio = 0.9f,
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(0, -200, 0, 0)
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            Storyboard.SetTarget(animation, settingPanel);
            storyboard.Children.Add(animation);
            storyboard.Completed += callback;
            storyboard.Begin();

            void callback(object obj, EventArgs arg)
            {
                (DataContext as MainViewModel).SettingVisibility = Visibility.Hidden;
            }
        }

        private void btn_SaveNote_Click(object sender, RoutedEventArgs e)
        {
            //using (var stream = new MemoryStream())
            //{
            //    XamlWriter.Save(rbx_Content.Document, stream);
            //    byte[] bytes = new byte[stream.Length];
            //    stream.Position = 0;
            //    stream.Read(bytes, 0, bytes.Length);

            //    var data = DataContext as MainViewModel;
            //    var dal = new Utils.DataBase.DAL.NotesDAL();

            //    //var textRange = new TextRange(rbx_Content.Document.ContentStart, rbx_Content.Document.ContentEnd);
            //    //string note = textRange.Text;

            //    string note = Convert.ToBase64String(bytes);

            //    if (string.IsNullOrWhiteSpace(data.NoteID))
            //    {
            //        data.NoteID = dal.CreateNote(note);
            //    }
            //    else
            //    {
            //        dal.UpdateNote(data.NoteID, note);
            //    }
            //}

            var dal = new Utils.DataBase.DAL.NotesDAL();
            var res = dal.RetrieveNoteContent("eaf51676-4984-48a3-b126-3ea346ce8b91");
            AnalysisNoteFromDatabase(res.Content);
        }

        private void AnalysisNoteFromDatabase(string base64Str)
        {
            byte[] bytes = Convert.FromBase64String(base64Str);
            using (var stream = new MemoryStream(bytes))
            {
                var doc = XamlReader.Load(stream) as FlowDocument;
                rbx_Content.Document = doc;
            }
        }
    }
}
