using BookDB;

namespace BookRepository.Interface
{
    public interface IAccountRepository
    {
        void Create(User user);
        User Get(string username);
    }
}
