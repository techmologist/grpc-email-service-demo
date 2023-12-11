using dotnet_server.Services;
using Google.Protobuf.WellKnownTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(Option => Option.EnableDetailedErrors = true);
builder.Services.Add(new ServiceDescriptor(typeof(EmailService), new EmailService(builder.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//call the email service
 var emailService= app.Services.GetService<EmailService>();
emailService?.SendEmail();
app.Run();
