namespace LP1_FOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArgsParser argsParser = new ArgsParser();
            CommandLineArguments commandLineArguments = argsParser.Parse(args);

            if (string.IsNullOrWhiteSpace(commandLineArguments.FilePath))
            {
                Console.WriteLine("Please provide a valid file path using the --file argument.");
                return;
            }

            //string logFilePath = "C:\\Users\\Pierre\\source\\repos\\LP1_FOOP\\LP1_FOOP\\System.log.txt";
            // Test

            IEnumerable<LogMessage> logMessages = commandLineArguments.FilePath.ParseLogFile();

            //IEnumerable<LogMessage> filteredMessages = logMessages.Where(m => m.TypeName == "GenericUnstructured");

            logMessages = ApplyFilters(logMessages, commandLineArguments);
            logMessages = ApplySorting(logMessages, commandLineArguments);

            foreach (var logMessage in logMessages)
            {
                Console.WriteLine(logMessage.ToOutputString());
            }
        }

        private static IEnumerable<LogMessage> ApplyFilters(
            IEnumerable<LogMessage> messages,
             CommandLineArguments commandLineArguments)
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

        private static IEnumerable<LogMessage> ApplySorting(
            IEnumerable<LogMessage> messages,
             CommandLineArguments commandLineArguments)
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
