# Condition-Specific LoggerConfiguration

## Serilog.LoggerConfiguration extensions
`ForCondition` checks custom condition   
`ForEnvironment` checks `ASPNETCORE_ENVIRONMENT` for custom value   
`ForDevelopment` checks `ASPNETCORE_ENVIRONMENT` for `Development` value  
`ForStaging` checks `ASPNETCORE_ENVIRONMENT` for `Staging` value  
`ForProduction` checks `ASPNETCORE_ENVIRONMENT` for `Production` value


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