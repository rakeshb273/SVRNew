using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data
{
   public class DbInitializer
    {
        public DbInitializer( AppDataDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Bills.
            if (context.Bills.Any())
            {
                return;   // DB has been seeded
            }

            var Bills = new Bill[]
            {
            new Bill{Description="Carson",ID=1},
            new Bill{Description="Meredith",ID=2 }
            };
            foreach (Bill s in Bills)
            {
                context.Bills.Add(s);
            }
            context.SaveChanges();

            var Customers = new Customer[]
            {
            new Customer{Name="SVR CUSTOMER 1",  ID=3},
            new Customer{Name="SVR CUSTOMER 1",ID=1},
            new Customer{Name="SVR CUSTOMER 1", ID=2} 
            };
            foreach (Customer c in Customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

             
        }
    }
}
