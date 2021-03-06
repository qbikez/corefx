// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Xunit;

namespace System.Tests
{
    public class IsDBNullTests
    {
        [Fact]
        public static void ChangeTypeTest()
        {
            var testValue = 0;
            bool expectedValue = false;
            Assert.Equal(expectedValue, Convert.ChangeType(testValue, TypeCode.Boolean));
        }

        [Fact]
        public static void ToBase64CharArrayTest()
        {
            byte[] barray = new byte[256];
            char[] carray = new char[352];
            int length = Convert.ToBase64CharArray(barray, 0, barray.Length, carray, 0, Base64FormattingOptions.InsertLineBreaks);
            int length2 = Convert.ToBase64CharArray(barray, 0, barray.Length, carray, 0, Base64FormattingOptions.None);
            Assert.Equal(length, 352);
            Assert.Equal(length, 352);
        }

        [Fact]
        public static void ToBase64StringTest()
        {
            byte[] barray = new byte[] { 1, 2, 3 };
            byte[] subset = new byte[] { 2, 3 };
            string s1 = Convert.ToBase64String(barray, Base64FormattingOptions.InsertLineBreaks);
            string s2 = Convert.ToBase64String(barray, Base64FormattingOptions.None);
            string s3 = Convert.ToBase64String(barray, 1, 2, Base64FormattingOptions.None);
            Assert.Equal(barray, Convert.FromBase64String(s1), "s1");
            Assert.True(!s2.Contains("\n"));
            Assert.Equal(barray, Convert.FromBase64String(s2), "s2");
            Assert.Equal(subset, Convert.FromBase64String(s3), "s3");
        }

        [Fact]
        public void ToBooleanTests()
        {
            char testValue = char.MinValue;
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(testValue), "char");
            DateTime testValue2 = DateTime.MinValue;
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(testValue2), "DateTime");
        }

        [Fact]
        public void ToByteTest()
        {
            DateTime testValue = DateTime.MaxValue;
            Assert.Throws<InvalidCastException>(() => Convert.ToByte(testValue), "DateTime");
        }

        [Fact]
        public void ToCharTests()
        {
            char testValue = char.MinValue;
            Assert.Equal(testValue, Convert.ToChar(testValue), "char");
            DateTime testValue2 = DateTime.MinValue;
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(testValue2), "DateTime");
        }

        [Fact]
        public void ToDateTimeTests()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(byte.MinValue), "byte");
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(sbyte.MinValue), "sbyte");
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(float.MinValue), "float");
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(ushort.MinValue), "ushort");
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(uint.MinValue), "uint");
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(ulong.MinValue), "ulong");
        }

        [Fact]
        public void ToDecimalTests()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToDecimal(char.MinValue), "char");
            Assert.Throws<InvalidCastException>(() => Convert.ToDecimal(DateTime.MinValue), "Datetime");
        }

        [Fact]
        public void ToDoubleTests()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToDouble(char.MinValue), "char");
            Assert.Throws<InvalidCastException>(() => Convert.ToDouble(DateTime.MinValue), "Datetime");
        }

        [Fact]
        public void ToInt16Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt16(DateTime.MaxValue), "Datetime");
        }

        [Fact]
        public void ToInt32Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(DateTime.MaxValue), "Datetime");
        }

        [Fact]
        public void ToInt64Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt64(DateTime.MaxValue), "Datetime");
        }

        [Fact]
        public static void IsDBNullTest()
        {
            Assert.True(Convert.IsDBNull(Convert.DBNull));
            Assert.False(Convert.IsDBNull(4));
            Assert.False(Convert.IsDBNull(true));
            Assert.False(Convert.IsDBNull('x'));
            Assert.False(Convert.IsDBNull(1.1));
            Assert.False(Convert.IsDBNull(null));
        }

        [Fact]
        public void ToSByteTest()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToSByte(DateTime.MaxValue), "DateTime");
        }

        [Fact]
        public void ToSingleTests()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToSingle(DateTime.MaxValue), "DateTime");
            Assert.Throws<InvalidCastException>(() => Convert.ToSingle(char.MinValue), "char");
        }

        [Fact]
        public static void ToStringTests()
        {
            string testValue = "Hello World!";
            Assert.Equal(testValue, Convert.ToString(testValue), "t1");
            Assert.Equal(testValue, Convert.ToString(testValue, NumberFormatInfo.CurrentInfo), "t2");
        }

        [Fact]
        public void ToUInt16Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToUInt16(DateTime.MaxValue), "Datetime");
        }

        [Fact]
        public void ToUInt32Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToUInt32(DateTime.MaxValue), "Datetime");
        }

        [Fact]
        public void ToUInt64Test()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToUInt64(DateTime.MaxValue), "DateTime");
        }
    }
}
