using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JA.Candidates.API.Services
{
    public interface IJobAdderRestService
    {
        [Get("/candidates")]
        Task<IEnumerable<CandidateDto>> GetCandidatesAsync();
    }

    public class CandidateDto
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string SkillTags { get; set; }
    }
}
