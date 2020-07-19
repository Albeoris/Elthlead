using System;
using Elthlead.Framework;
using UnityEngine;
using Object = System.Object;

namespace Elthlead.ResourceManager
{
    public sealed class LogRedirector : ILogHandler
    {
        private static Log _log;
        private static ILogHandler _native;

        public static void Redirect()
        {
            try
            {
                ILogHandler logger = Debug.unityLogger.logHandler;
                if (logger is LogRedirector)
                    return;

                _log = Log.CreateLog("Elthlead.Unity.log");
                _native = logger;

                Debug.unityLogger.logHandler = new LogRedirector();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot redirect Unity log.");
                Environment.Exit(1);
            }
        }

        private Char GetPrefix(LogType logType)
        {
            switch (logType)
            {
                case LogType.Assert: return 'A';
                case LogType.Log: return 'M';
                case LogType.Warning: return 'W';
                case LogType.Error:
                case LogType.Exception: return 'E';
                default: return 'U';
            }
        }

        public void LogFormat(LogType logType, UnityEngine.Object context, String format, params Object[] args)
        {
            _log.Write(GetPrefix(logType), 0, format, args);
            _native.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            _log.Write(GetPrefix(LogType.Exception), 0, Framework.Log.FormatException(exception));
            _native.LogException(exception, context);
        }
    }
}