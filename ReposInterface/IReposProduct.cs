using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Interface
{
    public interface IReposProduct
    {

        void Add(Product e);



        void Delete(int? id);


        Product Details(int? id);


        Product Search(int? id);


        List<Product> GetALL();

        void Save();
       

    }
}
