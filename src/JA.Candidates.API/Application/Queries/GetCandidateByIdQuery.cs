using JA.Candidates.API.Entities;
using MediatR;

namespace JA.Candidates.API.Application.Queries
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int CandidateId { get; set; }
    }
}
