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
        [Category(TestCategories.Authentication)]
        public async Task TestAuthorizeAccountSuccess()
        {
            var client = new UnauthenticatedB2Client(new Uri(TestEnvironment.B2ApiUrl));
            var req = new AuthorizeAccountV1Request(TestEnvironment.GetTestAccountId(), TestEnvironment.GetTestAccountKey());
            var result = await client.PerformAuthenticationRequestAsync(B2Apis.AuthorizeAccountV1, req);

            Assert.That(result.AccountId, Is.EqualTo(TestEnvironment.GetTestAccountId()));
            Assert.That(result.AuthorizationToken, Is.Not.Null);
            Assert.That(result.DownloadUrl, Is.Not.Null);
        }
    }
}