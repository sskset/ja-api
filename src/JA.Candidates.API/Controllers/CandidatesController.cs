using JA.Candidates.API.Application.Queries;
using JA.Candidates.API.Entities;
using JA.Candidates.API.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JA.Candidates.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ILogger<CandidatesController> _logger;
        private readonly IMediator _mediator;

        public CandidatesController(ILogger<CandidatesController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEquatable<Candidate>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var candidates = await _mediator.Send(new GetCandidatesQuery());
                if (candidates.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpGet("{candidateId}")]
        [ProducesResponseType(typeof(Candidate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCandidateById([FromRoute]GetCandidateByIdQuery query)
        {
            try
            {
                var candidate = await _mediator.Send(query);
                if (candidate == null)
                {
                    return NoContent();
                }
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }

        }

        [HttpPost("find/by-skilltags")]
        [ProducesResponseType(typeof(IEnumerable<MatchingCandidate>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatchingCandidatesBySkillTags(GetCandidatesBySkillTagsQuery query)
        {
            try
            {
                var matchingCandidates = await _mediator.Send(query);
                if (matchingCandidates.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(matchingCandidates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
