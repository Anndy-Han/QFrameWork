using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    interface ILogOutput
    {
        void Log(QLog.LogData logData);

        void Close();
    }
}
