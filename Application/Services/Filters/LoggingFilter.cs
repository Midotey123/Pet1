//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Pet1.Services.Filters
//{
//    /// <summary>
//    /// TODO: доделать фильтр логгирования методов контролера, с выводом имени действия и контроллера до и после выполнения.
//    /// </summary>
//    public class LoggingFilter : IActionFilter
//    {
//        private readonly ILogger<LoggingFilter> logger;
//        private readonly string title;
//        public LoggingFilter(ILogger<LoggingFilter> logger, string title)
//        {
//            this.logger = logger;
//            this.title = title;
//        }
//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            logger.LogInformation($"Log before controller's action {title}");
//        }
//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            logger.LogInformation($"Log before controller's action {title}");
//        }
//    }
//}
