using System;

namespace BugCount
{
    class Clients
    {
        // Array of clients
        public static object[][] list = new Object[][]
        {
            new Object[] { "ABC", 0, 0, "sivz6lwho7fpsdy4lgsue3pr5rhx6j4hszn6p2itpy6n42sjlw7a" }, //  0 ClientOne
            new Object[] { "DEF", 0, 0, "JIRA" },                                                 //  1 ClientTwo
            new Object[] { "GHI", 0, 0, "JIRA" },                                                 //  2 ClientThree
            new Object[] { "JKL", 0, 0, "sivz6lwho7fpsdy4lgsue3pr5rhx6j4hszn6p2itpy6n42sjlw7a" }  //  3 ClientFour
        };

        // Array structure - Client, QA bugs, UAT bugs, VSTS PAT

        public static void ConsoleOutput()
        {
            Console.WriteLine();
            Console.WriteLine("Client/QA");

            // Steps through array and outputs data
            int step = 0;
            foreach (Object client in list)
            {
                Console.WriteLine(list[step][0] + "\t" + "\t" + list[step][1] + " " + list[step][2]);
                step += 1;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close...");

        }

        public static void TextFileOutput()
        {
            string[] lines = new string[list.Length + 3];

            //Stores key data
            lines[0] = "QA - Bug count";
            lines[1] = "Date & Time: " + DateTime.Now.ToString("_ddMMyyyy_HHmmss");
            lines[2] = "";

            // Steps through array and outputs data
            int step = 0;
            foreach (Object client in list)
            {
                lines[step + 3] = (list[step][0] + "\t" + "\t" + list[step][1] + " " + list[step][2]);
                step += 1;
            }

            //Output text file
            System.IO.File.WriteAllLines(@"C:\BugCount\BugCount.txt", lines);
        }

    }

}
