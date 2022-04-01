namespace WebCalculatorWithDI
{
    public class ExceptionLogHandler
    {
        private readonly ILogger<ExceptionLogHandler> _logger;

        public ExceptionLogHandler(ILogger<ExceptionLogHandler> logger) =>
            _logger = logger;

        private void HandleIter(LogLevel logLevel, Exception exception) =>
            _logger.Log(logLevel, $"Exeption: {exception.Message}");

        private void HandleIter(LogLevel logLevel, NullReferenceException exception) =>
            _logger.Log(logLevel, $"Null: {exception.Message}");

        private void HandleIter(LogLevel logLevel, DivideByZeroException exception) =>
            _logger.Log(logLevel, $"Divide by Zero: {exception.Message}");

        public void Handle(LogLevel logLevel, Exception exception) =>
            Handle(logLevel, (dynamic)exception);
    }
}
