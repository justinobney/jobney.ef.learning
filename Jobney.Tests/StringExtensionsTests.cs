using Envoc.Core.UnitTests.Extensions;
using Jobney.EF.Learning.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.EF.UnitTests.StringExtensionsContainer
{
    [TestClass]
    public class StringExtensionsTests
    {
        private string target;

        [TestInitialize]
        public void Init()
        {
            
        }

        [TestMethod]
        public void StringSlugify_SlugifiesAString()
        {
            //arrange
            target = "This is not a test";

            //act
            var result = target.slugify();

            //assert
            const string expected = "this-is-not-a-test";

            result.ShouldBe(expected);
        }
    }
}