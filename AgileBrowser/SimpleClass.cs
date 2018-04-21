using System.Collections.Generic;
using CefSharp;

namespace AgileBrowser
{
    public class SimpleClass
    {
        public IJavascriptCallback Callback { get; set; }
        public string TestString { get; set; }

        public IList<SimpleSubClass> SubClasses { get; set; }
    }
}
