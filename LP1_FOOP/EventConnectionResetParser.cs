using System;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class EventConnectionResetParser : IConcreteMessageParser
    {
        public LogMessage Parse(GenericStructuredLogMessage genericStructuredLogMessage)
        {
            if (!IsMatchingType(genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.Level, genericStructuredLogMessage.LogMessageType))
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

        private bool IsMatchingType(string processName, string level, string logMessageType)
        {
            return processName == "WCCILevent"
                   && level == "WARNING"
                   && logMessageType == "39";
        }

        private Match MatchMessageContent(string messageContent)
        {
            string pattern =
                @"^Connection lost,\s+MAN:\s+\(SYS:\s+(?<sysnum>\d+)\s+(?<ptype>\S+)\s+-num\s+(?<pnum>\d+)\s+CONN:\s+(?<connum>\d+)\),\s+Connection reset by peer\s+\((?<reason>\d+)\)$";

            return Regex.Match(messageContent, pattern);
        }

        private EventConnectionResetLogMessage CreateMessage(
            GenericStructuredLogMessage genericStructuredLogMessage,
            Match match)
        {
            int systemNumber = int.Parse(match.Groups["sysnum"].Value);
            string connectedProcessType = match.Groups["ptype"].Value.Trim();
            int connectedProcessNumber = int.Parse(match.Groups["pnum"].Value);
            int connectionNumber = int.Parse(match.Groups["connum"].Value);
            int reasonNumber = int.Parse(match.Groups["reason"].Value);

            return new EventConnectionResetLogMessage(
                genericStructuredLogMessage.OriginalLine,
                genericStructuredLogMessage.TimeStamp,
                "EventConnectionReset",
                genericStructuredLogMessage.ProcessName,
                genericStructuredLogMessage.ProcessNumber,
                genericStructuredLogMessage.Category,
                genericStructuredLogMessage.Level,
                genericStructuredLogMessage.LogMessageType,
                genericStructuredLogMessage.MessageContent,
                systemNumber,
                connectedProcessType,
                connectedProcessNumber,
                connectionNumber,
                reasonNumber);
        }
    }
}