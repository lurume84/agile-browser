using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public class CanSetCookieEventArg : BaseRequestEventArgs
    {
        public CanSetCookieEventArg(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
            : base(browserControl, browser)
        {
            Frame = frame;
            Request = request;
            Cookie = cookie;
        }

        public IFrame Frame { get; private set; }
        public IRequest Request { get; private set; }
        public bool IsRedirect { get; private set; }
        public Cookie Cookie { get; private set; }

        /// <summary>
        /// Return true to allow the cookie to be stored or false to block the cookie.
        /// </summary>
        public bool SetCookie { get; set; } = true;
    }
}
