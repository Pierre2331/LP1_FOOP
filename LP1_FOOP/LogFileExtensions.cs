using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP1_FOOP
{
    public static class LogFileExtensions
    {
        public static IEnumerable<LogMessage> ParseLogFile(this string filePath)
        {
            MessageFactory messageFactory = new MessageFactory();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                 
                    if (line != null)
                    {
                        LogMessage logMessage = messageFactory.ParseLine(line);
                    
                        if (logMessage != null)
                        {
                            yield return logMessage;
                        }
                    }
                }
            }
        }
    }
}