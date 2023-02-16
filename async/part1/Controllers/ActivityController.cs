using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace part1.Controllers
{
    public class ActivityController : ApiController
    {
        private static readonly HttpClient _httpClient;

        static ActivityController()
        {
            _httpClient = new HttpClient();
        }

        [Route("api/activity")]
        public async Task<string> GetAsync()
        {
            var uri = "https://www.boredapi.com/api/activity";
            var response = await _httpClient.GetAsync(uri);
            var content = response.Content;
            if (content != null)
            {
                var responseJson = await content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseJson))
                {
                    dynamic jObj = JObject.Parse(responseJson);
                    return jObj.activity?.ToString();
                }
            }

            return null;
        }

        [Route("api/activities/serial")]
        public async Task<string[]> GetListSerialAsync(int n = 10)
        {
            var activities = new List<string>();

            for (int i = 0; i < n; i++)
            {
                activities.Add(await GetAsync());
            }

            return activities.ToArray();
        }

        [Route("api/activities")]
        public async Task<string[]> GetListAsync(int n = 10)
        {
            var tasks = new List<Task<string>>();
            var activities = new List<string>();

            for (int i = 0; i < n; i++)
            {
                tasks.Add(GetAsync());
            }

            // Wait for completion task
            await Task.WhenAll(tasks);

            // Harvest results
            tasks.ForEach(async t => activities.Add(await t));

            return activities.ToArray();
        }

    }
}
