using System;
using Model.Extensions;
using NUnit.Framework;

namespace Model.Test.Extensions.Test
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [TestCase(2020, 1, 2, ExpectedResult = 1)]
        [TestCase(2020, 1, 8, ExpectedResult = 2)]
        [TestCase(2020, 12, 22, ExpectedResult = 52)]
        public int GetWeekOfYear_ShouldReturnCorrectWeekOfYear(int year, int month, int day)
        {
            return new DateTime(year, month, day).GetWeekOfYear();
        }
    }
}
