using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace QFrameWork
{
    public class QLog:QSingleton<QLog>
    {
        public enum LogLevel
        {
            LOG = 0,
            WARNING = 1,
            ASSERT = 2,
            ERROR = 3,
            MAX = 4,
        }

        /// <summary>
        /// 日志数据类
        /// </summary>
        public class LogData
        {
            public string Log { get; set; }
            public string Track { get; set; }
            public LogLevel Level { get; set; }
        }

        /// <summary>
        /// 文本输出日志等级，只要大于等于这个级别的日志，都会输出到文本
        /// </summary>
        public LogLevel fileOutputLogLevel = LogLevel.LOG;

        /// <summary>
        /// unity日志和日志输出等级的映射
        /// </summary>
        private Dictionary<LogType, LogLevel> logTypeLevelDict = null;

        /// <summary>
        /// 日志输出列表
        /// </summary>
        private List<ILogOutput> logOutputList = null;

        private int mainThreadID = -1;

        private QLog()
        {
            this.logTypeLevelDict = new Dictionary<LogType, LogLevel>
            {
                { LogType.Log, LogLevel.LOG },
                { LogType.Warning, LogLevel.WARNING },
                { LogType.Assert, LogLevel.ASSERT },
                { LogType.Error, LogLevel.ERROR },
                { LogType.Exception, LogLevel.ERROR },
            };

            this.fileOutputLogLevel = LogLevel.LOG;
            this.mainThreadID = Thread.CurrentThread.ManagedThreadId;
            this.logOutputList = new List<ILogOutput>
            {
                new QFileLogOutput(),
            };

            Application.logMessageReceived += LogCallback;
            Application.logMessageReceivedThreaded += LogMultiThreadCallback;
        }

        private void LogMultiThreadCallback(string condition, string stackTrace, LogType type)
        {
            if (this.mainThreadID != Thread.CurrentThread.ManagedThreadId)
                Output(condition, stackTrace, type);
        }

        private void LogCallback(string condition, string stackTrace, LogType type)
        {
            if (this.mainThreadID == Thread.CurrentThread.ManagedThreadId)
                Output(condition, stackTrace, type);
        }

        void Output(string log, string track, LogType type)
        {
            LogLevel level = this.logTypeLevelDict[type];
            LogData logData = new LogData
            {
                Log = log,
                Track = track,
                Level = level,
            };
            for (int i = 0; i < this.logOutputList.Count; ++i)
                this.logOutputList[i].Log(logData);
        }

        /// <summary>
        /// 输出Log
        /// </summary>
        public static void Log()
        {

        }

        void OnDestroy()
        {
            Application.logMessageReceived -= LogCallback;
            Application.logMessageReceivedThreaded -= LogMultiThreadCallback;
        }

    }
}
