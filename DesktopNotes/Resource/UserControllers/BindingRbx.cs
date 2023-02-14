using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DesktopNotes.Resource.UserControllers
{
    public class BindingRbx : RichTextBox
    {
        public static readonly DependencyProperty BindingContentProperty =
          DependencyProperty.RegisterAttached(nameof(BindingContent), typeof(string), typeof(BindingRbx), new FrameworkPropertyMetadata
          {
              BindsTwoWayByDefault = true,
              PropertyChangedCallback = CallBack
          });

        public string BindingContent
        {
            get => (string)GetValue(BindingContentProperty);
            set => SetValue(BindingContentProperty, value);
        }

        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var richTextBox = d as BindingRbx;

            // Parse the XAML to a document (or use XamlReader.Parse())
            var xaml = richTextBox.BindingContent;

            var content = Utils.DocumnetAnalysis.AnalysisNoteFromDatabase(xaml);

            while (content.Blocks.Count > 5 || IsEmptyLine(content.Blocks.LastBlock))
            {
                content.Blocks.Remove(content.Blocks.LastBlock);
            }

            //App.Current.Dispatcher.Invoke(() =>
            //{

            // Set the document
            richTextBox.Document = content;

            //// When the document changes update the source
            //richTextBox.TextChanged += (sender, arg) =>
            //{
            //    richTextBox.BindingContent = Utils.DocumnetAnalysis.ConvertNoteToBase64(richTextBox.Document);
            //};


            //});
        }

        private static bool IsEmptyLine(Block block)
        {
            TextRange textRange = new TextRange(block.ContentStart, block.ContentEnd);

            return string.IsNullOrWhiteSpace(textRange.Text);
        }
    }
}
