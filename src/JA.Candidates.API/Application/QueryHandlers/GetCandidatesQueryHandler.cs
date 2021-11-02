using JA.Candidates.API.Application.Queries;
using JA.Candidates.API.Entities;
using JA.Candidates.API.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JA.Candidates.API.Application.QueryHandlers
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, IEnumerable<Candidate>>
    {
        private readonly IJobAdderRestService  _jobAdderRestService;
        private readonly ILogger<GetCandidatesQueryHandler> _logger;
        private readonly AsyncRetryPolicy _retryPolicy;

        public GetCandidatesQueryHandler(IJobAdderRestService jobAdderRestService, ILogger<GetCandidatesQueryHandler> logger)
        {
            _jobAdderRestService = jobAdderRestService ?? throw new ArgumentNullException(nameof(jobAdderRestService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // TODO: Handle certain Exception(s)
            _retryPolicy = Policy.Handle<Exception>(ex =>
            {
                _logger.LogError($"Exception: from - {nameof(GetCandidatesQueryHandler)} with message - {ex.Message}");
                return true;
            }).WaitAndRetryAsync(5, x => TimeSpan.FromSeconds(1));
        }

        public async Task<IEnumerable<Candidate>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidateDtos = await _retryPolicy.ExecuteAsync(async () =>
            {
                return await _jobAdderRestService.GetCandidatesAsync();
            });

            var candidates = new List<Candidate>();
            foreach(var candidateDto in candidateDtos)
            {
                var candidate = new Candidate(candidateDto.CandidateId, candidateDto.Name, candidateDto.SkillTags);
                candidates.Add(candidate);
            }

            return candidates;
        }
    }
}
