using JA.Candidates.API.Entities;
using MediatR;
using System.Collections.Generic;

namespace JA.Candidates.API.Application.Queries
{
    public class GetCandidatesQuery : IRequest<IEnumerable<Candidate>>
    {
    }
}
