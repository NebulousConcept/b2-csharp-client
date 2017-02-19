using NUnit.Framework;


namespace B2.Client.Test
{
    [TestFixture]
    public class ValidationUtilsTest
    {
        [Test]
        public void TestThrowIfNullThrowsOnNull()
        {
            const string testValue = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.That(() => testValue.ThrowIfNull(nameof(testValue)), Throws.ArgumentNullException);
        }

        [Test]
        public void TestThrowIfNullAcceptsNonNull()
        {
            const string testValue = "not null";
            Assert.That(testValue.ThrowIfNull(nameof(testValue)), Is.EqualTo(testValue));
        }
    }
}