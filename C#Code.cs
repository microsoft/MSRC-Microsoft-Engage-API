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
			CERTReport cert = new CERTReport
			{
				// Data model documentation at https://msrc.microsoft.com/report/developer
			};

			MakeRequest(cert).GetAwaiter().GetResult();
		}


		static async Task MakeRequest(CERTReport cert)
		{
			var client = new HttpClient();
			var queryString = HttpUtility.ParseQueryString(string.Empty);

			var uri = "https://api.msrc.microsoft.com/report/v2.0/abuse";

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
		// Data model documentation at https://msrc.microsoft.com/report/developer
	}
}
