using System.Collections.Generic;
using System.IO;
using CefSharp;

namespace AgileBrowser
{
    public class TempFileDialogHandler : IDialogHandler
    {
        public bool OnFileDialog(IWebBrowser browserControl, IBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
        {
            callback.Continue(selectedAcceptFilter, new List<string> { Path.GetRandomFileName() });
            
            return true;
        }
    }
}
