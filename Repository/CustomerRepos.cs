using Sales.Interface;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Repository
{
    public class CustomerRepos : IReposCustomer
    {
        private readonly AppDbContext _context;

        public CustomerRepos()
        {
            _context = new AppDbContext();
        }
        public void Add(Customer e)
        {
            _context.Customers.Add(e);
        }

        public void Delete(int? id)
        {
            var customer = Search(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                Save();
            }
              
        }


        public List<Customer> GetALL()
        {
            return  _context.Customers.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Customer Search(int? id)
        {
            return _context.Customers.Find(id);
        }

    }
}