using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Google.Protobuf;
using HelloWorld;

namespace HelloWorld_protobuf
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("Usage: Message [file]");
                Console.Error.WriteLine("If the filename isn't specified, \"messageLog.data\" is used instead.");
            }
            string messageLogFile = args.Length > 0 ? args[0] : "messageLog.data";

            bool stopping = false;
            while (!stopping)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("  L: List of Message");
                Console.WriteLine("  A: Add new Message");
                Console.WriteLine("  Q: Quit");
                Console.Write("Action? ");
                Console.Out.Flush();
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case 'A':
                        case 'a':
                            AddMessage.Main(messageLogFile);
                            break;
                        case 'L':
                        case 'l':
                            ListMessages.Main(messageLogFile);
                            break;
                        case 'Q':
                        case 'q':
                            stopping = true;
                            break;
                        default:
                            Console.WriteLine("Unknown option: {0}", choice);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception executing action: {0}", e);
                }
                Console.WriteLine();
            }
        }
    }
}
