﻿using System;
using System.Threading.Tasks;
using B2.Client.Apis.AuthorizeAccountV1;
using B2.Client.Apis.ListBucketsV1;
using B2.Client.Rest;
using NUnit.Framework;


namespace B2.Client.Test.Apis.ListBucketsV1
{
    [TestFixture]
    public class TestListBucketsV1
    {
        [Test]
        public async Task TestListBucketsV1Success()
        {
            var client = new UnauthenticatedB2Client(new Uri(TestEnvironment.B2ApiUrl));
            var req = new AuthorizeAccountV1Request(TestEnvironment.GetTestAccountId(), TestEnvironment.GetTestAccountKey());
            var authedClient = client.AuthenticateWithResponse(
                await client.PerformAuthenticationRequestAsync(new AuthorizeAccountV1Api(), req));

            var result = await authedClient.PerformApiRequestAsync(new ListBucketsV1Api(),
                new ListBucketsV1Request(TestEnvironment.GetTestAccountId()));
            Assert.That(result.Buckets, Is.Not.Null);
        }

    }
}