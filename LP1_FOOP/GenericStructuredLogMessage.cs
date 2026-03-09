using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class GenericStructuredLogMessage : StructuredLogMessage
    {
        public GenericStructuredLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent) : base(originalLine, timeStamp, typeName, processName, processNumber, category, level, lowMessageType, messageContent)
        {
        }

        public override string ToOutputString()
        {
            return $"GenericStructured: {TimeStamp:yyyy.MM.dd HH:mm:ss.fff} {ProcessName}({ProcessNumber}), {Category}, {Level}, {LogMessageType}, {MessageContent}";
        }
    }
}