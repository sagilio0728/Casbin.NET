﻿using System.Collections.Generic;
using System.Linq;
#if !NET45
using Microsoft.Extensions.Logging;

namespace Casbin.Extensions
{
    public static class LoggerExtension
    {
        public static void LogEnforceCachedResult(this ILogger logger, IEnumerable<object> requestValues, bool result)
        {
            logger.LogInformation("Request: {1} ---> {0} (cached)", result, 
                string.Join(", ", requestValues));
        }

        public static void LogEnforceResult(this ILogger logger, IEnumerable<object> requestValues, bool result)
        {
            logger.LogInformation("Request: {1} ---> {0}", result, 
                string.Join(", ", requestValues));
        }

        public static void LogEnforceResult(this ILogger logger, IEnumerable<object> requestValues,
            bool result, IEnumerable<IEnumerable<string>> explains)
        {
            logger.LogInformation("Request: {1} ---> {0}\nHit Policy: {2}", result, 
                string.Join(", ", requestValues),
                string.Join("\n", explains.Select(explain =>
                    string.Join(", ", explain))));
        }
    }
}
#endif