using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LP1_FOOP
{
    public class EventConnectionResetLogMessage : GenericStructuredLogMessage
    {
        public EventConnectionResetLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent, int systemNumber, string connectedProcessType, int connectedProcessNumber, int connectionNumber, int reasonNumber)
            : base(originalLine, timeStamp, typeName, processName, processNumber, category, level, lowMessageType, messageContent)
        {
            SystemNumber = systemNumber;
            ConnectedProcessType = connectedProcessType;
            ConnectedProcessNumber = connectedProcessNumber;
            ConnectionNumber = connectionNumber;
            ReasonNumber = reasonNumber;
        }

        public int SystemNumber
        {
            get;
        }

        public string ConnectedProcessType
        {
            get;
        }

        public int ConnectedProcessNumber
        {
            get;
        }

        public int ConnectionNumber
        {
            get;
        }

        public int ReasonNumber
        {
            get;
        }

        public override string ToOutputString()
        {
            return $"EventConnectionReset: {TimeStamp:yyyy.MM.dd HH:mm:ss.fff} {ProcessName}({ProcessNumber}), {Category}, {Level}, {LogMessageType}, {MessageContent}, {SystemNumber}, {ConnectedProcessType}, {ConnectedProcessNumber}, {ConnectionNumber}, {ReasonNumber}";
        }
    }
}