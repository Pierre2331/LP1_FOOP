using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public interface IConcreteMessageParser
    {
        LogMessage Parse(GenericStructuredLogMessage genericStructuredLogMessage);
    }
}