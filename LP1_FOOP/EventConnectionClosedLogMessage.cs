using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class EventConnectionClosedLogMessage : StructuredLogMessage
    {
        public EventConnectionClosedLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent, int systemNumber, string connectedProcessType, int connectedProcessNumber, int connectionNumber)
            : base(originalLine, timeStamp, typeName, processName, processNumber, category, level, lowMessageType, messageContent)
        {
            SystemNumber = systemNumber;
            ConnectedProcessType = connectedProcessType;
            ConnectedProcessNumber = connectedProcessNumber;
            ConnectionNumber = connectionNumber;
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
    }
}