using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public abstract class LogMessage
    {
        protected LogMessage(string originalLine, DateTime? timeStamp, string typeName)
        {
            OriginalLine = originalLine;
            TimeStamp = timeStamp;
            TypeName = typeName;
        }
        public string OriginalLine
        {
            get;
        }

        public System.DateTime? TimeStamp
        {
            get;
        }

        public string TypeName
        {
            get;
        }

        public virtual string ToOutputString()
        {
            return OriginalLine;
        }
    }
}