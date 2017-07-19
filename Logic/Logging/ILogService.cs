using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logging
{
    public interface ILogService
    {
        void DebugWriteToLog(DateTime time, string recordInfo, string record);
        void InfoWriteToLog(DateTime time, string recordInfo, string record);
        void WarnWriteToLog(DateTime time, string recordInfo, string record);
        void ErrorWriteToLog(DateTime time, string recordInfo, string record);
        void FatalWriteToLog(DateTime time, string recordInfo, string record);
    }
}
