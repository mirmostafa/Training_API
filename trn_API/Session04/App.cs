using Session04.Application.Interfaces;
using Session04.Application.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04;
public class App
{
    private readonly IGreetingService _greetingService;

    public App(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void Run()
    {
        Console.WriteLine(_greetingService.GetGreeting());
    }
}
