using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;
using BookRepository.Interface;

namespace BookRepository
{
    public class AccountRepository : IAccountRepository
    {
        public void Create(User user)
        {
            using (var db = new IconextBookShopEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public User Get(string username)
        {
            using (var db = new IconextBookShopEntities())
            {
                var data= db.Users.Include("UserClass").FirstOrDefault(x => x.UserName.Equals(username));
                return data;
            }
        }
      
    }
}
