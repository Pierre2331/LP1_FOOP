using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class EventConnectedToProcessLogMessage : GenericStructuredLogMessage
    {
        public EventConnectedToProcessLogMessage(string originalLine, DateTime? timeStamp, string typeName, string processName, int processNumber, string category, string level, string lowMessageType, string messageContent, int systemNumber, string connectedProcessType, int connectedProcessNumber, int connectionNumber, string hostname, string ipAddress) 
            : base(originalLine, timeStamp, typeName, processName, processNumber, category, level, lowMessageType, messageContent)
        {
        }

        public int SystemNumber
        {
            get;
        }

        public int ConnectedProcessType
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

        public int Hostname
        {
            get;
        }

        public int IPAddress
        {
            get;
        }

        public override string ToOutputString()
        {
            return $"EventConnectedToProcess: {TimeStamp:yyyy.MM.dd HH:mm:ss.fff} {ProcessName}({ProcessNumber}), {Category}, {Level}, {LogMessageType}, {MessageContent}, {SystemNumber}, {ConnectedProcessType}, {ConnectedProcessNumber}, {ConnectionNumber}, {Hostname}, {IPAddress}";
        }
    }
}