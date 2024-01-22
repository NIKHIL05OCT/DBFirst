using DataAccessLayer.Models;
using DataAccessLayer.repo;
using Microsoft.EntityFrameworkCore;
using GE = GlobalEntity;

namespace DataAccessLayer
{
    public class LoginDA : ILoginDA
    {
        private readonly DbfirstContext _dbcontext;
        public LoginDA(DbfirstContext dbfirst)
        {
            this._dbcontext = dbfirst;
        }
        public async Task<string> CreateUser(GE::tblEmployeeLogin model)
        {
            string res = string.Empty;
            try
            {
                if (model.Id > 0)
                {
                    var _exist = await this._dbcontext.EmployeeLogins.FirstOrDefaultAsync(itm => itm.Id == model.Id);
                    if (_exist != null)
                    {
                        _exist.Id = model.Id;
                        _exist.UserName = model.UserName;
                        _exist.EmailId = model.EmailId;
                    }
                }
                else
                {
                    EmployeeLogin _login = new EmployeeLogin()
                    {
                        UserName = model.UserName,
                        EmailId = model.EmailId,
                        Password = model.Password,
                    };
                    await _dbcontext.EmployeeLogins.AddAsync(_login);
                }
                await _dbcontext.SaveChangesAsync();
                res = "Saved";
                return res;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                return "fail";
            }
        }
        public async Task<string> RemoveUser(int id)
        {
            string res = string.Empty;
            var _data = await this._dbcontext.EmployeeLogins.FirstOrDefaultAsync(itm => itm.Id == id);

            if (_data != null)
            {
                try
                {
                    this._dbcontext.EmployeeLogins.Remove(_data);
                    await this._dbcontext.SaveChangesAsync();
                    res = "deleted";
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                    res = "fail";
                }
            }
            return res;
        }
        public async Task<List<GE::tblEmployeeLogin>> GetAllUser()
        {
            var _data = await this._dbcontext.EmployeeLogins.ToListAsync();
            List<GE::tblEmployeeLogin> logins = new List<GE::tblEmployeeLogin>();

            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    logins.Add(new GE.tblEmployeeLogin()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        EmailId = item.EmailId,
                    });
                });
            }
            return logins;
        }
        public async Task<GE::tblEmployeeLogin> GetUserById(int id)
        {
            var _data = await this._dbcontext.EmployeeLogins.FirstOrDefaultAsync(item => item.Id == id);
            GE::tblEmployeeLogin employees = new GE.tblEmployeeLogin();

            if (_data != null)
            {
                employees = (new GE.tblEmployeeLogin()
                {
                    Id = _data.Id,
                    UserName = _data.UserName,
                    EmailId = _data.EmailId,
                });
            }
            return employees;
        }
        public async Task<string> LoginAsync(string emailid, string password)
        {
            string res = string.Empty;
            var _data = await this._dbcontext.EmployeeLogins.FirstOrDefaultAsync(item => item.EmailId == emailid && item.Password == password);
            GE::tblEmployeeLogin employees = new GE.tblEmployeeLogin();
            if (_data != null)
                res = "valid";
            else
                res = "invalid";
            return res;
        }
    }
}
