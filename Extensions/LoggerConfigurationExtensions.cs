
using System;
using ConditionExtensions.Constants;
using Serilog;

namespace ConditionExtensions.Extensions
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration ForDevelopment(this LoggerConfiguration config,
            Action<LoggerConfiguration> options) => config.ForEnvironment(Environments.Development, options);
        
        public static LoggerConfiguration ForStaging(this LoggerConfiguration config,
            Action<LoggerConfiguration> options) => config.ForEnvironment(Environments.Staging, options);
        
        public static LoggerConfiguration ForProduction(this LoggerConfiguration config,
            Action<LoggerConfiguration> options) => config.ForEnvironment(Environments.Production, options);

        public static LoggerConfiguration ForEnvironment(this LoggerConfiguration config, string environment,
            Action<LoggerConfiguration> options) =>
            config.ForCondition(() => IsEnvironment(environment), options);

        public static LoggerConfiguration ForCondition(this LoggerConfiguration config, Func<bool> condition, Action<LoggerConfiguration> options)
        {
            if (condition())
            {
                options.Invoke(config);
            }

            return config;
        }

        private static bool IsEnvironment(string environment) => string.Equals(
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            environment, StringComparison.OrdinalIgnoreCase);
    }
}