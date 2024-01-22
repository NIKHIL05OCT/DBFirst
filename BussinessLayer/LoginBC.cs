using DataAccessLayer.repo;
using BussinessLayer.repo;
using GE = GlobalEntity;

namespace BussinessLayer
{
    public class LoginBC : ILoginBC
    {
        private readonly ILoginDA _loginsDA;
        public LoginBC(ILoginDA login)
        {
            this._loginsDA = login;
        }
        public async Task<string> CreateUser(GE::tblEmployeeLogin model)
        {
            return await this._loginsDA.CreateUser(model);
        }
        public async Task<string> RemoveUser(int id)
        {
            return await this._loginsDA.RemoveUser(id);
        }
        public async Task<GE::tblEmployeeLogin> GetUserById(int id)
        {
            return await this._loginsDA.GetUserById(id);
        }
        public async Task<List<GE::tblEmployeeLogin>> GetAllUser()
        {
            return await this._loginsDA.GetAllUser();
        }
        public async Task<string> validateuser(string emailid, string password)
        {
            return await this._loginsDA.LoginAsync(emailid, password);
        }
    }
}
