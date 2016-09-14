using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld;
using System.IO;
using Google.Protobuf;

namespace HelloWorld_protobuf
{
    class AddMessage
    {
        private static Talk SendMessage(TextReader input, TextWriter output)
        {
            Talk message = new Talk();

            output.Write("Enter Message Subject: ");
            message.Subject = input.ReadLine();

            output.Write("Enter messages: ");
            string email = input.ReadLine();

            return message;
        }

        public static void Main(string fileLog)
        {
            Log logMessage;

            if (File.Exists(fileLog))
            {
                using (Stream file = File.OpenRead(fileLog))
                {
                    logMessage = Log.Parser.ParseFrom(file);
                }
            }
            else
            {
                Console.WriteLine("{0}: File not found. Creating a new file.", fileLog);
                logMessage = new Log();
            }

            //Add Message.
            logMessage.Messages.Add(SendMessage(Console.In, Console.Out));

            // Write the new address book back to disk.
            using (Stream output = File.OpenWrite(fileLog))
            {
                logMessage.WriteTo(output);
            }
        }
    }
}
