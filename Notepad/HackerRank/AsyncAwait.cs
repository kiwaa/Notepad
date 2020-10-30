using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Notepad.CSharp
{
    class AsyncAwait
    {
        public async Task<int> Query(string substr)
        {
            var query = "https://jsonmock.hackerrank.com/api/movies/search/?Title=" + substr;
            var client = new HttpClient();
            var response = await client.GetAsync(query);
            var data = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(data);
            var total = obj["total"].ToObject<int>();
            return total;
        }
    }
}
