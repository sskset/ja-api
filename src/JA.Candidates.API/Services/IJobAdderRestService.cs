using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JA.Candidates.API.Services
{
    public interface IJobAdderRestService
    {
        [Get("/candidates")]
        Task<IEnumerable<CandidateDto>> GetCandidatesAsync();
    }

    //public class HttpClientJobAdderRestService : IJobAdderRestService
    //{
    //    private readonly IHttpClientFactory _clientFactory;

    //    public HttpClientJobAdderRestService(IHttpClientFactory clientFactory)
    //    {
    //        _clientFactory = clientFactory;
    //    }

    //    public async Task<IEnumerable<CandidateDto>> GetCandidatesAsync()
    //    {
    //        var req = new HttpRequestMessage(HttpMethod.Get, "/candidates");
    //        var client = _clientFactory.CreateClient("jobadder");

    //        var response = await client.SendAsync(req);
    //        response.EnsureSuccessStatusCode();

    //        var stream = await response.Content.ReadAsStreamAsync();
    //        return await JsonSerializer.DeserializeAsync<IEnumerable<CandidateDto>>(stream);
    //    }
    //}

    public class CandidateDto
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string SkillTags { get; set; }
    }
}
