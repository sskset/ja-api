using JA.Candidates.API.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JA.Candidates.API.UnitTests.Infrastructure.Extensions
{
    public class ExtensionsTest
    {
        [Fact]
        public void test_Null_Object()
        {
            IEnumerable<object> testObj = null;

            Assert.True(testObj.IsNullOrEmpty());
            Assert.False(testObj.IsNotNullOrEmpty());
        }

        [Fact]
        public void test_Empty_Object()
        {
            var testObj = Enumerable.Empty<int>();

            Assert.True(testObj.IsNullOrEmpty());
            Assert.False(testObj.IsNotNullOrEmpty());
        }

        [Fact]
        public void Give_valid_object_Should_return_expected()
        {
            var testObj = Enumerable.Range(0, 10);
            Assert.True(testObj.IsNotNullOrEmpty());
            Assert.False(testObj.IsNullOrEmpty());
        }
    }
}
