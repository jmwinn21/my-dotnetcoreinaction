using System;
using Microsoft.Extensions.Logging;

namespace ACController {
    public class RobustLogger {
        public IDisposable BeginScope<TState> (TState state) =>
            throw new NotImplementedException ();
        public bool IsEnabled (LogLevel logLevel) => logLevel > LogLevel.Debug;

        public void Log<State> (LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            Console.WriteLine (string.Join (" ", DateTime.Now, logLevel, formatter (state, exception)));
        }
    }
}