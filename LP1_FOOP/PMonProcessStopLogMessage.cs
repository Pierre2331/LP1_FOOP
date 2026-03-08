using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class PMonProcessStopLogMessage : StructuredLogMessage
    {
        public PMonProcessStopLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent, string targetProcessName, int targetProcessNumber, string signalType) : base(originalLine, timeStamp, "17/Pmon", processName, processNumber, category, level, lowMessageType, messageContent)
        {
            TargetProcessName = targetProcessName;
            TargetProcessNumber = targetProcessNumber;
            SignalType = signalType;
        }

        public string TargetProcessName
        {
            get;
        }

        public int TargetProcessNumber
        {
            get;
        }

        public string SignalType
        {
            get;
        }
    }
}