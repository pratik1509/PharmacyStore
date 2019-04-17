using System;
using System.Threading.Tasks;

namespace Common.Persistence.LogManagement
{
    public class SerilogLoggerService : ILoggerService
    {
        private Serilog.ILogger _seriLogger;

        public SerilogLoggerService(Serilog.ILogger seriLogger)
        {
            _seriLogger = seriLogger;
        }

        public Task Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _seriLogger.Error(exception, messageTemplate, propertyValues);
            return Task.CompletedTask;
        }

        public Task Error(string messageTemplate, params object[] propertyValues)
        {
            _seriLogger.Error(messageTemplate, propertyValues);
            return Task.CompletedTask;
        }

        public Task Information(string messageTemplate, params object[] propertyValues)
        {
            _seriLogger.Information(messageTemplate, propertyValues);
            return Task.CompletedTask;
        }

        public Task Warning(string messageTemplate, params object[] propertyValues)
        {
            _seriLogger.Warning(messageTemplate, propertyValues);
            return Task.CompletedTask;
        }
    }
}
