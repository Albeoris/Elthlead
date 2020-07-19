using System;
using System.IO;

namespace Elthlead.Framework
{
    public sealed class NotDisposableStream : ProxyStream
    {
        public NotDisposableStream(Stream stream)
            : base(stream)
        {
        }

        protected override void Dispose(Boolean disposing)
        {
        }
    }
}