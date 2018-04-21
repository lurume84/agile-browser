using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public class GetResourceResponseFilterEventArgs : BaseRequestEventArgs
    {
        public GetResourceResponseFilterEventArgs(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) : base(browserControl, browser)
        {
            Frame = frame;
            Request = request;
            Response = response;

            ResponseFilter = null; // default
        }

        public IFrame Frame { get; private set; }
        public IRequest Request { get; private set; }
        public IResponse Response { get; private set; }

        /// <summary>
        ///     Set a ResponseFilter to intercept this response, leave it null otherwise.
        /// </summary>
        public IResponseFilter ResponseFilter { get; set; }
    }
}
