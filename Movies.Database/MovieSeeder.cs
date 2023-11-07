using Bogus;
using Movies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Database
{
    public class MovieSeeder
    {
        public static List<Movie> GenerateProductData()
        {
            int productId = 1;
            var productFaker = new Faker<Movie>("pl")
                .UseSeed(123456)
                .RuleFor(x => x.Title, x => x.Random.Word())
                .RuleFor(x => x.Director, x => x.Person.FullName)
                .RuleFor(x => x.Id, x => productId++)
                .RuleFor(x => x.Year, x => x.Date.PastDateOnly().Year);

            return productFaker.Generate(50).ToList();

        }
    }
}
