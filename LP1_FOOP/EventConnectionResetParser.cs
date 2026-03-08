using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class EventConnectionResetParser : IConcreteMessageParser
    {
        public LogMessage Parse(
           string originalLine,
           DateTime timestamp,
           string processName,
           int processNumber,
           string category,
           string level,
           string logMessageType,
           string messageContent)
        {
            if (!IsMatchingType(processName, level, logMessageType))
            {
                return null;
            }

            Match match = MatchMessageContent(messageContent);

            if (!match.Success)
            {
                return null;
            }

            return CreateMessage(
                originalLine,
                timestamp,
                processName,
                processNumber,
                category,
                level,
                logMessageType,
                messageContent,
                match);
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
            string connectedProcessType = match.Groups["ptype"].Value.Trim();
            int connectedProcessNumber = int.Parse(match.Groups["pnum"].Value);
            int connectionNumber = int.Parse(match.Groups["connum"].Value);
            int reasonNumber = int.Parse(match.Groups["reason"].Value);

            return new EventConnectionResetLogMessage(
                originalLine,
                timestamp,
                "EventConnectionReset",
                processName,
                processNumber,
                category,
                level,
                logMessageType,
                messageContent,
                systemNumber,
                connectedProcessType,
                connectedProcessNumber,
                connectionNumber,
                reasonNumber);
        }
    }
}