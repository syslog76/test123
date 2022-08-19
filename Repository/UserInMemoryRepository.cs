using lang.Models;
using lang.Service;

namespace lang.Repository
{
    public class UserInMemoryRepository : IUserRepository
    {
        private readonly MilMemoryCache<User> _storage = new MilMemoryCache<User>("userMemStorage", 10, CacheType.Default);
        private readonly KeysService<string> _stringKeyService;

        public UserInMemoryRepository(KeysService<string> stringKeyService)
        {
            _stringKeyService = stringKeyService;
        }

        public Guid Add(string nickname, string email)
        {
            _storage.Put(email, new User
            {
                Nickname = nickname,
                Email = email
            });
            return _stringKeyService.GenKey(email);
        }
    }
}
