using System;
using System.IO;
using CefSharp;

namespace AgileBrowser.Filters
{
    public class PassThruResponseFilter : IResponseFilter
    {
        bool IResponseFilter.InitFilter()
        {
            return true;
        }

        FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if(dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                return FilterStatus.Done;
            }

            dataInRead = dataIn.Length;
            dataOutWritten = Math.Min(dataInRead, dataOut.Length);

            dataIn.CopyTo(dataOut);

            return FilterStatus.Done;
        }

        public void Dispose()
        {
            
        }
    }
}
