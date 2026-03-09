namespace LP1_FOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "C:\\Users\\Felix\\Desktop\\FH Projekte\\LP1_FOOP\\LP1_FOOP\\System.log.txt";
            // Test

            IEnumerable<LogMessage> logMessages = logFilePath.ParseLogFile();

            IEnumerable<LogMessage> filteredMessages = logMessages.Where(m => m.TypeName == "GenericStructured");


            foreach (var logMessage in filteredMessages)
            {
                Console.WriteLine(logMessage.ToOutputString());
            }
        }
    }
}
