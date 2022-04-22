﻿using App.Commands;
using App.Extensions;
using IbanNet;
using IbanNet.Registry;
using Lib.Helpers;
using Lib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return CreateHostBuilder(args).RunCommandLineApplicationAsync<MainCommand>(args);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddJsonFile();
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                })
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConsoleLogger();
                    loggingBuilder.AddNonGenericLogger();
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<MainCommand>();
                    services.AddTransient<GenerateCommand>();
                    services.AddTransient<ValidateCommand>();
                    services.AddTransient<IIbanService, IbanService>();
                    services.AddTransient<IConsoleHelper, ConsoleHelper>();
                    services.AddTransient<IIbanValidator, IbanValidator>();
                    services.AddTransient<IIbanGenerator, IbanGenerator>();
                });
    }
}