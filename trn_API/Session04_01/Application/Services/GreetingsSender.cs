using Session04_01.Application.Interface;

namespace Session04_01.Application.Services;

public class GreetingsSender : IGreetingsSender
{
    public string SayHello()
    {
        return "Hello";
    }
}
