using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP1_FOOP
{
    public class CommandLineArguments
    {
        public string FilePath { get; set; }

        public string FilterType { get; set; }

        public DateTime? FilterTimeGreaterThan { get; set; }

        public DateTime? FilterTimeSmallerThan { get; set; }

        public string SortByTime { get; set; }
    }
}
