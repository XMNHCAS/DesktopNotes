using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;

namespace DesktopNotes.Utils
{
    public class DocumnetAnalysis
    {
        public static FlowDocument AnalysisNoteFromDatabase(string base64Str)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64Str);
                using (var stream = new MemoryStream(bytes))
                {
                    return XamlReader.Load(stream) as FlowDocument;
                }
            }
            catch (Exception)
            {
                using (var stream = new MemoryStream(Encoding.Default.GetBytes("")))
                {
                    var paragraph = new Paragraph();
                    paragraph.Inlines.Add(new Run(""));
                    var res = new FlowDocument();
                    res.Blocks.Add(paragraph);
                    return res;
                }
            }
        }

        public static string ConvertNoteToBase64(FlowDocument doc)
        {
            using (var stream = new MemoryStream())
            {
                XamlWriter.Save(doc, stream);
                byte[] bytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(bytes, 0, bytes.Length);

                return Convert.ToBase64String(bytes);
            }
        }
    }
}
