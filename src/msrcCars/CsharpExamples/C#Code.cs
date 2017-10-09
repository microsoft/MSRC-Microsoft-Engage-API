//This is a working code sample of the CARS API Post Method
//Please fill in your own data before submiting
//You will need to insert your own api-key in order for it to post

using System;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CARSexample
{
	class Program
	{
		static void Main(string[] args)
		{
			Reporterinfo repinfo = new Reporterinfo
			{
				discloseEmail = "TRUE",
				reporterEmail = "yourname@yourorganization.com",
				reporterName = "You",
				reporterNotes = "This is a code sample test",
				reporterOrg = "YourOrganization",
				reporterPhone = "555-555-5555"
			};
			Threat1 threat1 = new Threat1()
			{
				threatType = "Activity",
				threatSubType = "INTRUSION_ATTEMPT",
				sampleType = "Base64",
				sourceIp = "1.1.1.1",
				destinationIp = "2.2.2.2",
				sourcePort = "22",
				destinationPort = "1433",
				protocol = "foo",
				byteCount = "600",
				packetCount = "20",
				date = DateTime.Now.ToString("yyyy-MM-dd"),
				time = DateTime.Now.ToString("hh:mm:ss"),
				timeZone = "-00:00",
				sample = "null",
				sourceUrl = "attacking url",
				destinationUrl = "attacked url"

			};
			Threat threat = new Threat()
			{
				threat = threat1
			};
			Threat[] t = new Threat[] { threat };
			Report1 rep1 = new Report1
			{
				disclosureNotes = "This is a test from example code on Git",
				reportNotes = "This is a test from example code on Git",
				TLP = "White",
				threats = t
			};
			Report rep = new Report
			{
				report = rep1
			};
			Report[] r = new Report[] { rep };
			CERTReport cert = new CERTReport
			{
				reporterInfo = repinfo,
				reports = r
			};

			MakeRequest(cert).GetAwaiter().GetResult();
		}


		static async Task MakeRequest(CERTReport cert)
		{
			var client = new HttpClient();
			var queryString = HttpUtility.ParseQueryString(string.Empty);

			// Request headers
			client.DefaultRequestHeaders.Add("api-key", "{your api-key}");

			var uri = "https://api.msrc.microsoft.com/engage/cars?" + queryString;

			HttpResponseMessage response;

			// Request body
			string str = JsonConvert.SerializeObject(cert);		//NewtonSoft serializes the object.toString() to JSON
			

			using (var content = new StringContent(str))
			{
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				response = await client.PostAsync(uri, content);
			}


		}

	}
	
	
	//This is the JSON body converted to C#
	public class CERTReport
	{
		public Reporterinfo reporterInfo { get; set; }
		//The report field is an array to allow you to submit multiple reports at once
		public Report[] reports { get; set; }
	}

	public class Reporterinfo
	{
		public string reporterEmail { get; set; }
		public string reporterName { get; set; }
		public string reporterPhone { get; set; }
		public string reporterOrg { get; set; }
		public string discloseEmail { get; set; }
		public string reporterNotes { get; set; }
	}

	public class Report
	{
		public Report1 report { get; set; }
	}

	public class Report1
	{
		public string batchID { get; set; }
		public string[] relatedCases { get; set; }
		public string reportNotes { get; set; }
		public string TLP { get; set; }
		public string disclosureNotes { get; set; }
		//The Threat field is an array to allow you to submit multiple Threats per report
		public Threat[] threats { get; set; }
	}

	public class Threat
	{
		public Threat1 threat { get; set; }
	}

	public class Threat1
	{
		public string threatType { get; set; }
		public string threatSubType { get; set; }
		public string sampleType { get; set; }
		public string sourceIp { get; set; }
		public string destinationIp { get; set; }
		public string sourcePort { get; set; }
		public string destinationPort { get; set; }
		public string sourceUrl { get; set; }
		public string destinationUrl { get; set; }
		public string protocol { get; set; }
		public string byteCount { get; set; }
		public string packetCount { get; set; }
		public string date { get; set; }
		public string time { get; set; }
		public string timeZone { get; set; }
		public string sample { get; set; }
	}
}
