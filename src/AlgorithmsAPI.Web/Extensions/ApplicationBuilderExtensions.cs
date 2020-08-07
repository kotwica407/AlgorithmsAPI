using System;
using Microsoft.AspNetCore.Builder;

namespace AlgorithmsAPI.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder When(
            this IApplicationBuilder builder,
            bool predicate,
            Func<IApplicationBuilder> compose) => predicate ? compose() : builder;
    }
}