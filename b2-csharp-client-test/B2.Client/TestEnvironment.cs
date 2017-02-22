using System;
using NUnit.Framework;

namespace B2.Client.Test
{
    internal static class TestEnvironment
    {
        internal const string B2_API_URL = "https://api.backblazeb2.com";


        internal static string GetTestConfiguration(string key)
        {
            var ret = Environment.GetEnvironmentVariable(key);
            if (ret == null) {
                Assert.Inconclusive();
            }
            return ret;
        }

        internal static string GetTestAccountId() => GetTestConfiguration("B2_ACCOUNT_ID");

        internal static string GetTestAccountKey() => GetTestConfiguration("B2_ACCOUNT_KEY");
    }
}