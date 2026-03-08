using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public class GenericUnstructuredLogMessage : LogMessage
    {
        public GenericUnstructuredLogMessage(string rawContent) : base(rawContent, null, "GenericUnstructred")
        {
            RawContent = rawContent;
        }

        public string RawContent
        {
            get;
        }
    }
}