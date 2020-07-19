using System;
using System.IO;
using UnityEngine;
using Object = System.Object;

namespace Elthlead.ResourceManager
{
    public struct StreamingAssetsPath
    {
        public String AbsolutePath { get; }

        private StreamingAssetsPath(String absolutePath)
        {
            AbsolutePath = absolutePath;
        }

        public override String ToString() => AbsolutePath;
        public Boolean Equals(StreamingAssetsPath other) => AbsolutePath == other.AbsolutePath;
        public override Boolean Equals(Object obj) => obj is StreamingAssetsPath other && Equals(other);
        public override Int32 GetHashCode() => (AbsolutePath != null ? AbsolutePath.GetHashCode() : 0);
        public static Boolean operator ==(StreamingAssetsPath left, StreamingAssetsPath right) => left.Equals(right);
        public static Boolean operator !=(StreamingAssetsPath left, StreamingAssetsPath right) => !left.Equals(right);

        public static StreamingAssetsPath Root { get; } = new StreamingAssetsPath(GetStreamingAssetsPath());

        public static StreamingAssetsPath Relative(String relativePath)
        {
            if (!relativePath.StartsWith("/"))
                throw new NotSupportedException(relativePath);

            return new StreamingAssetsPath(GetStreamingAssetsPath() + relativePath);
        }

        private static String GetStreamingAssetsPath()
        {
            String path = Application.streamingAssetsPath;
            if (String.IsNullOrEmpty(path))
                throw new NotSupportedException("Application.streamingAssetsPath is not supported.");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(path);

            return path;
        }
    }
}