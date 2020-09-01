# How to


- dotnet new

```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate> dotnet new
Getting ready...
Usage: new [options]

Options:
  -h, --help          Displays help for this command.
  -l, --list          Lists templates containing the specified name. If no name is specified, lists all templates.
  -n, --name          The name for the output being created. If no name is specified, the name of the current directory is used.
  -o, --output        Location to place the generated output.
  -i, --install       Installs a source or a template pack.
  -u, --uninstall     Uninstalls a source or a template pack.
  --nuget-source      Specifies a NuGet source to use during install.
  --type              Filters templates based on available types. Predefined values are "project", "item" or "other".
  --dry-run           Displays a summary of what would happen if the given command line were run if it would result in a template creation.
  --force             Forces content to be generated even if it would change existing files.
  -lang, --language   Filters templates based on language and specifies the language of the template to create.
  --update-check      Check the currently installed template packs for updates.
  --update-apply      Check the currently installed template packs for update, and install the updates.


Templates                                         Short Name               Language          Tags
----------------------------------------------------------------------------------------------------------------------------------
Console Application                               console                  [C#], F#, VB      Common/Console
Class library                                     classlib                 [C#], F#, VB      Common/Library
WPF Application                                   wpf                      [C#]              Common/WPF
WPF Class library                                 wpflib                   [C#]              Common/WPF
WPF Custom Control Library                        wpfcustomcontrollib      [C#]              Common/WPF
WPF User Control Library                          wpfusercontrollib        [C#]              Common/WPF
Windows Forms (WinForms) Application              winforms                 [C#]              Common/WinForms
Windows Forms (WinForms) Class library            winformslib              [C#]              Common/WinForms
Worker Service                                    worker                   [C#]              Common/Worker/Web
Unit Test Project                                 mstest                   [C#], F#, VB      Test/MSTest
NUnit 3 Test Project                              nunit                    [C#], F#, VB      Test/NUnit
NUnit 3 Test Item                                 nunit-test               [C#], F#, VB      Test/NUnit
xUnit Test Project                                xunit                    [C#], F#, VB      Test/xUnit
Razor Component                                   razorcomponent           [C#]              Web/ASP.NET
Razor Page                                        page                     [C#]              Web/ASP.NET
MVC ViewImports                                   viewimports              [C#]              Web/ASP.NET
MVC ViewStart                                     viewstart                [C#]              Web/ASP.NET
Blazor Server App                                 blazorserver             [C#]              Web/Blazor
Blazor WebAssembly App                            blazorwasm               [C#]              Web/Blazor/WebAssembly
ASP.NET Core Empty                                web                      [C#], F#          Web/Empty
ASP.NET Core Web App (Model-View-Controller)      mvc                      [C#], F#          Web/MVC
ASP.NET Core Web App                              webapp                   [C#]              Web/MVC/Razor Pages
ASP.NET Core with Angular                         angular                  [C#]              Web/MVC/SPA
ASP.NET Core with React.js                        react                    [C#]              Web/MVC/SPA
ASP.NET Core with React.js and Redux              reactredux               [C#]              Web/MVC/SPA
Razor Class Library                               razorclasslib            [C#]              Web/Razor/Library/Razor Class Library
ASP.NET Core Web API                              webapi                   [C#], F#          Web/WebAPI
ASP.NET Core gRPC Service                         grpc                     [C#]              Web/gRPC
dotnet gitignore file                             gitignore                                  Config
global.json file                                  globaljson                                 Config
NuGet Config                                      nugetconfig                                Config
Dotnet local tool manifest file                   tool-manifest                              Config
Web Config                                        webconfig                                  Config
Solution File                                     sln                                        Solution
Protocol Buffer File                              proto                                      Web/gRPC

Examples:
    dotnet new mvc --auth Individual
    dotnet new webapi
    dotnet new --help
```


- dotnet new nunit -n ProjectTest

```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate> dotnet new nunit -n ProjectTest
The template "NUnit 3 Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on ProjectTest\ProjectTest.csproj...
  Determining projects to restore...
  Restored C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj (in 1,25 sec).

Restore succeeded.
```

 - cd TestProject
 - dotnet test

