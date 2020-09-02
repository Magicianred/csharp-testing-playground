using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTest
{
    public class SumNumbersVeryLong
    {
        [SetUp]
        public void Setup()
        {
        }

        public static IEnumerable<int> Do(Addends addends)
        {

            var result = new List<int>();
            var listA = addends.A.ToList();
            var listB = addends.B.ToList();


            var maxCount = listA.Count > listB.Count ? listA.Count : listB.Count;
            var amountCarriedOver = 0;
            

            for (int i = 0; i < maxCount; i++)
            {
                var tempSum = 0;
                if (listA.ElementAtOrDefault(i) != null && listB.ElementAtOrDefault(i) != null)
                {
                    tempSum = listA.ElementAt(i).Value + listB.ElementAt(i).Value + amountCarriedOver;
                }
                else if (listA.ElementAtOrDefault(i) != null && listB.ElementAtOrDefault(i) == null)
                {
                    tempSum = listA.ElementAt(i).Value + amountCarriedOver;

                }
                else if (listA.ElementAtOrDefault(i) == null && listB.ElementAtOrDefault(i) != null)
                {
                    tempSum = listB.ElementAt(i).Value + amountCarriedOver;
                }


                if (tempSum > 9)
                {
                    result.Add(ReturnRightDigit(tempSum));
                    amountCarriedOver = ReturnLeftDigit(tempSum);
                }
                else
                {
                    result.Add(tempSum);
                    amountCarriedOver = 0;
                }


            }
            
            if (amountCarriedOver > 0)
            {
                result.Add(amountCarriedOver);
            }
            
            return result;

        }


        private static int ReturnLeftDigit(int value)
        {
            if  (value > 99)
                throw new Exception("The value cannot be greater than 99");
            return value / 10;
        }
        private static int ReturnRightDigit(int value)
        {
            if (value > 99)
                throw new Exception("The value cannot be greater than 99");
            return value % 10;
        }

        //[TestCase(ExpectedResult = 1111111110)]
        [Test]
        [TestCaseSource("source1")]
        [TestCaseSource("source2")]
        public void SumNumbersVeryLong1(Addends addends)
        {
            var res = Do(addends);

            Assert.IsNotNull(res);
            Assert.AreEqual(addends.ExpectedResult, res);


        }

        private static readonly object[] source1 =
        {

            new object[] {new Addends()
            {
                A = new List<int?>()
                {
                    5,
                    6,
                    7,
                    8,
                    9,
                    4
                },
                B = new List<int?>()
                {
                    2,
                    4,
                    9,
                    6

                },
                ExpectedResult = new List<int?>()
                {
                    7,
                    0,
                    7,
                    5,
                    0,
                    5
                }
            }}

        };

        private static readonly object[] source2 =
        {
            new object[] {new Addends()
            {
                A = new List<int?>()
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9
                },
                B = new List<int?>()
                {
                    9,
                    8,
                    7,
                    6,
                    5,
                    4,
                    3,
                    2,
                    1
                },
                ExpectedResult = new List<int?>()
                {
                    0,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1
                }
            }}
        };

    }
}


public class Addends
{
    public IEnumerable<int?> A { get; set; }
    public IEnumerable<int?> B { get; set; }
    public IEnumerable<int?> ExpectedResult { get; set; }
}