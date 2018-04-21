using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public class OnProtocolExecutionEventArgs : BaseRequestEventArgs
    {
        public OnProtocolExecutionEventArgs(IWebBrowser browserControl, IBrowser browser, string url) : base(browserControl, browser)
        {
            Url = url;

            AttemptExecution = false; // default
        }

        public string Url { get; private set; }

        /// <summary>
        ///     Set to true to attempt execution via the registered OS protocol handler, if any. Otherwise set to false.
        /// </summary>
        public bool AttemptExecution { get; set; }
    }
}
