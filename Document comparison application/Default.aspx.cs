using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Comparison;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;

namespace Document_comparison_application
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sourceFile = Server.MapPath("~/SampleFiles/sample1.docx");
            string targetFile = Server.MapPath("~/SampleFiles/sample2.docx");
            string outputFilePath = Server.MapPath("~/OutputFiles/");

            Comparer compare = new Comparer(sourceFile);
            compare.Add(targetFile);
            compare.Compare(outputFilePath + "comparison output.docx", new GroupDocs.Comparison.Options.CompareOptions());

            MemoryStream outputStream = new MemoryStream(); 
            Viewer viewer = new Viewer(outputFilePath + "comparison output.docx");
            HtmlViewOptions Options = HtmlViewOptions.ForEmbeddedResources(
                    (pageNumber) => outputStream,
                    (pageNumber, pageStream) => { });
            viewer.View(Options);
            outputStream.Position = 0;

            string outputContent = Encoding.UTF8.GetString((outputStream as MemoryStream).ToArray());
            Session["value"] = outputContent;
            outputStream.Dispose();
        }
    }
}