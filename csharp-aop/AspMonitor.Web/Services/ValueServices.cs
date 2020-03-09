using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMonitor.Web.Services
{

    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }

    [Intercept("log-calls")]
    public class ValuesService : IValuesService
    {
        private readonly ILogger<ValuesService> _logger;

        public ValuesService(ILogger<ValuesService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> FindAll()
        {
            _logger.LogDebug("{method} called", nameof(FindAll));

            return new[] { "value1", "value2" };
        }

        public string Find(int id)
        {
            _logger.LogDebug("{method} called with {id}", nameof(Find), id);

            return $"value{id}";
        }
    }
}
