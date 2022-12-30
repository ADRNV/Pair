namespace Pair.Core.Services
{
    public interface IAuthService<U> where U : class
    {
        Task<bool?> SignIn(U user);
    }
}
