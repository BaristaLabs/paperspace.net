namespace Paperspace.Tests.Helpers
{
    using Paperspace;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        public void Ensure_Throws_When_Argument_Null()
        {

            Ensure.ArgumentNotNull("foo", "foo");

            Assert.ThrowsException<ArgumentNullException>(() => {
                Ensure.ArgumentNotNull(null, "foo");
            });
        }

        [TestMethod]
        public void Ensure_Throws_When_Enumerable_Empty()
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(new List<string>() { "foo " }, "foo");

            Assert.ThrowsException<ArgumentNullException>(() => {
                IEnumerable<string> foo = null;
                Ensure.ArgumentNotNullOrEmptyEnumerable(foo, "foo");
            });

            Assert.ThrowsException<ArgumentException>(() => {
                Ensure.ArgumentNotNullOrEmptyEnumerable(new List<string>(), "foo");
            });
        }

        [TestMethod]
        public void Ensure_Throws_When_Empty_String()
        {
            Ensure.ArgumentNotNullOrEmptyString("foo", "foo");

            Assert.ThrowsException<ArgumentException>(() => {
                Ensure.ArgumentNotNullOrEmptyString(string.Empty, "foo");
            });

            Assert.ThrowsException<ArgumentNullException>(() => {
                Ensure.ArgumentNotNullOrEmptyString(null, "foo");
            });
        }

        [TestMethod]
        public void Ensure_Throws_When_LessThanZero()
        {
            Ensure.GreaterThanZero(TimeSpan.FromTicks(100), "foo");

            Assert.ThrowsException<ArgumentException>(() => {
                Ensure.GreaterThanZero(TimeSpan.FromTicks(-1), "foo");
            });
        }
    }
}
