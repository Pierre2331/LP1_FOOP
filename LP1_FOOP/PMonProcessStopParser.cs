using System;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class PMonProcessStopParser : IConcreteMessageParser
    {
        public LogMessage Parse(GenericStructuredLogMessage genericStructuredLogMessage)
        {
            if (!isMatchingType(genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.LogMessageType))
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

        private bool isMatchingType(string processName, string logMessageType)
        {
            return processName == "WCCILpmon" && logMessageType == "17/pmon";
        }

        private Match MatchMessageContent(string messageContent)
        {
            string pattern = @"^Stoppe Manager (?<targetName>.+?)\((?<targetNumber>\d+)\) mit Signal (?<signalType>.+)$";

            return Regex.Match(messageContent, pattern);
        }

        private PMonProcessStopLogMessage CreateMessage(
            GenericStructuredLogMessage genericStructuredLogMessage,
            Match match)
        {
            string targetProcessName = match.Groups["targetName"].Value.Trim();
            int targetProcessNumber = int.Parse(match.Groups["targetNumber"].Value);
            string signalType = match.Groups["signalType"].Value.Trim();

            return new PMonProcessStopLogMessage(
                genericStructuredLogMessage.OriginalLine, genericStructuredLogMessage.TimeStamp, "EventConnectedToProcess", genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.ProcessNumber, genericStructuredLogMessage.Category, genericStructuredLogMessage.Level, genericStructuredLogMessage.LogMessageType, genericStructuredLogMessage.MessageContent,
                targetProcessName,
                targetProcessNumber,
                signalType);
        }
    }
}