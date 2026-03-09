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
            Sorter sorter = new Sorter();
            Filtering filter = new Filtering();


            logMessages = sorter.ApplyFilter(logMessages, commandLineArguments);
            logMessages = filter.ApplyFilter(logMessages, commandLineArguments);

            foreach (var logMessage in logMessages)
            {
                Console.WriteLine(logMessage.ToOutputString());
            }
        }
    }
}
