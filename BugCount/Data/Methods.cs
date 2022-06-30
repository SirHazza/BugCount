using System;

namespace BugCount
{
    class Methods
    {
        // Jira Credentials
        public static string[] JiraPass = new string[] { "JiraUser", "password123" };
        public static string[] JiraTwoPass = new string[] { "OtherUser", "auth456789" }; 

        public static void AddBug(int client, int type)
        {
            // Get current value
            int sum = (int)Clients.list[client][type];

            // Step up value and apply
            sum += 1;
            Clients.list[client][type] = sum;

        }


        public static void NoBugs(int client, int type)
        {
            // Get current value
            int sum = (int)Clients.list[client][type];

            // Step up value and apply
            sum = -99;
            Clients.list[client][type] = sum;

        }

    }
}
