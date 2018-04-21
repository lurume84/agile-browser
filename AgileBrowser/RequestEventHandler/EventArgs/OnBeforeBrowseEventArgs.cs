using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public class OnBeforeBrowseEventArgs : BaseRequestEventArgs
    {
        public OnBeforeBrowseEventArgs(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
            : base(browserControl, browser)
        {
            Frame = frame;
            Request = request;
            IsRedirect = isRedirect;

            CancelNavigation = false; // default
        }

        public IFrame Frame { get; private set; }
        public IRequest Request { get; private set; }
        public bool IsRedirect { get; private set; }

        /// <summary>
        ///     Set to true to cancel the navigation or false to allow the navigation to proceed.
        /// </summary>
        public bool CancelNavigation { get; set; }
    }
}
