namespace lang.Repository;

public interface IUserRepository
{
    Guid Add(string nickname, string email);
}