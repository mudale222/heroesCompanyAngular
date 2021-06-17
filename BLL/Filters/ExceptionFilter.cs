using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

namespace heroesCompanyAngular.filters {
    public class ExceptionFilter : IExceptionFilter {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider) {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context) {
            if (!_hostingEnvironment.IsDevelopment()) {
                return;
            }
            context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                    {"controller", "Heroes"},
                                    {"action", "Error"}
                                    }
                                 );
        }
    }
}