```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet test                                                                                             Test run for C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\bin\Debug\netcoreapp3.1\ProjectTest.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 1,3589 Seconds
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> 

```

 - dotnet watch test
 - edit UnitTest.cs

```csharp
using NUnit.Framework;

namespace ProjectTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

```

```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet watch test                                                                                       watch : Started
Test run for C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\bin\Debug\netcoreapp3.1\ProjectTest.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 1,3209 Seconds
watch : Exited
watch : Waiting for a file to change before restarting dotnet...
watch : Started
Test run for C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\bin\Debug\netcoreapp3.1\ProjectTest.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
  X Test1 [58ms]
  Stack Trace:
     at ProjectTest.Tests.Test1() in C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\UnitTest1.cs:line 15


Test Run Failed.
Total tests: 1
     Failed: 1
 Total time: 1,5591 Seconds
C:\Program Files\dotnet\sdk\3.1.401\Microsoft.TestPlatform.targets(32,5): error MSB4181: The "Microsoft.TestPlatform.Build.Tasks.VSTestTask" task returned false but did not log an error. [C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj]
watch : Exited with error code 1
watch : Waiting for a file to change before restarting dotnet...
```

 - the csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="nunit" Version="3.12.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.15.1" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.4.0"/>
  </ItemGroup>

</Project>
```

 - update nuget libraries
 - dotnet list package --outdated 
```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet list package --outdated                                                                          
The following sources were used:
   https://api.nuget.org/v3/index.json
   C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\

Project `ProjectTest` has the following updates to its packages
   [netcoreapp3.1]:
   Top-level Package             Requested   Resolved   Latest
   > Microsoft.NET.Test.Sdk      16.4.0      16.4.0     16.7.1
   > NUnit3TestAdapter           3.15.1      3.15.1     3.17.0

PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet tool install --global dotnet-outdated                                                            You can invoke the tool using the following command: dotnet-outdated
Tool 'dotnet-outdated' (version '2.11.0') was successfully installed.
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet outdated                                                                                         » ProjectTest
  [.NETCoreApp,Version=v3.1]
  Microsoft.NET.Test.Sdk  16.4.0 -> 16.7.1
  NUnit3TestAdapter       3.15.1 -> 3.17.0

```

 - update nuget packages

```cmd
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet add package Microsoft.NET.Test.Sdk                                                                 Determining projects to restore...
  Writing C:\Users\massimiliano.balestr\AppData\Local\Temp\tmpD1B6.tmp
info : Adding PackageReference for package 'Microsoft.NET.Test.Sdk' into project 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : Restoring packages for C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.net.test.sdk/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.net.test.sdk/index.json 406ms
info : Package 'Microsoft.NET.Test.Sdk' is compatible with all the specified frameworks in project 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : PackageReference for package 'Microsoft.NET.Test.Sdk' version '16.7.1' updated in file 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : Committing restore...
info : Generating MSBuild file C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\obj\ProjectTest.csproj.nuget.g.props.
info : Generating MSBuild file C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\obj\ProjectTest.csproj.nuget.g.targets.
info : Writing assets file to disk. Path: C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\obj\project.assets.json
log  : Restored C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj (in 1,1 sec).
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet add package NUnit3TestAdapter                                                                      Determining projects to restore...
  Writing C:\Users\massimiliano.balestr\AppData\Local\Temp\tmpE04.tmp
info : Adding PackageReference for package 'NUnit3TestAdapter' into project 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : Restoring packages for C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/nunit3testadapter/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/nunit3testadapter/index.json 357ms
info : Package 'NUnit3TestAdapter' is compatible with all the specified frameworks in project 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : PackageReference for package 'NUnit3TestAdapter' version '3.17.0' updated in file 'C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj'.
info : Committing restore...
info : Generating MSBuild file C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\obj\ProjectTest.csproj.nuget.g.props.
info : Writing assets file to disk. Path: C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\obj\project.assets.json
log  : Restored C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest\ProjectTest.csproj (in 926 ms).
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest> dotnet list package --outdated                                                                          
The following sources were used:
   https://api.nuget.org/v3/index.json
   C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\

The given project `ProjectTest` has no updates given the current sources.
PS C:\Github\csharp-testing-playground\00-TestProjectBoilerplate\ProjectTest>    
```