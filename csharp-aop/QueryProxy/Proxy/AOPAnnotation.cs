using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QueryProxy.Proxy
{
    public abstract class AOPAttribute: Attribute
    {
        public abstract object Execute(MethodInfo targetMethod, object[] args, object[] annotations);
    }
}
