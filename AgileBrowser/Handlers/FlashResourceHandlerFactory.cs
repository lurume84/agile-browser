using CefSharp;

namespace AgileBrowser
{
    public class FlashResourceHandlerFactory : IResourceHandlerFactory
    {
        bool IResourceHandlerFactory.HasHandlers
        {
            get { return true; }
        }

        IResourceHandler IResourceHandlerFactory.GetResourceHandler(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request)
        {
            if (request.Url.Contains("zeldaADPCM5bit.swf"))
            {
                return new FlashResourceHandler();
            }
            return null;
        }
    }
}
