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
        /// <summary>
        /// 构造函数
        /// </summary>
        private NoteList()
        {
            InitializeComponent();

            DataContext = new NoteListViewModel();
        }

        /// <summary>
        /// 单例对象
        /// </summary>
        public static NoteList Instance => Nested.instance;

        /// <summary>
        /// 防止调用此类静态方法时，创建新的实例
        /// </summary>
        private class Nested
        {
            internal static readonly NoteList instance = null;
            static Nested()
            {
                instance = new NoteList();
            }
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

        private void btn_MinSize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            //var data = DataContext as NoteListViewModel;
            //MainViewModel.OnAddNewNote -= data.OnAddNewNote;
            //MainViewModel.ChageItemTheme -= data.ChangeItemTheme;
        }

        private void menu_RemoveNote_Click(object sender, RoutedEventArgs e)
        {
            var test = sender as MenuItem;
            var id = test.Tag.ToString();

            var dataContext = DataContext as NoteListViewModel;
            dataContext.Notes.Remove(dataContext.Notes.First(m => m.ID == id));

            var dal = new Utils.DataBase.DAL.NotesDAL();
            dal.DeleteNote(id);

            var wins = Application.Current.Windows;

            foreach (var item in wins)
            {
                if (item.GetType() == typeof(MainWindow))
                {
                    var data = ((MainWindow)item).DataContext as MainViewModel;

                    if (data.NoteID == id)
                    {
                        ((MainWindow)item).Close();
                        break;
                    }
                }
            }
        }

        private void lvItemBtn_Click(object sender, RoutedEventArgs e)
        {
            bool haveShowedForm = false;
            var btnSource = (e.Source as Button).DataContext as ViewNote;

            if (btnSource == null)
            {
                return;
            }

            var wins = Application.Current.Windows;

            foreach (var item in wins)
            {
                if (item.GetType() == typeof(MainWindow))
                {
                    var data = ((MainWindow)item).DataContext as MainViewModel;

                    if (data.NoteID == btnSource.ID)
                    {
                        ((MainWindow)item).Show();
                        ((MainWindow)item).WindowState = WindowState.Normal;

                        break;
                    }
                }
            }

            if (!haveShowedForm)
            {
                MainWindow form = new MainWindow(btnSource);
                form.Show();
            }
        }

        private void btn_NewForm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }
    }
}
