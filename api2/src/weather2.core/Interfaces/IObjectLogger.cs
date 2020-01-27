using System;
using Microsoft.Extensions.Logging;

namespace weather2.core.Interfaces
{
    /// <summary>
    /// All the methods here echo the functionality of the ILogger extension found here:
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions?view=aspnetcore-2.2
    /// We force the use the EventIds here, so that all events have proper Ids going into application insights.
    /// The LogXYZObject methods provide a simplified wrapper to allow for easy logging of entire objects to 
    /// Application Insights via the BeginScope method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectLogger<T>
    {
        void LogInformation(EventId eventId, string message, params object[] args);
        void LogInformation(EventId eventId, Exception ex, string message, params object[] args);
        void LogInformationObject(EventId eventId, object o);
        void LogInformationObject(EventId eventId, Exception ex, object o);
        void LogWarning(EventId eventId, string message, params object[] args);
        void LogWarning(EventId eventId, Exception ex, string message, params object[] args);
        void LogWarningObject(EventId eventId, object o);
        void LogWarningObject(EventId eventId, Exception ex, object o);
        void LogError(EventId eventId, string message, params object[] args);
        void LogError(EventId eventId, Exception ex, string message, params object[] args);
        void LogErrorObject(EventId eventId, object o);
        void LogErrorObject(EventId eventId, Exception ex, object o);
        void LogCritical(EventId eventId, string message, params object[] args);
        void LogCritical(EventId eventId, Exception ex, string message, params object[] args);
        void LogCriticalObject(EventId eventId, object o);
        void LogCriticalObject(EventId eventId, Exception ex, object o);
    }
}
