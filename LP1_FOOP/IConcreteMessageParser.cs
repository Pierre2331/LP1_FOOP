using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public interface IConcreteMessageParser
    {
        LogMessage Parse(
            string originalLine,
            DateTime timestamp,
            string processName,
            int processNumber,
            string category,
            string level,
            string logMessageType,
            string messageContent);
    }
}