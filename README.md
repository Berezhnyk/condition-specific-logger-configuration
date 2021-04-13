# Condition-Specific LoggerConfiguration

## Serilog.LoggerConfiguration extensions
`ForCondition` checks custom condition   
`ForEnvironment` checks `ASPNETCORE_ENVIRONMENT` for custom value   
`ForDevelopment` checks `ASPNETCORE_ENVIRONMENT` for `Development` value  
`ForStaging` checks `ASPNETCORE_ENVIRONMENT` for `Staging` value  
`ForProduction` checks `ASPNETCORE_ENVIRONMENT` for `Production` value


## Install 
`Install-Package Serilog.LoggerConfiguration.ConditionExtensions -Version 1.0.0` or  
`dotnet add package Serilog.LoggerConfiguration.ConditionExtensions --version 1.0.0`

## How to use
```
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .ForDevelopment(config =>
    {
        config.WriteTo.ColoredConsole();
    })
    .ForProduction(config =>
    {
        config.WriteTo.Console(new RenderedCompactJsonFormatter());
    })
    .ForCondition(() => magicExists == "yes", config =>
    {
        // Do magic configuration here
    })
    .CreateLogger();
```