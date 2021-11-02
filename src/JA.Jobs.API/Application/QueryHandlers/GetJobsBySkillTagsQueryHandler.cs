using JA.Jobs.API.Application.Queries;
using JA.Jobs.API.Entities;
using JA.Jobs.API.Infrastructure.Extensions;
using JA.Jobs.API.Services;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JA.Jobs.API.Application.QueryHandlers
{
    public class GetJobsBySkillTagsQueryHandler : IRequestHandler<GetJobsBySkillTagsQuery, IEnumerable<MatchingJob>>
    {
        private readonly IMediator _mediator;
        private readonly ISkillTagMatchService _skillTagMatchService;

        public GetJobsBySkillTagsQueryHandler(ISkillTagMatchService skillTagMatchService, IMediator mediator)
        {
            _skillTagMatchService = skillTagMatchService;
            _mediator = mediator;
        }

        public async Task<IEnumerable<MatchingJob>> Handle(GetJobsBySkillTagsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _mediator.Send(new GetJobsQuery());
            if (jobs.IsNullOrEmpty())
            {
                return null;
            }

            var matchingJobs = new List<MatchingJob>();
            foreach (var @job in jobs)
            {
                var matchingSkillTags = _skillTagMatchService.Match(request.SkillTags, @job.SkillTags);
                if (!matchingSkillTags.IsNullOrEmpty())
                {
                    matchingJobs.Add(new MatchingJob(job, matchingSkillTags));
                }
            }

            return matchingJobs.OrderByDescending(x => x.Score);
        }
    }
}
