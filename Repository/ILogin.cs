using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Models;

namespace ctrlspec.Repository.ILogin
{
    public interface ILogin
    {
        Task<Login> SignUp(Login loginTable);
        Task<Login> Login(string emailId, string Password, string Role);

         Task<List<Login>> GetAll();
        Task<Login> GetByID(int Id);

         Task Delete(int Id);

    }
}