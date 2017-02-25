using System;
using System.Threading.Tasks;

using NUnit.Framework;

using B2.Client.Rest;
using B2.Client.Test;


namespace B2.Client.Apis.AuthorizeAccountV1.Test
{
    [TestFixture]
    public class TestAuthorizeAccountV1
    {
        [Test]
        public async Task TestAuthorizeAccountSuccess()
        {
            var client = new UnauthenticatedB2Client(new Uri(TestEnvironment.B2ApiUrl));
            var req = new AuthorizeAccountV1Request(TestEnvironment.GetTestAccountId(), TestEnvironment.GetTestAccountKey());
            var result = await client.PerformAuthenticationRequestAsync(new AuthorizeAccountV1Api(), req);

            Assert.That(result.AccountId, Is.EqualTo(TestEnvironment.GetTestAccountId()));
            Assert.That(result.AuthorizationToken, Is.Not.Null);
            Assert.That(result.DownloadUrl, Is.Not.Null);
        }
    }
}