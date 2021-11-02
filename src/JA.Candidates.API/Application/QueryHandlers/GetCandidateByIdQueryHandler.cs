using JA.Candidates.API.Application.Queries;
using JA.Candidates.API.Entities;
using JA.Candidates.API.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JA.Candidates.API.Application.QueryHandlers
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
    {
        private readonly IJobAdderRestService _jobAdderRestService;

        public GetCandidateByIdQueryHandler(IJobAdderRestService jobAdderRestService)
        {
            _jobAdderRestService = jobAdderRestService;
        }

        public async Task<Candidate> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _jobAdderRestService.GetCandidatesAsync();
            var targetCandidate = candidates.FirstOrDefault(x => x.CandidateId == request.CandidateId);

            if(targetCandidate == null)
            {
                return null;
            }

            return new Candidate(targetCandidate.CandidateId, targetCandidate.Name, targetCandidate.SkillTags);
        }
    }
}
