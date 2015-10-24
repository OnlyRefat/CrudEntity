using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestL2_1
{
    class Program
    {
        static  TestDBEntities db = new TestDBEntities();
        public static void select()
        {
            var customers = db.Customers.ToList();
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
        }

        private static void insert()
        {
            var customer = db.Customers;
            Customer newCustomer = new Customer();
            Console.WriteLine("Please Enter the Id:\n");
           newCustomer.Id =Int16.Parse(Console.ReadLine());
           Console.WriteLine("Plase Enter the Name:");
           newCustomer.Name = Console.ReadLine();

           customer.Add(newCustomer);
           db.SaveChanges();
           
           Console.WriteLine(Guid.NewGuid());

        }

        private static void update()
        {
            var customer = db.Customers;
            Console.WriteLine("Please Enter the Id to be Edited");

           Customer updateCustomer= customer.Find(Int16.Parse(Console.ReadLine()));
           Console.WriteLine("Please Enter the Name");
           updateCustomer.Name = Console.ReadLine();
           db.SaveChanges();
        }

        private static void delete()
        {
            var customer = db.Customers;
            Console.WriteLine("Please Enter the Id to be deleted:");
           // int Id = Int16.Parse(Console.ReadLine());
            //Console.WriteLine(Id);
            Customer deleteCustomer = customer.Find(Int16.Parse(Console.ReadLine()));
            customer.Remove(deleteCustomer);
            db.SaveChanges();
            //deleteCustomer.Remove();

        }

        static void Main(string[] args)
        {
           
            Console.WriteLine(" 0.Exit\n 1.Select\n 2.Insert\n 3.Update\n 4.Delete\n");
            string input = Console.ReadLine();
            int option = Int32.Parse(input);
            while(option!=0)
            {
                switch(option)
            {
                case 1:
                    select();
                    break;

                case 2:
                    insert();
                    break;
                case 3:
                    update();
                    break;

                case 4:
                    delete();
                    break;


            }
                Console.WriteLine(" 0.Exit\n 1.Select\n 2.Insert\n 3.Update\n 4.Delete\n");
              input = Console.ReadLine();
             option = Int32.Parse(input);
            }
           
           
        }

       
    }
}
