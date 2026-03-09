using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP1_FOOP
{
    public class ArgsParser
    {
        public CommandLineArguments Parse(string[] args)
        {
            CommandLineArguments commandLineArguments = new CommandLineArguments();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-file" && i + 1 < args.Length)
                {
                    commandLineArguments.FilePath = args[++i];
                }
                else if (args[i] == "-filterType" && i + 1 < args.Length)
                {
                    commandLineArguments.FilterType = args[++i];
                }
                else if (args[i] == "-filterTimeGreaterThan" && i + 1 < args.Length)
                {
                    commandLineArguments.FilterTimeGreaterThan = DateTime.ParseExact(args[++i], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                }
                else if (args[i] == "-filterTimeSmallerThan" && i + 1 < args.Length)
                {
                    commandLineArguments.FilterTimeSmallerThan = DateTime.ParseExact(args[++i], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                }
                else if (args[i] == "-sortByTime" && i + 1 < args.Length)
                {
                    commandLineArguments.SortByTime = args[++i];
                }
            }


            return commandLineArguments;
        }
    }
}
