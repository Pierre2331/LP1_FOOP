namespace LP1_FOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "C:\\Users\\Pierre\\source\\repos\\LP1_FOOP\\LP1_FOOP\\System.log.txt";
            // Test

            IEnumerable<LogMessage> logMessages = logFilePath.ParseLogFile();

            foreach (var logMessage in logMessages)
            {
                Console.WriteLine(logMessage.ToOutputString());
            }
        }
    }
}
