using JA.Candidates.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace JA.Candidates.API.UnitTests.Services
{
    public class SimpleSkillTagMatchingServiceTest
    {
        [Fact]
        public void test_Null_or_Empty_argument()
        {
            var svc = new SimpleSkillTagMatchingService();

            Assert.Null(svc.Match(null, new string[] { "a" }));
            Assert.Null(svc.Match(Enumerable.Empty<string>(), new string[] { "a" }));

            Assert.Null(svc.Match(new string[] { "a" }, null));
            Assert.Null(svc.Match(new string[] { "a" }, Enumerable.Empty<string>()));
        }

        [Fact]
        public void Should_return_expected()
        {
            var svc = new SimpleSkillTagMatchingService();
            var obj1 = new string[] { "a", "b", "c" };
            var obj2 = new string[] { "b", "c", "d" };
            var results = svc.Match(obj1, obj2);

            Assert.Equal(new string[] { "b", "c" }, results.ToArray());
        }
    }
}
