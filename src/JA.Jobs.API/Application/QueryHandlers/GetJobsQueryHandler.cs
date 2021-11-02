using JA.Jobs.API.Application.Queries;
using JA.Jobs.API.Entities;
using JA.Jobs.API.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JA.Jobs.API.Application.QueryHandlers
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, IEnumerable<Job>>
    {
        private readonly IJobAdderRestService _jobAdderRestService;

        public GetJobsQueryHandler(IJobAdderRestService jobAdderRestService)
        {
            _jobAdderRestService = jobAdderRestService;
        }

        public async Task<IEnumerable<Job>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            var dtos = await _jobAdderRestService.GetJobsAsync();
            var candidates = new List<Job>();
            foreach(var dto in dtos)
            {
                candidates.Add(new Job(dto));
            }

            return candidates;
        }
    }
}
