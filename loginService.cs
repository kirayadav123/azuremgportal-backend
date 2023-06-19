using ctrlspec.Repository;
using ctrlspec.Repository.ILogin;

namespace ctrlspec
{
    internal class loginService
    {
        private ILogin _loginRepo;

        public loginService(ILogin loginRepo)
        {
            _loginRepo = loginRepo;
        }
    }
}