using System;

using NUnit.Framework;

using B2.Client.Apis.AuthorizeAccountV1;
using B2.Client.Rest;


namespace B2.Client.Test.Apis.ErrorResponse
{
    [TestFixture]
    public class TestErrorResponse
    {

        [Test]
        [Category("integration")]
        public void TestErrorResponseFromApiCall()
        {
            var client = new UnauthenticatedB2Client(new Uri(TestEnvironment.B2ApiUrl));
            var req = new AuthorizeAccountV1Request("nonsense", "nonsense");

            var exception = Assert.ThrowsAsync<B2Exception>(
                async () => await client.PerformAuthenticationRequestAsync(new AuthorizeAccountV1Api(), req));

            var response = exception.ErrorResponse;

            Assert.That(response.StatusCode, Is.EqualTo(401U));
        }
    }
}