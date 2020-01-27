using System;
using Microsoft.Extensions.Logging;

namespace weather.core.Models
{
    public class LogContext
    {
        public Guid UserId {get;private set;}

        public LogContext()
        {
            UserId = Guid.NewGuid();
        }
    }
}