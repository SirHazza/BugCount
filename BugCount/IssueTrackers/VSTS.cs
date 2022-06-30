using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BugCount
{
    class VSTS
    {
        public static void GetIssues(string num, int client, string type, string URL)
        {
            
            Console.WriteLine(num + "/" + Program.totalADO + " " + Clients.list[client][0]);

            // Selects array positon for bug type, from qa/uat
            int bugType = 1;
            switch (type)
            {
                case "qa":
                    bugType = 1;
                    break;

                case "uat":
                    bugType = 2;
                    break;
            }

            //Get JSON from URL
            string jiraJson = GetJiraJSON((string)Clients.list[client][3], URL);

            if (jiraJson != null)
            {
                // Text into JSON object
                JObject jiraResults = JObject.Parse(jiraJson);
                // Get JSON list of issues
                IList<JToken> issues = jiraResults["workItems"].Children().ToList();

                // Steps through issues
                foreach (JToken issue in issues)
                {
                    // Adds bug to count
                    Methods.AddBug(client, bugType);

                }
            }
            else
            {
                Methods.NoBugs(client, bugType);
            }

        }

        public static string GetJiraJSON(string paToken, string URL)
        {
            try
            {
                // With auth, return JSON
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", paToken)));

                using (WebClient webClient = new WebClient())
                {
                    // Set auth header
                    webClient.Headers.Set("Authorization", "Basic " + credentials);
                    // Get JSON page
                    return webClient.DownloadString(URL);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("(!) Can't get data");
                return null;
            }

            
        }

    }
}