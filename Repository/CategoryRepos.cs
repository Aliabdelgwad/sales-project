using Sales.Interface;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Sales.Repository
{
    public class CategoryRepos : IReposCategory
    {
        private readonly AppDbContext _context;

        public CategoryRepos()
        {
            _context = new AppDbContext();
        }

        public void Add(Category e)
        {

            _context.Categories.Add(e);
        }

        public void Delete(int? id)
        {
            var category = Search(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                Save();
            }
        }

     

        public Category Search(int? id)
        {
           return _context.Categories.Find(id);
          
        }
        public List<Category> GetALL()
        {
           return _context.Categories.ToList();
        }

     

        public void Save() {
            _context.SaveChanges();
        }

    }
}