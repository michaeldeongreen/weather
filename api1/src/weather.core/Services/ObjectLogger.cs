using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using weather.core.Interfaces;
using weather.core;

namespace weather.core.services
{
    public class ObjectLogger<T> : IObjectLogger<T>
    {
        private readonly ILogger<T> _logger;
        public ObjectLogger(ILogger<T> log)
        {
            _logger = log;
        }

        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            _logger.LogInformation(eventId, message, args);
        }
        public void LogInformation(EventId eventId, Exception ex, string message, params object[] args)
        {
            _logger.LogInformation(eventId, ex, message, args);
        }

        public void LogInformationObject(EventId eventId, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogInformation(eventId, eventId.Name);
            }
        }

        public void LogInformationObject(EventId eventId, Exception ex, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogInformation(eventId, ex, eventId.Name);
            }
        }


        public void LogWarning(EventId eventId, string message, params object[] args)
        {
            _logger.LogWarning(eventId, message, args);
        }
        public void LogWarning(EventId eventId, Exception ex, string message, params object[] args)
        {
            _logger.LogWarning(eventId, ex, message, args);
        }


        public void LogWarningObject(EventId eventId, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogWarning(eventId, eventId.Name);
            }
        }

        public void LogWarningObject(EventId eventId, Exception ex, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogWarning(eventId, ex, eventId.Name);
            }
        }

        public void LogError(EventId eventId, string message, params object[] args)
        {
            _logger.LogError(eventId, message, args);
        }

        public void LogError(EventId eventId, Exception ex, string message, params object[] args)
        {
            _logger.LogError(eventId, ex, message, args);
        }

        public void LogErrorObject(EventId eventId, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogError(eventId, eventId.Name);
            }
        }

        public void LogErrorObject(EventId eventId, Exception ex, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogError(eventId, ex, eventId.Name);
            }
        }

        public void LogCritical(EventId eventId, string message, params object[] args)
        {
            _logger.LogCritical(eventId, message, args);
        }

        public void LogCritical(EventId eventId, Exception ex, string message, params object[] args)
        {
            _logger.LogCritical(eventId, ex, message, args);
        }

        public void LogCriticalObject(EventId eventId, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogCritical(eventId, eventId.Name);
            }
        }

        public void LogCriticalObject(EventId eventId, Exception ex, Object o)
        {
            using (_logger.BeginScope(ConvertToDictionary(o)))
            {
                _logger.LogCritical(eventId, ex, eventId.Name);
            }
        }

        // This routine convert objects into dictionary of type Dictionary<string, object> 
        // so that the log will put the key / value pairs into the log
        private Dictionary<string, object> ConvertToDictionary(object o)
        {
            try
            {
                JObject jsonObject;
                if (o is string)
                {
                    return new Dictionary<string, object> { { "Message", o } };
                }
                if (o.GetType().IsArray)
                {
                    var Array = o;
                    var no = new { Array };
                    jsonObject = JObject.FromObject(no);
                }
                else
                {
                    jsonObject = JObject.FromObject(o);
                }
                IEnumerable<JToken> jTokens = jsonObject.Descendants().Where(p => p.Count() == 0);
                Dictionary<string, object> results = jTokens.Aggregate(new Dictionary<string, object>(),
                    (properties, jToken) =>
                    {
                        properties.Add(jToken.Path, jToken.ToString());
                        return properties;
                    });
                return results ?? new Dictionary<string, object> { { "Logger Error", "Null Object" } };
            }
            catch (JsonReaderException hre)
            {
                _logger.LogCritical(LogEventIds.AppLoggerParsingError,
                    $"JSonReaderException Error in logging parser: {hre.Message}");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogCritical(LogEventIds.AppLoggerParsingError,
                    $"Unknown Error in logging parser: {e.Message}");
                return null;
            }
        }
    }
}