using JA.Candidates.API.Application.Queries;
using JA.Candidates.API.Entities;
using JA.Candidates.API.Infrastructure.Extensions;
using JA.Candidates.API.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JA.Candidates.API.Application.QueryHandlers
{
    public class GetCandidatesBySkillTagsQueryHandler : IRequestHandler<GetCandidatesBySkillTagsQuery, IEnumerable<MatchingCandidate>>
    {
        private readonly ILogger<GetCandidatesBySkillTagsQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly ISkillTagMatchService _skillTagMatchService;

        public GetCandidatesBySkillTagsQueryHandler(ILogger<GetCandidatesBySkillTagsQueryHandler> logger, IMediator mediator, ISkillTagMatchService skillTagMatchService)
        {
            _logger = logger;
            _mediator = mediator;
            _skillTagMatchService = skillTagMatchService;
        }

        public async Task<IEnumerable<MatchingCandidate>> Handle(GetCandidatesBySkillTagsQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            if (candidates.IsNullOrEmpty())
            {
                return null;
            }

            var matchingCandidates = new List<MatchingCandidate>();
            foreach (var @candidate in candidates)
            {
                var matchingSkillTags = _skillTagMatchService.Match(request.SkillTags, @candidate.SkillTags);
                if (!matchingSkillTags.IsNullOrEmpty())
                {
                    matchingCandidates.Add(new MatchingCandidate(candidate, matchingSkillTags));
                }
            }

            return matchingCandidates.OrderByDescending(x => x.Scores);
        }
    }
}
