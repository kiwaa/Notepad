using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using Notepad.CSharp;

namespace Notepad
{
    class Program
    {
        static void Main()
        {
            Console.CancelKeyPress += myHandler;
            while (true)
            {
                Console.WriteLine("CTRL+C to interrupt the read operation:");

                Console.ReadLine();
            }
        }

        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("\nThe read operation has been interrupted.");

            Console.WriteLine($"  Key pressed: {args.SpecialKey}");

            Console.WriteLine($"  Cancel property: {args.Cancel}");

            // Set the Cancel property to true to prevent the process from terminating.
            Console.WriteLine("Setting the Cancel property to true...");
            args.Cancel = true;

            // Announce the new value of the Cancel property.
            Console.WriteLine($"  Cancel property: {args.Cancel}");
            Console.WriteLine("The read operation will resume...\n");
        }

    }
}
