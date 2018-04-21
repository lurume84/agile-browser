using System;
using System.Diagnostics;
using CefSharp.ModelBinding;

namespace AgileBrowser.ModelBinding 
{
    public class MethodInterceptorLogger : IMethodInterceptor
    {
        object IMethodInterceptor.Intercept(Func<object> method, string methodName)
        {
            object result = method();
            Debug.WriteLine("Called " + methodName);
            return result;
        }
    }
}
