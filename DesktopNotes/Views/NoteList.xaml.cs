using DesktopNotes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopNotes.Views
{
    /// <summary>
    /// NoteList.xaml 的交互逻辑
    /// </summary>
    public partial class NoteList : Window
    {
        public NoteList()
        {
            InitializeComponent();

            DataContext = new NoteListViewModel();
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

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("111");
        }

        private void menu_RemoveNote_Click(object sender, RoutedEventArgs e)
        {
            var test = sender as MenuItem;
            MessageBox.Show(test.Tag.ToString());
        }
    }
}
