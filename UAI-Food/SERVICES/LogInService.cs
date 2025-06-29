using BE;
namespace SERVICES
{
    public class LogInService
    {
        private static readonly object _lock = new object();
        private static LogInService _instance;
        public static LogInService GetInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null) _instance = new LogInService();
                    return _instance;
                }
            }
        }
        public Usuario User { get; private set; }
        private LogInService() { }
        public void Login(Usuario user)
        {
            _instance.User = user;

        }
        public void Logout()
        {
            _instance = null;
        }
    }
}
