using Sales.Interface;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sales.ViewModels;
using Microsoft.Ajax.Utilities;
namespace Sales.Repository
{
    public class InvoiceRepos : IReposInvoice
    {
        private readonly AppDbContext _context;
        // GET: Product
        public InvoiceRepos()
        {
            _context = new AppDbContext();
        }

        public void Add(Invoice e)
        {
          
            _context.Invoices.Add(e);

        }


        public Invoice Search(int? id)
        {
            var Invoice = _context.Invoices.Find(id);

            return Invoice;
        }

        public List<Invoice> GetALL()
        {
            //_context.Invoices.Include(mbox => mbox.Category).ToList();
            return _context.Invoices.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       
     
    }
}