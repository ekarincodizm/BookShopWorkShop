using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;
using BookModel;

namespace BookService.Interface
{
    public interface ILoginService
    {
        UserModel GetUser(string username, string password);
    }

}
