using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SSIEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Reporterinfo reporterinfo = new Reporterinfo
            {
                reporterName = "YourName",
                reporterOrg = "YourOrg",
                reporterPhone = "YourPhoneNumber",
                reporterNotes = "NotesAboutYou",
                reporterEmail = "YourEmail",
                discloseEmail = true
            };
            Issue1 issue1 = new Issue1
            {
                batchID = "BatchID",
                relatedCases = "AnyRelatedCases",
                issueType = "IssueType",
                issueNotes = "IssueNotes",
                sampleType = "TypeOfSample",
                url = "URL",
                sample = "sample",
                piiPresent = true,
                piiDescription = "piiDescription",
                publiclyKnown = true,
                publicUrl = "PublicURL",
                isWebApp = true
            };
            Issue issue = new Issue()
            {
                issue = issue1
            };
            SSIObject ssi = new SSIObject
            {
                reporterInfo = reporterinfo,
                issues = new[] {issue},
            };
        }
        static async Task MakeRequest(SSIObject ssi)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("api-key", "62767bad6f034eaabde3ffa2c455bce7");

            var uri = "https://api.msrc.microsoft.com/engage/ssi" + queryString;

            HttpResponseMessage response;

            // Request body
            string str = JsonConvert.SerializeObject(ssi);

            using (var content = new StringContent(str))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

        }
    }

    public class SSIObject
    {
        public Reporterinfo reporterInfo { get; set; }
        public Issue[] issues { get; set; }
    }

    public class Reporterinfo
    {
        public string reporterEmail { get; set; }
        public string reporterName { get; set; }
        public string reporterPhone { get; set; }
        public string reporterOrg { get; set; }
        public bool discloseEmail { get; set; }
        public string reporterNotes { get; set; }
    }

    public class Issue
    {
        public Issue1 issue { get; set; }
    }

    public class Issue1
    {
        public string batchID { get; set; }
        public string relatedCases { get; set; }
        public string issueType { get; set; }
        public string issueNotes { get; set; }
        public string sampleType { get; set; }
        public string url { get; set; }
        public string sample { get; set; }
        public bool piiPresent { get; set; }
        public string piiDescription { get; set; }
        public bool publiclyKnown { get; set; }
        public string publicUrl { get; set; }
        public bool isWebApp { get; set; }
    }

}
