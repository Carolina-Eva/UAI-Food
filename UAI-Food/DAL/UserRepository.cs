using Microsoft.Data.SqlClient;

namespace DAL
{
    public class UserRepository
    {
        Acceso _acceso = new Acceso();
        public async Task<bool> AreCredentialsValid(string user, string pass)
        {
            var result = await _acceso.GetScalarAsync("VALIDAR_USUARIO", new List<SqlParameter>
            {
                _acceso.CreateParameter("@UserName", user),
                _acceso.CreateParameter("@Password", pass)
            });
            return result != null && Convert.ToInt32(result) > 0;
        }

        public async Task<int> GetUsuarioId(string user)
        {
            string sql = "GET_USUARIO_ID";
            var parameters = new List<SqlParameter>
            {
                _acceso.CreateParameter("@NombreUsuario", user)
            };
            var result = await _acceso.GetScalarAsync(sql, parameters);

            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
