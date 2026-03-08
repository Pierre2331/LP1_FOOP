using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class PMonProcessStopParser : IConcreteMessageParser
    {
        public LogMessage Parse(string originalLine, DateTime timestamp, string processName, int processNumber, string category, string level, string logMessageType, string messageContent)
        {
            if (!isMatchingType(processName, logMessageType))
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

        private bool isMatchingType(string processName, string logMessageType)
        {
            return processName == "WCCILpmon" && logMessageType == "17/pmon";
        }

        private Match MatchMessageContent(string messageContent)
        {
            string pattern = @"^Stoppe Manager (?<targetName>.+?)\((?<targetNumber>\d+)\) mit Signal (?<signalType>.+)$";

            return Regex.Match(messageContent, pattern);
        }

        private PMonProcessStopLogMessage CreateMessage(string originalLine,
            DateTime timestamp,
            string processName,
            int processNumber,
            string category,
            string level,
            string logMessageType,
            string messageContent,
            Match match)
        {
            string targetProcessName = match.Groups["targetName"].Value.Trim();
            int targetProcessNumber = int.Parse(match.Groups["targetNumber"].Value);
            string signalType = match.Groups["signalType"].Value.Trim();

            return new PMonProcessStopLogMessage(originalLine,
                timestamp,
                "PMonProcessStop",
                processName,
                processNumber,
                category,
                level,
                logMessageType,
                messageContent,
                targetProcessName,
                targetProcessNumber,
                signalType);
        }
    }
}