
namespace MyDotnetWebApp.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
    }
}

internal class TestClassAttribute : Attribute
{
}

internal class TestMethodAttribute : Attribute
{
}