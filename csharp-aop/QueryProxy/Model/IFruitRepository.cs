using Microsoft.Data.Sqlite;
using QueryProxy.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryProxy.Model
{
    public interface IFruitRepository
    {
        [Query("SELECT * FROM fruits where family={0}")]
        List<Fruit> GetFruits(string tree);


        [Query("SELECT * FROM fruits where family='Citrus'")]
        List<Fruit> GetCitrus(string tree);

        public void InitDB();
    }
}
