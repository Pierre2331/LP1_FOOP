using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class MessageFactory
    {
        private readonly LogLineParser _logLineParser;
        private readonly List<IConcreteMessageParser> _concreteMessageParsers;

        public MessageFactory()
        {
            _logLineParser = new LogLineParser();
            _concreteMessageParsers = new List<IConcreteMessageParser>
            {
                new PMonProcessStopParser(),
                new EventConnectedToProcessParser(),
                new EventConnectionClosedParser(),
                new EventConnectionResetParser()
            };
        }

        public LogMessage ParseLine(string line)
        {
            LogMessage parsedMessage = _logLineParser.Parse(line);

            if (parsedMessage is GenericUnstructuredLogMessage)
            {
                return parsedMessage;
            }

            GenericStructuredLogMessage structuredLogMessage = (GenericStructuredLogMessage)parsedMessage;

            foreach (IConcreteMessageParser parser in _concreteMessageParsers)
            {
                if(!structuredLogMessage.TimeStamp.HasValue)
                {
                    return structuredLogMessage;
                }

                LogMessage concreteMessage = parser.Parse(structuredLogMessage);
                

                if (concreteMessage != null)
                {
                    return concreteMessage;
                }
            }

            return structuredLogMessage;
        }
    }
}