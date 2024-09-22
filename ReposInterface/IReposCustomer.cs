using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Interface
{
    public interface IReposCustomer
    {
        List<Customer> GetALL();
        void Add(Customer e);
        void Delete(int? id);
        Customer Search(int? id);
        void Save();

    }
}
