using CatsSelection_Priceadjustment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Threading.Channels;

namespace CatsSelection_Priceadjustment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<NORTHWINDContext>()
           .UseSqlServer("Server=.;Database=NORTHWIND;Trusted_Connection=True;TrustServerCertificate=True;")
           .Options;
            using (NORTHWINDContext db = new NORTHWINDContext(options))
            {
                var cats = db.Categories.AsNoTracking().ToList();
                Console.WriteLine($"{"Category ID".PadRight(15)}{"Categoey Name".PadRight(25)} Description" +
                  $"\n==========================================================");
                foreach (var item in cats)
                {
                    Console.WriteLine($"{item.CategoryId.ToString().PadRight(15)}{item.CategoryName.PadRight(25)}" +
                        $"{item.Description ?? "There is no Description"}");
                }
                decimal userPercnt;
                bool isConverted;
                string userCat;
                int totalCats = cats.Count;
                do
                {
                    Console.WriteLine("Enter Category Name/Id");
                    userCat = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userCat))
                    {
                        userCat = null;
                        continue;
                    }

                    if (int.TryParse(userCat, out int catId))
                    {
                        if (catId <= 0 || catId > totalCats)
                        {
                            Console.WriteLine("Category Id Invaid");
                            userCat = null;
                        }
                    }
                    else
                    {
                        if (!cats.Any(c => c.CategoryName.Equals(userCat, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine(" Category Name invalid");
                            userCat = null;
                        }

                    }

                } while (userCat == null);
                do
                {
                    Console.WriteLine("Enter Discount Percentage (1:100)");
                    isConverted = decimal.TryParse(Console.ReadLine(), out userPercnt);

                }
                while (!isConverted || userPercnt <= 0 || userPercnt > 100);
                List<Category> prods = null;

                if (int.TryParse(userCat, out int id))
                {
                    prods = db.Categories.Include(x => x.Products).Where(c => c.CategoryId == id).ToList();
                }
                else
                {
                    prods = db.Categories.Include(x => x.Products).Where(c => c.CategoryName == userCat).ToList();
                }
                decimal discount = (userPercnt / 100);
                Console.WriteLine($"=======================================================================\n" +
                    $"{"Products".PadRight(38)}{"Price".PadRight(15)}Discounted");
                foreach (var item in prods)
                {
                    foreach (var item1 in item.Products)
                    {
                        Console.WriteLine($"{item1.ProductName.PadRight(38)}{item1.UnitPrice.ToString().PadRight(15)}" +
                      $"{item1.UnitPrice - (item1.UnitPrice * discount)}");
                    }
                }

            }


        }
    }
}
