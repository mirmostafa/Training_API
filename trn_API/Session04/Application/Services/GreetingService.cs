using Session04.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04.Application.Services;
internal class GreetingService : IGreetingService
{
    public string GetGreeting()
    {
        return "Hello, Dependency Injection!";
    }
}
