using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using JA.Jobs.API.Infrastructure.Extensions;
using MediatR;
using JA.Jobs.API.Application.Queries;
using System.Collections.Generic;
using JA.Jobs.API.Entities;

namespace JA.Jobs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IMediator _mediator;

        public JobsController(ILogger<JobsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<Job>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var jobs = await _mediator.Send(new GetJobsQuery());

                if (jobs.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(jobs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpPost("find/by-skilltags")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<MatchingJob>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindMatchingJobsBySkillTagss(GetJobsBySkillTagsQuery query)
        {
            try
            {
                var matchingJobs = await _mediator.Send(query);
                if (matchingJobs.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(matchingJobs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ex.Message
                });
            }
        }
    }
}
