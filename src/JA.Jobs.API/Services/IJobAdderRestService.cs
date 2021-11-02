using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace JA.Jobs.API.Services
{
    public interface IJobAdderRestService
    {
        [Get("/jobs")]
        Task<IEnumerable<JobDto>> GetJobsAsync();
    }

    //public class HttpClientJobAdderRestService : IJobAdderRestService
    //{
    //    private readonly IHttpClientFactory _clientFactory;

    //    public HttpClientJobAdderRestService(IHttpClientFactory clientFactory)
    //    {
    //        _clientFactory = clientFactory;
    //    }

    //    public async Task<IEnumerable<JobDto>> GetJobsAsync()
    //    {
    //        var req = new HttpRequestMessage(HttpMethod.Get, "/candidates");
    //        var client = _clientFactory.CreateClient("jobadder");

    //        var response = await client.SendAsync(req);
    //        response.EnsureSuccessStatusCode();

    //        var stream = await response.Content.ReadAsStreamAsync();
    //        return await JsonSerializer.DeserializeAsync<IEnumerable<JobDto>>(stream);
    //    }
    //}


    public class JobDto
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
    }
}
