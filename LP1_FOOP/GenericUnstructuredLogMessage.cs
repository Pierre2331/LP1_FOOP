using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace LP1_FOOP
{
    public class GenericUnstructuredLogMessage : LogMessage
    {
        public GenericUnstructuredLogMessage(string rawContent) : base(rawContent, null, "GenericUnstructured")
        {
            RawContent = rawContent;
        }

        public string RawContent
        {
            get;
        }

        public override string ToOutputString()
        {
            return $"GenericUnstructured: {RawContent}";
        }
    }
}