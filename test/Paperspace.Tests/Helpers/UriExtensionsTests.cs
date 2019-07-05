﻿namespace Paperspace.Tests.Helpers
{
    using Paperspace;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class UriExtensionsTests
    {
        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_contains_no_query_string_and_values_is_empty_should_return_url_without_changing_it()
        {
            Uri url = new Uri("http://www.domain.com/test");
            var values = new Dictionary<string, string>();
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test"), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_contains_hash_and_query_string_values_are_empty_should_return_url_without_changing_it()
        {
            Uri url = new Uri("http://www.domain.com/test#div");
            var values = new Dictionary<string, string>();
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test#div"), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_contains_no_query_string_should_add_values()
        {
            Uri url = new Uri("http://www.domain.com/test");
            var values = new Dictionary<string, string> { { "param1", "val1" }, { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test?param1=val1&param2=val2"), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_contains_hash_and_no_query_string_should_add_values()
        {
            Uri url = new Uri("http://www.domain.com/test#div");
            var values = new Dictionary<string, string> { { "param1", "val1" }, { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test#div?param1=val1&param2=val2"), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_contains_query_string_should_add_values_and_keep_original_query_string()
        {
            Uri url = new Uri("http://www.domain.com/test?param1=val1");
            var values = new Dictionary<string, string> { { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test?param1=val1&param2=val2"), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_is_relative_contains_no_query_string_should_add_values()
        {
            Uri url = new Uri("/test", UriKind.Relative);
            var values = new Dictionary<string, string> { { "param1", "val1" }, { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=val1&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_is_relative_and_contains_query_string_should_add_values_and_keep_original_query_string()
        {
            Uri url = new Uri("/test?param1=val1", UriKind.Relative);
            var values = new Dictionary<string, string> { { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=val1&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_dictionary_when_url_is_relative_and_contains_query_string_with_existing_value_should_add_new_values_and_update_existing_ones()
        {
            Uri url = new Uri("/test?param1=val1", UriKind.Relative);
            var values = new Dictionary<string, string> { { "param1", "new-value" }, { "param2", "val2" } };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=new-value&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_object_when_url_contains_no_query_string_should_add_values()
        {
            Uri url = new Uri("http://www.domain.com/test");
            var values = new { param1 = "val1", param2 = "val2" };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test?param1=val1&param2=val2"), result);
        }


        [TestMethod]
        public void Add_to_query_string_object_when_url_contains_query_string_should_add_values_and_keep_original_query_string()
        {
            Uri url = new Uri("http://www.domain.com/test?param1=val1");
            var values = new { param2 = "val2" };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("http://www.domain.com/test?param1=val1&param2=val2"), result);
        }

        [TestMethod]
        public void Add_to_query_string_object_when_url_is_relative_contains_no_query_string_should_add_values()
        {
            Uri url = new Uri("/test", UriKind.Relative);
            var values = new { param1 = "val1", param2 = "val2" };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=val1&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_object_when_url_is_relative_and_contains_query_string_should_add_values_and_keep_original_query_string()
        {
            Uri url = new Uri("/test?param1=val1", UriKind.Relative);
            var values = new { param2 = "val2" };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=val1&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_object_when_url_is_relative_and_contains_query_string_with_existing_value_should_add_new_values_and_update_existing_ones()
        {
            Uri url = new Uri("/test?param1=val1", UriKind.Relative);
            var values = new { param1 = "new-value", param2 = "val2" };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=new-value&param2=val2", UriKind.Relative), result);
        }

        [TestMethod]
        public void Add_to_query_string_object_when_props_are_null()
        {
            Uri url = new Uri("/test?param1=val1", UriKind.Relative);
            var values = new Foo() { Id = null };
            var result = url.ExtendQuery(values);
            Assert.AreEqual(new Uri("/test?param1=val1&Id=", UriKind.Relative), result);
        }


        public class Foo
        {
            public string Id
            {
                get;
                set;
            }
        }
    }
}
