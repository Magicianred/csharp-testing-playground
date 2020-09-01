using NUnit.Framework;
using System;

namespace TddUnitTests
{
    public class Tests
    {

        [TestCase(MyCalc.TypeOperation.Add, 1, 1, ExpectedResult = 2)]
        [TestCase(MyCalc.TypeOperation.Subtract, 1, 1, ExpectedResult = 0)]
        [TestCase(MyCalc.TypeOperation.Multiply, 2, 2, ExpectedResult = 4)]
        [TestCase(MyCalc.TypeOperation.Divide, 10, 2, ExpectedResult = 5)]
        public int MyCalcDoOkTest(MyCalc.TypeOperation typeOperation, int arg1, int arg2)
        {
            // arrange
            // act
            return MyCalc.Do(arg1, arg2, typeOperation);
            // assert
        }

        //[TestCase(MyCalc.TypeOperation.Add, int.MaxValue, int.MaxValue)]
        //[TestCase(MyCalc.TypeOperation.Subtract, int.MaxValue, int.MaxValue)]
        //[TestCase(MyCalc.TypeOperation.Multiply, int.MaxValue, int.MaxValue)]
        //[TestCase(MyCalc.TypeOperation.Divide, int.MaxValue, int.MaxValue)]
        //public void MyCalcDoExceptionsTest(MyCalc.TypeOperation typeOperation, int arg1, int arg2)
        //{
        //    // arrange
        //    // act
        //    // assert
        //    Assert.Throws<Exception>(() => MyCalc.Do(arg1, arg2, typeOperation));
        //}

        [TestCase(MyCalc.TypeOperation.Divide, 10, 0)]
        public void MyCalcDoExceptionsTest(MyCalc.TypeOperation typeOperation, int arg1, int arg2)
        {
            // arrange
            // act
            // assert
            Assert.Throws<DivideByZeroException>(() => MyCalc.Do(arg1, arg2, typeOperation));
        }

        [TestCase(MyCalc.TypeOperation.Divide, 10, 0, typeof(DivideByZeroException))]
        public void MyCalcDoExceptionsTest(MyCalc.TypeOperation typeOperation, int arg1, int arg2, Type exceptionType)
        {
            // arrange
            // act
            // assert
            Assert.Throws(exceptionType, () => MyCalc.Do(arg1, arg2, typeOperation));
        }
    }

    public static class MyCalc
    {
        public enum TypeOperation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
        public static int Do(int num1, int num2, TypeOperation typeOperation)
        {
            int ret = 0;
            switch (typeOperation)
            {
                case TypeOperation.Add:
                    ret = num1 + num2;
                    break;
                case TypeOperation.Subtract:
                    ret = num1 - num2;
                    break;
                case TypeOperation.Multiply:
                    ret = num1 * num2;
                    break;
                case TypeOperation.Divide:
                    ret = num1 / num2;
                    break;
            }

            return ret;
        }
    }
}