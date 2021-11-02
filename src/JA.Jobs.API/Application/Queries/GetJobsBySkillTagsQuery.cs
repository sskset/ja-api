using JA.Jobs.API.Entities;
using MediatR;
using System.Collections.Generic;

namespace JA.Jobs.API.Application.Queries
{
    public class GetJobsBySkillTagsQuery : IRequest<IEnumerable<MatchingJob>>
    {
        public string[] SkillTags { get; set; }
    }
}
