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
        public int Test1(MyCalc.TypeOperation typeOperation, int arg1, int arg2)
        {
            // arrange
            // act
            return MyCalc.Do(arg1, arg2, typeOperation);
            // assert
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
            throw new NotImplementedException();
        }
    }
}