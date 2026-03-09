using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public interface IFilter
    {
        public IEnumerable<LogMessage> ApplyFilter(IEnumerable<LogMessage> messages, CommandLineArguments commandLineArguments);
    }
}