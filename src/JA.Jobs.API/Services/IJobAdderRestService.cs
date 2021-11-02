using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JA.Jobs.API.Services
{
    public interface IJobAdderRestService
    {
        [Get("/jobs")]
        Task<IEnumerable<JobDto>> GetJobsAsync();
    }


    public class JobDto
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
    }
}
