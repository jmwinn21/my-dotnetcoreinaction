using Microsoft.Extensions.Logging;

namespace ACController {
    public class RobustLoggerExtension {
        public static LoggerFactory AddRobust (this LoggerFactory factory) {
            factory.AddProvicer (new RobustLoggerProvider ());
            return factory;
        }
    }
}