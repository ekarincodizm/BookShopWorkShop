using BookDB;
using BookRepository;
using BookService;
using System.Text.RegularExpressions;
using BookService.Interface;

namespace BookModel
{
    public class AccountService : IAccountService
    {
        public bool RegisterAccount(AccountServiceModel aaAccountServiceModel)
        {
            User user = new User();
            user.FirstName = aaAccountServiceModel.FirstName;
            user.LastName = aaAccountServiceModel.LastName;
            user.Address = aaAccountServiceModel.Address;
            user.BirthDay = aaAccountServiceModel.BirthDay;
            user.CritizenId = aaAccountServiceModel.CritizenId;
            user.Email = aaAccountServiceModel.Email;
            user.UserName = aaAccountServiceModel.UserName;
            user.Password = aaAccountServiceModel.Password;

            AccountRepository accountRepository = new AccountRepository();

            if (accountRepository.Get(user.UserName) == null)
            {
                if (!string.IsNullOrEmpty(user.FirstName) &&
                    !string.IsNullOrEmpty(user.LastName) &&
                    !string.IsNullOrEmpty(user.Address) &&
                    user.BirthDay != null &&
                    !string.IsNullOrEmpty(user.CritizenId) &&
                    !string.IsNullOrEmpty(user.Email) &&
                    !string.IsNullOrEmpty(user.UserName) &&
                    !string.IsNullOrEmpty(user.Password))
                {
                    accountRepository.Create(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}