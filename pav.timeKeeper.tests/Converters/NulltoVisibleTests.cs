using Microsoft.VisualStudio.TestTools.UnitTesting;
using pav.timeKeeper.mobile.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace pav.timeKeeper.tests.Converters
{
    
    [TestClass]
    public class NulltoVisibleTests
    {
        [TestMethod]
        public void Test_nullable_datetime()
        {
            var converter = new NullToVisibilityConverter();

            Nullable<DateTime> dt = DateTime.Now;

            object result = converter.Convert(dt, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);

            dt = null;
            result = converter.Convert(dt, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Test_String_NotNullNotEmpty()
        {
            var converter = new NullToVisibilityConverter();
            string value = "some text";
            object result = converter.Convert(value, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Test_String_Null()
        {
            var converter = new NullToVisibilityConverter();
            string value = null;
            var result = converter.Convert(value, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Test_String_Empty()
        {
            var converter = new NullToVisibilityConverter();
            string value = String.Empty;
            var result = converter.Convert(value, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

     
    }
}
