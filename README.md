# Backblaze B2 CoreCLR client library

This is a `netstandard1.6` compatible client library written in C# 6.0 for use
with the [Backblaze B2 cloud storage
service](https://www.backblaze.com/b2/cloud-storage.html). This is currently a
work in progress with additional functionality being added over time.

Sample code:
```C#
var accountId = "my_account_id";
var applicationKey = "my_app_key";
var client = new UnauthenticatedB2Client(new Uri("https://api.backblazeb2.com"));
var authedClient = client.AuthenticateWithResponse(
    await client.PerformAuthenticationRequestAsync(B2Apis.AuthorizeAccountV1,
        new AuthorizeAccountV1Request(accountId, applicationKey)));

var result = await authedClient.PerformApiRequestAsync(B2Apis.ListBucketsV1,
    new ListBucketsV1Request(accountId));
foreach (var bucket in result.Buckets) {
    Console.WriteLine(bucket.BucketName);
}
```
