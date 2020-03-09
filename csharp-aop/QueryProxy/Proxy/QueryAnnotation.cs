using Microsoft.Data.Sqlite;
using QueryProxy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QueryProxy.Proxy
{
    public class QueryAttribute : AOPAttribute
    {
        public string Template { get; set; }
        public   QueryAttribute(string template)
        {
            this.Template = template;
        }

        public override object Execute(MethodInfo targetMethod, object[] args, object[] annotations)
        {
            using (var data = new FruitDB())
            {
                return data.Fruits.FromSqlRaw<Fruit>(this.Template,args ).ToList(); //Dataset can be taken by target field
            }
        }
    }
}
