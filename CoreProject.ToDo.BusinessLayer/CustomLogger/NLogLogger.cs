using CoreProject.ToDo.BusinessLayer.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
