# Cosa ho imparato
 
 - Unit tests + TDD:
   - ho scritto il readme, e il metodo statico da testare
   - ho scritto un test che fallisce (perchè il metodo throw new NotImpementedException)
   - in TDD prima si scrive l'interfaccia (la firma della funzione) e non si scrive implementazione (buona pratica throw NotImplementedException)
   - si scrive il test e deve fallire, poi si implementa il codice
   - il test tramite l'attributo [TestCase] "prevede" che
     - 1+1 dovrà fare 2
     - 1-1 dovrà fare 0
​     - 2 per 2 4
     - 10 / 2 farà 5
 - NUnit TestCase/Test Attributes
​   - TestCase(args...., ExpectedResult=) usando ExpectedResult il metodo/funzione deve tornare e non essere void
 - Concetto di funzione pura
   - come primo esempio ho scelto una funzione statica perchè essendo statica dovrebbe essere pura (senza dipendenze, senza stato - le classi possono avere uno stato)
   - le funzioni pure sono per definizione testabili. A daterminati input avrò sempre lo stesso risultato.
     - Lo stesso metodo inserito in una classe potrebbe avere dei valori di istanza che ne mutano il risultano
 - Testare le eccezioni
 - Visiblità e testing
   - private: non si testa!
   - protected: si può testare estendendo nel progetto di tests
     - può essere accettabile. non sono un fan
     - quick & dirty solution per moccare una parte di codice altrimenti intestabile (sto rifattorizzando legacy code)
 - Testare void

# TODO

 - Internal 
 - Testare async
 - Testare exceptions async
 - NUnit Api TODO 
   - qualche esempio sulla api di asserzioni in NUnit
   - attributi/lifecycle hooks
   - TestData?
 - XUnit ... altri esempi
 - FluentAssertion

# How to

- dotnet new nunit -n TddUnitTests
```cmd
PS C:\Github\csharp-testing-playground\01-TDD-UnitTests> dotnet new nunit -n TddUnitTests
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on TddUnitTests\TddUnitTests.csproj...
  Determining projects to restore...
  Restored C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\TddUnitTests.csproj (in 2,03 sec).

Restore succeeded.
```

 - create a static class MyCalc
 - create a static method
   - static int Do(int num1, int num2, TypeOperation typeOperation)
 - create a enum TypeOperation with the following values Add, Subtract, Multiply, Divide
 - the method Do at the moment throws new NotImplementedException

```csharp
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
```

 - TDD is the technique where the test is written before the implementation (Test driven development)
 - I know that my program will resolve basic math operation, so write tests before


```csharp
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
```
 - I used TestCase Attribute instead of Test
 - I used ExpectedResult named parameter to assert the final result
 - I write in the test 3 comments. The 3 phases of tests.
   - Arrange the test (in this case nothing - no new() no setup something...)
   - Act is the phase where I invoke the public function to be tested
   - Assert is the region where I can assert something (in this case, because my test is trivial I return the result)
 - I tested one "operation" per type using simple arguments
 - I know that tests will fail and is important to ensure the first invokation will fail
 - In TDD I have to implement the method AFTER I implemented the test scenario

```cmd
PS C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests> dotnet test                                       Test run for C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\bin\Debug\netcoreapp3.1\TddUnitTests.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
  X Test1(Add,1,1) [32ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at TddUnitTests.MyCalc.Do(Int32 num1, Int32 num2, TypeOperation typeOperation) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 33
   at TddUnitTests.Tests.Test1(TypeOperation typeOperation, Int32 arg1, Int32 arg2) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 17
  X Test1(Subtract,1,1) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at TddUnitTests.MyCalc.Do(Int32 num1, Int32 num2, TypeOperation typeOperation) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 33
   at TddUnitTests.Tests.Test1(TypeOperation typeOperation, Int32 arg1, Int32 arg2) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 17
  X Test1(Multiply,2,2) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at TddUnitTests.MyCalc.Do(Int32 num1, Int32 num2, TypeOperation typeOperation) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 33
   at TddUnitTests.Tests.Test1(TypeOperation typeOperation, Int32 arg1, Int32 arg2) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 17
  X Test1(Divide,10,2) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at TddUnitTests.MyCalc.Do(Int32 num1, Int32 num2, TypeOperation typeOperation) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 33
   at TddUnitTests.Tests.Test1(TypeOperation typeOperation, Int32 arg1, Int32 arg2) in C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\UnitTest1.cs:line 17

Test Run Failed.
Total tests: 4
     Failed: 4
 Total time: 1,1993 Seconds
C:\Program Files\dotnet\sdk\3.1.401\Microsoft.TestPlatform.targets(32,5): error MSB4181: The "Microsoft.TestPlatform.Build.Tasks.VSTestTask" task returned false but did not log an error. [C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests\TddUnitTests.csproj]
PS C:\Github\csharp-testing-playground\01-TDD-UnitTests\TddUnitTests>
```

## Test Exceptions

```csharp
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
```

 - il primo esempio usa Assert.Throws<T>(delegateCode) dove T (generics) sarà l'ExceptionType che ci si aspetta
 - il secondo esempio usa Assert.Throws(Type, delegateCode) dove Type sarà il typeof(ExceptionType)
 - il secondo esempio è dinamico e posso passare il Type via TestCase[params]


## Unit tests - Private methods

```csharp 
private static int MyPrivateMethod(int result)
{
    return result;
}
```

 - il metodo privato di una classe non è testabile e non si testa.
 - non si usa la reflection per testare un metodo privato
 - non si aumenta la superficie esposta da un software solamente per scopi di test