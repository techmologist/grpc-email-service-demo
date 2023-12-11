using Grpc.Core;
using dotnet_server;

namespace dotnet_server.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<NameList> SayHello(Name request, ServerCallContext context)
    {
        var names = new List<Name>
        {
            new() { Value = "Piyush" , Age = 25},
            new() { Value = "Kaji" , Age = 21},
            new() {Value ="Bimisha",Age=24},
            new() {Value ="Tshering",Age=24}
        };

        var response = new NameList();
        response.Names.AddRange(names); // Use AddRange here

        return Task.FromResult(response);
    }
}
