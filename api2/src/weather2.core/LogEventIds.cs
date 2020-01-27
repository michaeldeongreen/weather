// Numbering scheme 
// 5 digits - ABCDE
//
// A == one of the following
// 0 == Trace.  Logs that contain the most detailed messages.These messages may contain sensitive application data.These messages are disabled by default and should never be enabled in a production environment.
// 1 == Debug. Logs that are used for interactive investigation during development. These logs should primarily contain information useful for debugging and have no long-term value. 
// 2 == Information.  Logs that track the general flow of the application.These logs should have long-term value.
// 3 == Warning.  Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the application execution to stop.
// 4 == Error.  Logs that highlight when the current flow of execution is stopped due to a failure.These should indicate a failure in the current activity, not an application-wide failure. 
// 5 == Critical.  Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention.
//
// BC == Subsystem.
// 00 == App level, mid tier, config etc
// 01 == Weather 
//
// DE are up to the discrtion of the subsystem, usually incrementing from 00.

using Microsoft.Extensions.Logging;

namespace weather2.core
{
    public static class LogEventIds
    {
        // App
        public static EventId AppLoggerParsingError = new EventId(40000, "ERROR: Logging object parsing failed.");

        // Weather
        public static EventId WeatherForecast2ControllerGetEnterInformation = new EventId(20100, "INFORMATION: Logging WeatherForecastController GET enter.");
        public static EventId WeatherForecast2ControllerGetExitInformation = new EventId(20101, "INFORMATION: Logging WeatherForecastController GET exit.");
    }
}