using BE;
using DAL;

namespace BLL
{
    public class UsuarioManager
    {
        UserRepository _userRepo = new UserRepository();

        public async Task<int> GetUsuarioId(string username)
        {
            return await _userRepo.GetUsuarioId(username);
        }

        public async Task<bool> AttemptLogin(string username, string password)
        {
            if (await _userRepo.AreCredentialsValid(username, password))
            {
               return true;
            }
            return false;
        }
    }
}
