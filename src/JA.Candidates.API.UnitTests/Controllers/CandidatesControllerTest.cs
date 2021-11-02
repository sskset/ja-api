using JA.Candidates.API.Application.Queries;
using JA.Candidates.API.Controllers;
using JA.Candidates.API.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JA.Candidates.API.UnitTests.Controllers
{
    public class CandidatesControllerTest
    {
        [Fact]
        public void Should_handle_dependency_injections_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CandidatesController(null, null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var loggerMock = new Mock<ILogger<CandidatesController>>();
                new CandidatesController(loggerMock.Object, null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var mediatorMock = new Mock<IMediator>();
                new CandidatesController(null, mediatorMock.Object);
            });
        }

        [Fact]
        public async Task Given_No_Candidates_Found_WhenCall_GetCandidates_Should_Return_No_Content()
        {
            var loggerMock = new Mock<ILogger<CandidatesController>>();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null);

            var controller = new CandidatesController(loggerMock.Object, mediatorMock.Object);
            var response = await controller.GetCandidates();
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Given_Candidates_Found_WhenCall_GetCandidates_Should_Return_Ok()
        {
            var expectedCandidates = new List<Candidate>();
            for(int i = 0; i < 100; i++)
            {
                expectedCandidates.Add(new Candidate
                {
                    Id = i,
                    Name = $"Some randome name {i}" // this can be replaced with a randome name generator tool
                });
            }

            var loggerMock = new Mock<ILogger<CandidatesController>>();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetCandidatesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedCandidates);

            var controller = new CandidatesController(loggerMock.Object, mediatorMock.Object);
            var response = await controller.GetCandidates();
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(expectedCandidates, (response as OkObjectResult).Value as List<Candidate>);
        }

        // TODO: MORE UNIT TESTS
    }
}
