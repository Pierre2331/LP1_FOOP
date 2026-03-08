using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class EventConnectionClosedParser : IConcreteMessageParser
    {
        public LogMessage Parse(string originalLine, DateTime timestamp, string processName, int processNumber, string category, string level, string logMessageType, string messageContent)
        {
            if (!isMatchingType(processName, logMessageType, level))
            {
                return null;
            }

            Match match = MatchMessageContent(messageContent);

            if (!match.Success)
            {
                return null;
            }

            return CreateMessage(originalLine, timestamp, processName, processNumber, category, level, logMessageType, messageContent, match);
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
            string originalLine,
            DateTime timestamp,
            string processName,
            int processNumber,
            string category,
            string level,
            string logMessageType,
            string messageContent,
            Match match)
        {
            int systemNumber = int.Parse(match.Groups["sysnum"].Value);
            string connectedProcessType = match.Groups["ptype"].Value;
            int connectedProcessNumber = int.Parse(match.Groups["pnum"].Value);
            int connectionNumber = int.Parse(match.Groups["connum"].Value);

            return new EventConnectionClosedLogMessage(originalLine, timestamp, "EventConnectedToProcess", processName, processNumber, category, level, logMessageType, messageContent, systemNumber, connectedProcessType, connectedProcessNumber, connectionNumber);
        }
    }
}