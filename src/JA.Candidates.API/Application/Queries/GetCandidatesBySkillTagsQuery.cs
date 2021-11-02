using JA.Candidates.API.Entities;
using MediatR;
using System.Collections.Generic;

namespace JA.Candidates.API.Application.Queries
{
    public class GetCandidatesBySkillTagsQuery : IRequest<IEnumerable<MatchingCandidate>>
    {
        public string[] SkillTags { get; set; }
    }
}
