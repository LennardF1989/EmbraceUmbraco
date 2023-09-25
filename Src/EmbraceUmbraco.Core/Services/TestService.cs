namespace EmbraceUmbraco.Core.Services;

public interface ITestService
{
    string Test();
}

public class TestService : ITestService
{
    public string Test()
    {
        return "This is a test!";
    }
}