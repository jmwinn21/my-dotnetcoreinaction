using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Logging;

namespace ACController {
    public class Telemetry {
        private readonly ILogger logger;
        private ResourceManager resMan;

        public Telemetry (ILogger logger) {
            this.logger = logger;
            this.resMan = new ResourceManager (
                "ACController.strings",
                typeof (Program).GetTypeInfo ().Assembly
            );
        }

        public void LogStatus () {
            logger.LogInformation (
                resMan.GetString ("ExhaustAirTemp") +
                TempControl.ExhaustAirTemp + " C");
            logger.LogInformation (
                resMan.GetString ("CoolantTemp") +
                TempControl.CoolantTemp + " C");
            logger.LogInformation (
                resMan.GetString ("OutsideAirTemp") +
                TempControl.OutsideAirTemp + " C");
        }
    }
}