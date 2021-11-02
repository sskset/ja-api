using JA.Candidates.API.Entities;
using Xunit;

namespace JA.Candidates.API.UnitTests.Entities
{
    public class CandidateTest
    {
        [Fact]
        public void Should_have_default_constructor()
        {
            // in order to deserialize
            Assert.NotNull(new Candidate());
        }

        [Fact]
        public void Should_have_expected_values_assigned()
        {

            var expectedId = 10;
            var expectedName = "James";
            var expectedSkillTagss = "c#, sql server, mysql, nhibernate";
            var c = new Candidate(expectedId, expectedName, expectedSkillTagss);
            Assert.Equal(expectedId, c.Id);
            Assert.Equal(expectedName, c.Name);
            Assert.Equal(expectedSkillTagss, string.Join(", ", c.SkillTags));
        }
    }
}
