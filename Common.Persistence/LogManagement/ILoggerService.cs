using System;
using System.Threading.Tasks;

namespace Common.Persistence.LogManagement
{
    public interface ILoggerService
    {
        Task Information(string messageTemplate, params object[] propertyValues);
        Task Warning(string messageTemplate, params object[] propertyValues);
        Task Error(Exception exception, string messageTemplate, params object[] propertyValues);
        Task Error(string messageTemplate, params object[] propertyValues);
    }
}
