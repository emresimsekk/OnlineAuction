using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAuction.Product.Data.Seed
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Entities.Product> GetConfigureProducts()
        {
            return new List<Entities.Product>()
            {
                 new Entities.Product()
                 {
                     Name="Apple-6",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=400.00M,
                     Category="Mobile Phone Apple"
                 },
                 new Entities.Product()
                 {
                     Name="Apple-7",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=410.00M,
                     Category="Mobile Phone Apple"
                 },
                 new Entities.Product()
                 {
                     Name="Apple-8",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=420.00M,
                     Category="Mobile Phone Apple"
                 },
                 new Entities.Product()
                 {
                     Name="Apple-9",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=430.00M,
                     Category="Mobile Phone Apple"
                 },
                 new Entities.Product()
                 {
                     Name="Apple-10",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=440.00M,
                     Category="Mobile Phone Apple"
                 },
                 new Entities.Product()
                 {
                     Name="Apple-11",
                     Summary="Lorem Ipsum is simply dummy text of the printing and typesetting industry. " ,
                     Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. ",
                     ImageFile="produrct-1",
                     Price=450.00M,
                     Category="Mobile Phone Apple"
                 },
            };
        }
    }
}
