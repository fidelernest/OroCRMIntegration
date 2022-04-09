using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OroClient.Utils
{
    public class ApiConsumer : IApiConsumer
	{
		public static string BaseUrl => "http://orocrm.eastus.cloudapp.azure.com";

		private string GetUrl(string uri)
        {
			return $"{BaseUrl}{uri}";
        }

        public async Task<HttpResponseMessage> Get(string uri)
        {
			var client = new HttpClient();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(GetUrl(uri)),
				Headers =
				{
					{ "Accept", "application/vnd.api+json" },
					{ "Authorization", "WSSE profile=\"UsernameToken\"" },
					{ "X-WSSE", Wsse.GenerateHeader() },
				}
			};

			var response = await client.SendAsync(request);

			return response;
		}

		public async Task<HttpResponseMessage> Patch(string uri, dynamic body)
		{
			var client = new HttpClient();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Patch,
				RequestUri = new Uri(GetUrl(uri)),
				Headers =
				{
					{ "Accept", "application/vnd.api+json" },
					{ "Authorization", "WSSE profile=\"UsernameToken\"" },
					{ "X-WSSE", Wsse.GenerateHeader() },
				},
				Content =  new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
			};
			
			var response = await client.SendAsync(request);

			return response;
		}

		public async Task<HttpResponseMessage> Post(string uri, dynamic body)
		{
			var client = new HttpClient();

			string stringBody = JsonConvert.SerializeObject(body);

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(GetUrl(uri)),
				Headers =
				{
					{ "Accept", "application/vnd.api+json" },
					{ "Authorization", "WSSE profile=\"UsernameToken\"" },
					{ "X-WSSE", Wsse.GenerateHeader() },
				},
				Content = new StringContent(stringBody, Encoding.UTF8, "application/json")
			};


			var response = await client.SendAsync(request);

			return response;
		}
	}

	public interface IApiConsumer
    {
		Task<HttpResponseMessage> Get(string uri);
		Task<HttpResponseMessage> Patch(string uri, dynamic body);
		Task<HttpResponseMessage> Post(string uri, dynamic body);
	}
}
