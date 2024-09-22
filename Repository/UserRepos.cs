using Sales.Models;
using Sales.ReposInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Repository
{
    public class UserRepos : IReposUser
    {
        private readonly AppDbContext _context;

        public UserRepos()
        {
            _context = new AppDbContext();
        }

        public void Add(User e)
        {

            _context.Users.Add(e);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public User Search(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
            
        }
        public User SearchWhitPassUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        }

        public bool MyAny(string username) {

            return _context.Users.Any(u => u.Username == username);
        }
    }

}
