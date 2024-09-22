using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Interface
{
    public interface IReposCategory
    {
        List<Category> GetALL();
        void Add(Category e);
        void Delete(int? id);
        Category Search(int? id);
        void Save();
    
    }
}