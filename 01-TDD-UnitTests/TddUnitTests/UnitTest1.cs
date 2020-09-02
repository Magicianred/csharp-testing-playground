using NUnit.Framework;
using System;
using System.IO;

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

            return MyPrivateMethod(ret);
        }

        private static int MyPrivateMethod(int result)
        {
            return result;
        }

    }

    public class SecondUselessClassTests
    {
        [Test]
        public void PublicMethodTest()
        {
            //arrange
            var instance = new SecondUselessClass();
            //act
            var result = instance.PublicMethodReturnOne();
            //assert
            Assert.AreEqual(result, 1);
            Assert.True(result == 1);
            //....
        }

        [Test]
        public void ProtectedMethodReturnOneTest()
        {
            //arrange
            var instance = new SecondUselessClass();
            // protected method are not testable
            // instance.Prote ... not visible
            // but....
            // I can extend a class if not sealed....
            // and test a method created for this reason
            var instanceExtended = new SecondUselessClassExtendedForTest();
             //act
            var result = instanceExtended.ProtectedMethodReturnOneWrap();
            //assert
            Assert.True(result == 1);

            // but why?
            // 2 reasons
            // 1) reason one. My software/library/class is huge and expose for example 1 method only?
            //  - PRO: I can unit test better my library classes
            //  - CONS: I expose methods as protected, implicitly saying extend me
            // for me is NOT a good practice

            // 2) reason two. I want test a legacy class but this class is untestable 
            // (use new(), use external dependencies, use filesystem, use databases, http, server variables, http context) 
            Assert.Throws<FileNotFoundException>(() => new SecondUselessClass().GodMethodLegacySoftwareIWantToTest());
            // I can override the protected method 
            Assert.True(new SecondUselessClassExtendedForTest().GodMethodLegacySoftwareIWantToTest() ==  "Mocked content");
        }

        [Test]
        public void VoidMethodWriteConsoleTest()
        {
            Assert.DoesNotThrow(() => new SecondUselessClass().VoidMethodWriteConsole());
        }

        class SecondUselessClassExtendedForTest : SecondUselessClass 
        {
            public int ProtectedMethodReturnOneWrap()
            {
                return ProtectedMethodReturnOne();
            }

            protected override string GetContentFile()
            {
                return "Mocked content";
            }
        }
    }


    public class SecondUselessClass 
    {
        public int PublicMethodReturnOne()
        {
            return 1;
        }

        protected int ProtectedMethodReturnOne()
        {
            return 1;
        }
        public string GodMethodLegacySoftwareIWantToTest()
        {
            // imagine a huge method
            // i'd like to add a test before refactory
            // but the method is untestable
            // because at certain point the method let me say an example use...
            // Server.MapPath("repository/myfile.txt")
            // a solution in this case can be wrap the untestable code in a protected method
            var content = GetContentFile();

            return content;
        }

        protected virtual string GetContentFile()
        {
            return File.ReadAllText(@"c:\temp\mytxt.txt");
        }
        public void VoidMethodWriteConsole()
        {
            Console.WriteLine("Void method executed");
        }

        
    }
}