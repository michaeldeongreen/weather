using System;


namespace weather2.core.Models
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