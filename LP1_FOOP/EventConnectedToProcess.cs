using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class EventConnectedToProcessParser : IConcreteMessageParser
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
            return processName == "WCCILevent" && logMessageType == "4";
        }

        private Match MatchMessageContent(string messageContent)
        {
            string pattern = @"^Connected to \(SYS:\s+(?<sysnum>\d+)\s+(?<ptype>\.+?)\s+-num\s+(?<pnum>\d+)\s+CONN:\s+(?<connum>\d+)\)\s+@\s+(?<host>.+?)\s+\((?<ip>.+?)\)$";

            return Regex.Match(messageContent, pattern);
        }

        private EventConnectedToProcessLogMessage CreateMessage(
            GenericStructuredLogMessage genericStructuredLogMessage,
            Match match)
        {
            int systemNumber = int.Parse(match.Groups["sysnum"].Value);
            string connectedProcessType = match.Groups["ptype"].Value;
            int connectedProcessNumber = int.Parse(match.Groups["pnum"].Value);
            int connectionNumber = int.Parse(match.Groups["connum"].Value);
            string hostname = match.Groups["host"].Value;
            string ipAddress = match.Groups["ip"].Value;

            return new EventConnectedToProcessLogMessage(genericStructuredLogMessage.OriginalLine, genericStructuredLogMessage.TimeStamp, "EventConnectedToProcess", genericStructuredLogMessage.ProcessName, genericStructuredLogMessage.ProcessNumber, genericStructuredLogMessage.Category, genericStructuredLogMessage.Level, genericStructuredLogMessage.LogMessageType, genericStructuredLogMessage.MessageContent, systemNumber, connectedProcessType, connectedProcessNumber, connectionNumber, hostname, ipAddress);
        }
    }
}