using NLog;
using System;

namespace Logic.Logging
{
    public class NLogService : ILogService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Writes to log file debug info.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Short info about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void DebugWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info("---");
            logger.Info(time);
            logger.Debug(recordInfo);
            logger.Debug(record);
            logger.Info("---");
        }

        /// <summary>
        /// Writes to log file error info.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Short info about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void ErrorWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info("---");
            logger.Info(time);
            logger.Error(recordInfo);
            logger.Error(record);
            logger.Info("---");
        }

        /// <summary>
        /// Writes to log file fatal error info.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Short info about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void FatalWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info("---");
            logger.Info(time);
            logger.Fatal(recordInfo);
            logger.Fatal(record);
            logger.Info("---");
        }

        /// <summary>
        /// Writes to log file some info.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Short info about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void InfoWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info("---");
            logger.Info(time);
            logger.Info(recordInfo);
            logger.Info(record);
            logger.Info("---");
        }

        /// <summary>
        /// Writes to log file warn info.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Short info about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void WarnWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info("---");
            logger.Info(time);
            logger.Warn(recordInfo);
            logger.Warn(record);
            logger.Info("---");
        }
    }
}
