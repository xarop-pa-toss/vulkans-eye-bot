// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetCord;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using NetCord.Rest;

var builder = Host.CreateApplicationBuilder(args);

builder.Environment.EnvironmentName = "Development";

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);

var token = builder.Configuration["Discord:Token"];

builder.Services
    .AddDiscordGateway(options =>
    {
        options.Token = token;
    })
    .AddApplicationCommands();

var host = builder.Build();

host.AddSlashCommand("ping", "Ping!", () => "Pong!");
host.AddUserCommand("Username", (User user) => user.Username);
host.AddMessageCommand("Length", (RestMessage message) => message.Content.Length.ToString());

// Add commands from modules
host.AddModules(typeof(Program).Assembly);

await host.RunAsync();