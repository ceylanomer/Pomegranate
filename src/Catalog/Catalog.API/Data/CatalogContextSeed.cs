using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "asd",
                    Description = "asd"
                },
                new Product()
                {
                    Name = "Samsung",
                    Summary = "asd",
                    Description = "asd"
                },
                new Product()
                {
                    Name = "Sony",
                    Summary = "asd",
                    Description = "asd"
                }
            };
        }
    }
}