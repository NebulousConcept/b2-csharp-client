using B2.Client.Rest;
using B2.Client.Rest.Request.Param;

using NUnit.Framework;


namespace B2.Client.Test
{
    [TestFixture]
    public class UrlSegmentTest
    {
        [Test]
        public void TestLiteralSegmentDoesNotTransform()
        {
            const string paramName = "paramName";
            const string paramValue = "paramValue";
            var param = new RestParam(paramName, paramValue);

            var segment = UrlSegment.Literal(paramName);

            Assert.That(segment.Transform(param.Yield()), Is.EqualTo(paramName));
        }

        [Test]
        public void TestParameterSegmentDoesTransform()
        {
            const string paramName = "paramName";
            const string paramValue = "paramValue";
            var param = new RestParam(paramName, paramValue);

            var segment = UrlSegment.Parameter(paramName);

            Assert.That(segment.Transform(param.Yield()), Is.EqualTo(paramValue));
        }
    }
}