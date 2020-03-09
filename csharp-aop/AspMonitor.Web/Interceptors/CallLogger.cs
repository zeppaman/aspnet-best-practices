using Castle.DynamicProxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspMonitor.Web.Interceptors
{
    public class CallLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var executionId = Guid.NewGuid().ToString();

            Debug.WriteLine("{0} - Calling method {1} with parameters {2}... ", 
                executionId,
               invocation.Method.Name,
               JsonConvert.SerializeObject(invocation.Arguments));

            invocation.Proceed();

            Debug.WriteLine("{0} - Done: result was {1}.", 
                executionId, 
               JsonConvert.SerializeObject( invocation.ReturnValue));
        }
    }
}
