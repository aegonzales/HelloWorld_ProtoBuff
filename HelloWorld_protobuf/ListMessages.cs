using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using System.IO;
using HelloWorld;

namespace HelloWorld_protobuf
{
    class ListMessages
    {
        private static void Print(Log messages)
        {
            int counter = 0;
            foreach (Talk message in messages.Messages)
            {
                counter++;
                Console.WriteLine("Message Count: {0}", counter);
                Console.WriteLine("SUBJECT: {0}", message.Subject);
                Console.WriteLine("  MESSAGE: {0}", message.Message);
            }
        }

        /// <summary>
        /// Entry point - loads the addressbook and then displays it.
        /// </summary>
        public static void Main(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} doesn't exist. Add a message to create the file first.", fileName);
                return;
            }

            // Read the existing address book.
            using (Stream stream = File.OpenRead(fileName))
            {
                Log messages = Log.Parser.ParseFrom(stream);
                Print(messages);
            }
        }
    }
}
