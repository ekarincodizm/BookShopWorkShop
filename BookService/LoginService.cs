using BookRepository;
using BookService.Interface;
using System;
using System.Web;
using BookDB;
using BookModel;

namespace BookService
{
    public class LoginService : ILoginService
    {


        public UserModel GetUser(string username, string password)
        {
            UserModel userModel = new UserModel();
            AccountRepository accountRepository = new AccountRepository();
            try
            {
                var user = accountRepository.Get(username);
                if (user.Password.Equals(password))
                {
                    
                    userModel.Id = user.Id;
                    userModel.CritizenId = user.CritizenId;
                    userModel.BirthDay = user.BirthDay;
                    userModel.UserName = user.UserName;
                    userModel.FirstName = user.FirstName;
                    userModel.LastName = user.LastName;
                    userModel.Password = user.Password;
                    userModel.Email = user.Email;
                    userModel.Address = user.Address;
                    userModel.ZipCode = user.ZipCode;
                    userModel.UserClassId = user.UserClass.Id;
                    userModel.UserClassName = user.UserClass.UserClassName;
                    return userModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }
}