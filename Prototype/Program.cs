using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Customer customer1 = new Person.Customer
                {FirstName = "Mehmet",
                    LastName = "SÜRÜCÜ",
                    City = "İstanbul",
                    Id = 1};
            
            var customer2 = (Person.Customer)customer1.Clone();
            customer2.FirstName = "Ziya";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();//prototip hale geldi.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class Customer : Person
        {
            public string City { get; set; }

            public override Person Clone()//Customeri Clonlamayı sağlar.
            {
                return (Person) MemberwiseClone();
            }
        }

        public class Employee : Person
        {

            public decimal Salary { get; set; }
            public override Person Clone()
            {
                return (Person)MemberwiseClone();
            }
        }

    }

    }

