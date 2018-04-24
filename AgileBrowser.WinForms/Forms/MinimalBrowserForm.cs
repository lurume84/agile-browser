using System;
using System.Windows.Forms;
using AgileBrowser;
using AgileBrowser.Handlers;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;

namespace AgileBrowser.WinForms.Forms
{
    public partial class MinimalBrowserForm : Form
    {
        private ChromiumWebBrowser browser;

        private string externalDomain;

        public MinimalBrowserForm(string externalDomain)
        {
            InitializeComponent();

            Text = "CefSharp";
            WindowState = FormWindowState.Maximized;

            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            DisplayOutput(version);

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

            Load += OnLoad;

            this.externalDomain = externalDomain;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            CreateBrowser();
        }

        private void CreateBrowser()
        {
            browser = new ChromiumWebBrowser("www.google.com")
            {
                Dock = DockStyle.Fill,
            };
            toolStripContainer.ContentPanel.Controls.Add(browser);

            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.JavascriptObjectRepository.Register("bound", new BoundObject());
            browser.RequestHandler = new RequestHandler(externalDomain);
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            
        }

        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            
        }

        private void SetCanGoBack(bool canGoBack)
        {
            
        }

        private void SetCanGoForward(bool canGoForward)
        {
            
        }

        private void SetIsLoading(bool isLoading)
        {
            HandleToolStripLayout();
        }

        public void DisplayOutput(string output)
        {
            
        }

        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        private void HandleToolStripLayout()
        {
            
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
            Close();
        }

        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }
    }
}
