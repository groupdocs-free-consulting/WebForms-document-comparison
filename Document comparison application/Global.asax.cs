using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Document_comparison_application
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            GroupDocs.Comparison.License comparisonLic = new GroupDocs.Comparison.License();
            comparisonLic.SetLicense(@"D:/GroupDocs.Total.NET.lic");

            GroupDocs.Viewer.License viewerLic = new GroupDocs.Viewer.License();
            viewerLic.SetLicense(@"D:/GroupDocs.Total.NET.lic");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}