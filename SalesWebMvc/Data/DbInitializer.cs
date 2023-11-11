using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SalesWebMvcContext context)
        {
            if (context.Department.Any() || context.Seller.Any() || context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new(1, "Computers");
            Department d2 = new(2, "Electronics");
            Department d3 = new(3, "Fashion");
            Department d4 = new(4, "Book");

            Seller s1 = new(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            List<SalesRecord> records = new()
            {
                new(1, new DateTime(2023, 09, 25), 11000.0, SaleStatus.Billed, s1),
                new(2, new DateTime(2023, 09, 4), 7000.0, SaleStatus.Billed, s5),
                new(3, new DateTime(2023, 09, 13), 4000.0, SaleStatus.Canceled, s4),
                new(4, new DateTime(2023, 09, 1), 8000.0, SaleStatus.Billed, s1),
                new(5, new DateTime(2023, 09, 21), 3000.0, SaleStatus.Billed, s3),
                new(6, new DateTime(2023, 09, 15), 2000.0, SaleStatus.Billed, s1),
                new(7, new DateTime(2023, 09, 28), 13000.0, SaleStatus.Billed, s2),
                new(8, new DateTime(2023, 09, 11), 4000.0, SaleStatus.Billed, s4),
                new(9, new DateTime(2023, 09, 14), 11000.0, SaleStatus.Pending, s6),
                new(10, new DateTime(2023, 09, 7), 9000.0, SaleStatus.Billed, s6),
                new(11, new DateTime(2023, 09, 13), 6000.0, SaleStatus.Billed, s2),
                new(12, new DateTime(2023, 09, 25), 7000.0, SaleStatus.Pending, s3),
                new(13, new DateTime(2023, 09, 29), 10000.0, SaleStatus.Billed, s4),
                new(14, new DateTime(2023, 09, 4), 3000.0, SaleStatus.Billed, s5),
                new(15, new DateTime(2023, 09, 12), 4000.0, SaleStatus.Billed, s1),
                new(16, new DateTime(2023, 10, 5), 2000.0, SaleStatus.Billed, s4),
                new(17, new DateTime(2023, 10, 1), 12000.0, SaleStatus.Billed, s1),
                new(18, new DateTime(2023, 10, 24), 6000.0, SaleStatus.Billed, s3),
                new(19, new DateTime(2023, 10, 22), 8000.0, SaleStatus.Billed, s5),
                new(20, new DateTime(2023, 10, 15), 8000.0, SaleStatus.Billed, s6),
                new(21, new DateTime(2023, 10, 17), 9000.0, SaleStatus.Billed, s2),
                new(22, new DateTime(2023, 10, 24), 4000.0, SaleStatus.Billed, s4),
                new(23, new DateTime(2023, 10, 19), 11000.0, SaleStatus.Canceled, s2),
                new(24, new DateTime(2023, 10, 12), 8000.0, SaleStatus.Billed, s5),
                new(25, new DateTime(2023, 10, 31), 7000.0, SaleStatus.Billed, s3),
                new(26, new DateTime(2023, 10, 6), 5000.0, SaleStatus.Billed, s4),
                new(27, new DateTime(2023, 10, 13), 9000.0, SaleStatus.Pending, s1),
                new(28, new DateTime(2023, 10, 7), 4000.0, SaleStatus.Billed, s3),
                new(29, new DateTime(2023, 10, 23), 12000.0, SaleStatus.Billed, s5),
                new(30, new DateTime(2023, 10, 12), 5000.0, SaleStatus.Billed, s2),
                new(31, new DateTime(2023, 11, 4), 7000.0, SaleStatus.Billed, s5),
                new(32, new DateTime(2023, 11, 1), 8000.0, SaleStatus.Billed, s1),
                new(33, new DateTime(2023, 11, 11), 4000.0, SaleStatus.Billed, s4),
                new(34, new DateTime(2023, 11, 7), 9000.0, SaleStatus.Billed, s6),
                new(35, new DateTime(2023, 11, 4), 3000.0, SaleStatus.Billed, s5),
                new(36, new DateTime(2023, 11, 5), 2000.0, SaleStatus.Billed, s4),
                new(37, new DateTime(2023, 11, 1), 12000.0, SaleStatus.Billed, s1),
                new(38, new DateTime(2023, 11, 6), 5000.0, SaleStatus.Billed, s4),
                new(39, new DateTime(2023, 11, 7), 4000.0, SaleStatus.Billed, s3),
                new(40, new DateTime(2023, 11, 11), 5000.0, SaleStatus.Billed, s2)
            };

            context.Department.AddRange(d1, d2, d3, d4);

            context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            context.SalesRecord.AddRange(records);

            context.SaveChanges();
        }
    }
}
