using Microsoft.Data.Sqlite;
using QueryProxy.Proxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QueryProxy.Model
{
    public  class FruitRepositoryImpl
    {
        public void InitDB()
        {

            using (var db = new FruitDB())
            {
                db.Database.EnsureCreated();

                var count = db.Fruits.Count();
                if (count == 0)
                {
                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Lemon",
                        Family = "Citrus"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Orange",
                        Family = "Citrus"
                    });


                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Lemon",
                        Family = "Citrus"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "grapefruit",
                        Family = "Citrus"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Limes",
                        Family = "Citrus"
                    });


                    

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Pumpkin",
                        Family = "Cucurbitaceae"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Zucchini",
                        Family = "Cucurbitaceae"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Watermelon",
                        Family = "Cucurbitaceae"
                    });

                    db.Fruits.Add(new Fruit()
                    {
                        Name = "Cucumber",
                        Family = "Cucurbitaceae"
                    });

                    db.SaveChanges();

                }
            }

            //using (var connection = new SqliteConnection("Data Source=.\\Fruit.db"))
            //{
            //    connection.OpenAsync().Wait();

            //    var command = connection.CreateCommand();
            //    command.CommandText = @"CREATE TABLE IF NOT EXISTS fruits(
            //           name varchar(20) NOT NULL,
            //        family varchar(20)  NOT NULL
            //    ); ";

            //    command.ExecuteNonQuery();

            //    command.CommandText =
            //    @" INSERT INTO fruits (name,family) VALUES
            //    ('orange', 'citruses'),
            //    ('grapefruit', 'citruses'),
            //    ('pumpkin', 'cucurbits'),
            //    ('watermelon', 'cucurbits'),
            //    ('cucumber', 'cucurbits');";
            //    command.ExecuteNonQuery();

            //}
        }

    }
}
