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
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowSizeChange(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                btn.Content = "\ue62a";
            }
            else
            {
                WindowState = WindowState.Maximized;
                btn.Content = "\ue673";
            }
        }

        private void MinSizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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
    }
}
