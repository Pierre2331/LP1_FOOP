using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public abstract class StructuredLogMessage : LogMessage
    {
        protected StructuredLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent)
            : base(originalLine, timeStamp, typeName)
        {
            ProcessName = processName;
            ProcessNumber = processNumber;
            Category = category;
            Level = level;
            LogMessageType = lowMessageType;
            MessageContent = messageContent;
        }

        public string ProcessName
        {
            get;
        }

        public int ProcessNumber
        {
            get;
        }

        public string Category
        {
            get;
        }

        public string Level
        {
            get;
        }

        public string LogMessageType
        {
            get;
        }

        public string MessageContent
        {
            get;
        }
    }
}