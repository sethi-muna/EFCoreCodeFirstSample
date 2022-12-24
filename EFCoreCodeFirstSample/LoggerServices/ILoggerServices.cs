using System;

namespace EFCoreCodeFirstSample.LoggerServices
{
    public interface ILoggerServices
    {
        public void LogInfo(string strMessage);
        public void LogWarning(string strMessage);
        public void LogError(string strMessage);
        public void LogDebug(string strMessage);
    }
}
