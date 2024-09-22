using Sales.Interface;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Sales.Repository
{
    public class ProductRepos : IReposProduct
    {
        private readonly  AppDbContext _context;
      
        public ProductRepos()
        {
            _context = new AppDbContext();
        }

        public void Add(Product e)
        {


            _context.Products.Add(e);
         
        }

        public void Delete(int? id)
        {
            var Product = Search(id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
                Save();
            }
        }

        public Product Details(int? id)
        {
            return  _context.Products.Include(mbox => mbox.Category).SingleOrDefault(m => m.ProductId == id);

        }

        public Product Search(int? id)
        {
            var product= _context.Products.Find(id);
           
            return product;
        }

        public List<Product> GetALL()
        {
            return _context.Products.Include(mbox => mbox.Category).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    

        
    }
}