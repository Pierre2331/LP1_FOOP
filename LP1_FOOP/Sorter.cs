using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class Sorter : IFilter
    {
        public IEnumerable<LogMessage> ApplyFilter(IEnumerable<LogMessage> messages, CommandLineArguments commandLineArguments)
        {
            if (commandLineArguments.SortByTime == "ASC")
            {
                return messages.OrderBy(message => message.TimeStamp);
            }

            if (commandLineArguments.SortByTime == "DESC")
            {
                return messages.OrderByDescending(message => message.TimeStamp);
            }

            return messages;
        }
    }
}