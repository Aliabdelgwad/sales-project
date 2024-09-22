using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sales.ReposInterface
{
    public interface IReposUser
    {
        void Add(User e);
        User Search(string username);
        User SearchWhitPassUser(string username, string password);
        void Save();
        bool MyAny(string username);
    }
}
