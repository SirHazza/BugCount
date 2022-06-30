using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BugCount
{
    class Jira
    {

        public static void GetIssues(string issueType)
        {

            //string jiraJson = File.ReadAllText(@"C:\json\search.json");

            // Selects which issue type to search
            string LinkJSON = "";
            switch (issueType)
            {
                case "bug":
                    LinkJSON = "https://godzilla.example.com/rest/api/2/search?jql=issuetype=%20Bug%20AND%20created%20%3E=%20-6d";
                    break;

                case "sub-task":
                    LinkJSON = "https://godzilla.example.com/rest/api/2/search?jql=issuetype=sub-task%20AND%20created%20%3E=%20-6d";
                    break;
            }

            //Get JSON from URL
            string jiraJson = GetJiraJSON(LinkJSON);

            if (jiraJson != null)
            {
                // Text into JSON object
                JObject jiraResults = JObject.Parse(jiraJson);
                // Get JSON list of issues
                IList<JToken> issues = jiraResults["issues"].Children().ToList();

                // Steps through issues
                foreach (JToken issue in issues)
                {

                    // Gets fields tokens
                    JToken fields = issue["fields"]["project"]["key"];
                    // Converts to string
                    string issueKey = fields.ToObject<String>();

                    // Adds issue to project count
                    switch (issueKey)
                    {
                        case "DEF": // ClientTwo
                            Methods.AddBug(0, 1);
                            break;

                        case "GHI": // ClientThree
                            Methods.AddBug(1, 1);
                            break;

                        case "MNO": // ClientFive
                            Methods.AddBug(2, 1);
                            break;

                    }

                }
            }

        }

        public static string GetJiraJSON(string URL)
        {

            try
            {
                // With auth, return JSON
                var mergedCredentials = string.Format("{0}:{1}", Methods.JiraPass[0], Methods.JiraPass[1]);
                var byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
                var encodedCredentials = Convert.ToBase64String(byteCredentials);

                using (WebClient webClient = new WebClient())
                {
                    // Set auth header
                    webClient.Headers.Set("Authorization", "Basic " + encodedCredentials);
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