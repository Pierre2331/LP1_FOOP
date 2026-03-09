using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class Filtering : IFilter
    {
        public IEnumerable<LogMessage> ApplyFilter(IEnumerable<LogMessage> messages, CommandLineArguments commandLineArguments)
        {
            if (!string.IsNullOrWhiteSpace(commandLineArguments.FilterType))
            {
                messages = messages.Where(message => message.TypeName == commandLineArguments.FilterType);
            }

            if (commandLineArguments.FilterTimeGreaterThan.HasValue)
            {
                messages = messages.Where(message =>
                    message.TimeStamp.HasValue &&
                    message.TimeStamp.Value > commandLineArguments.FilterTimeGreaterThan.Value);
            }

            if (commandLineArguments.FilterTimeSmallerThan.HasValue)
            {
                messages = messages.Where(message =>
                    message.TimeStamp.HasValue &&
                    message.TimeStamp.Value < commandLineArguments.FilterTimeSmallerThan.Value);
            }

            return messages;
        }
    }
}