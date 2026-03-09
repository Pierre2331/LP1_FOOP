using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LP1_FOOP
{
    public class LogLineParser
    {
        public LogMessage Parse(string line)
        {
            Match match = MatchStructuredLine(line);

            if (!match.Success)
            {
                return new GenericUnstructuredLogMessage(line);
            }

            return CreateGenericStructuredLogMessage(line, match);
        }

        private Match MatchStructuredLine(string line)
        {
            string pattern = @"^(?<processName>.+?)\s+\((?<processNumber>\d+)\),\s+(?<timestamp>\d{4}\.\d{2}\.\d{2}\s+\d{2}:\d{2}:\d{2}\.\d{3}),\s+(?<category>.+?),\s+(?<level>.+?),\s+(?<logMessageType>.+?),\s+(?<messageContent>.*)$";

            return Regex.Match(line, pattern);
        }

        private GenericStructuredLogMessage CreateGenericStructuredLogMessage(string line, Match match)
        {
            string processName = match.Groups["processName"].Value.Trim();
            int processNumber = int.Parse(match.Groups["processNumber"].Value);
            DateTime timestamp = DateTime.ParseExact(match.Groups["timestamp"].Value, "yyyy.MM.dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            string category = match.Groups["category"].Value.Trim();
            string level = match.Groups["level"].Value.Trim();
            string lowMessageType = match.Groups["logMessageType"].Value.Trim();
            string messageContent = match.Groups["messageContent"].Value;

            return new GenericStructuredLogMessage(
                line,
                timestamp,
                "GenericStructured",
                processName,
                processNumber,
                category,
                level,
                lowMessageType,
                messageContent
                );
        }
    }
}