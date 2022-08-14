using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrributes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Ozlu", Age = 32};
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }
    [ToTable("Customers")]
    public class Customer
        {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
        }
    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew Method")] // metodu eski versiyon olduğunu
        public void Add(Customer customer )
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    
}
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)] 
    // AttributeTargets.All herkes kullanabilir,
    // AllowMultiple aynı yerde birden fazla kullanılabilir
    class RequiredPropertyAttribute:Attribute // Attribute kural belirtir
    {

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field)] 
    // '|' işreti ile birden fazla hedef belirtilir
    class ToTableAttribute:Attribute
    {
        public string _tablename;

        public ToTableAttribute(string tablename)
        {
            _tablename = tablename;
        }
    }
}
