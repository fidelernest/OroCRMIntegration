using Newtonsoft.Json;
using OroClient.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OroClient.Utils
{
    public  class ApiConsumer
    {
        public static async Task<string> getEndPoint(string URL)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(URL),
				Headers =
			{
				{ "Accept", "application/vnd.api+json" },
				{ "Authorization", "WSSE profile=\"UsernameToken\"" },
				{ "X-WSSE", Wsse.GenerateHeader() },
			},
					};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var respuesta = await response.Content.ReadAsStringAsync();
				return respuesta;
			}
		}

		public static async Task patchEndPoint(string URL, UserRoot body)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Patch,
				RequestUri = new Uri("http://orocrm.eastus.cloudapp.azure.com/api/users/3"/*URL*/),
				Headers =
				{
					{ "Accept", "application/vnd.api+json" },
					{ "Authorization", "WSSE profile=\"UsernameToken\"" },
					{ "X-WSSE", Wsse.GenerateHeader() },
				},
				Content =  new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
			};
			var response = await client.SendAsync(request);
			
		}
	}
}
