using System;

namespace BugCount
{
    class Program
    {
        public static string totalADO = "4";

        static void Main(string[] args)
        {
            // JIRA Boards
            Console.WriteLine("JIRA CLIENTS");
            Jira.GetIssues("bug");
            Jira.GetIssues("sub-task");


            // VSTS Boards
            Console.WriteLine();
            Console.WriteLine("AZURE DEVOPS CLIENTS");


            // ClientOne
            VSTS.GetIssues("1", 0, "qa", "https://dev.azure.com/example/client/_apis/wit/wiql/e640cba1-db65-4709-95e8-321b92f3bd2e?api-version=4.1");

            // ClientTwo
            VSTS.GetIssues("2", 3, "qa", "https://dev.azure.com/example/client/_apis/wit/wiql/e0fd3c47-66ad-4811-9f16-b589f7faab71?api-version=4.1");

            // ClientThree
            VSTS.GetIssues("3", 4, "qa", "https://dev.azure.com/example/client/_apis/wit/wiql/fe8b643d-0de7-4ee8-a4ca-bbc7387f10e6?api-version=4.1");

            // ClientFour
            VSTS.GetIssues("4", 5, "qa", "https://example.visualstudio.com/client/_apis/wit/wiql/3cef624a-c76e-49b9-aacc-21f00b2d08aa?api-version=4.1");

            // Please update the totalADO value at the top of this class file

            // Run bug count output
            Clients.TextFileOutput();
            Clients.ConsoleOutput();
            Console.ReadLine();
        }
    }
}
