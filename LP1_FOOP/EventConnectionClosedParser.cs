using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class EventConnectionClosedParser : IConcreteMessageParser
    {
        public LogMessage Parse(GenericStructuredLogMessage genericStructuredLogMessage)
        {
            if (!isMatchingType(genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.LogMessageType, genericStructuredLogMessage.Level))
            {
                return null;
            }

            Match match = MatchMessageContent(genericStructuredLogMessage.MessageContent);

            if (!match.Success)
            {
                return null;
            }

            return CreateMessage(genericStructuredLogMessage, match);
        }

        private bool isMatchingType(string processName, string logMessageType, string level)
        {
            return processName == "WCCILevent" && logMessageType == "39" && level == "INFO";
        }

        private Match MatchMessageContent(string messageContent)
        {
            string pattern = @"^Connection\s+lost,\s+MAN:\s+\(SYS:\s+(?<sysnum>\d+)\s+(?<ptype>.+?)\s+-num\s+(?<pnum>\d+)\s+CONN:\s+(?<connum>\d+)\),\s+Connection\s+closed$";

            return Regex.Match(messageContent, pattern);
        }

        private EventConnectionClosedLogMessage CreateMessage(
            GenericStructuredLogMessage genericStructuredLogMessage,
            Match match)
        {
            int systemNumber = int.Parse(match.Groups["sysnum"].Value);
            string connectedProcessType = match.Groups["ptype"].Value;
            int connectedProcessNumber = int.Parse(match.Groups["pnum"].Value);
            int connectionNumber = int.Parse(match.Groups["connum"].Value);

            return new EventConnectionClosedLogMessage(genericStructuredLogMessage.OriginalLine, genericStructuredLogMessage.TimeStamp, "EventConnectionClosed", genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.ProcessNumber, genericStructuredLogMessage.Category, genericStructuredLogMessage.Level, genericStructuredLogMessage.LogMessageType, genericStructuredLogMessage.MessageContent, systemNumber, connectedProcessType, connectedProcessNumber, connectionNumber);
        }
    }
}