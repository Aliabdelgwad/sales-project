using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Interface
{
   public interface IReposInvoice
    {

        void Add(Invoice e);
        Invoice Search(int? id);
        List<Invoice> GetALL();
        void Save();
       

        
    }
}
