using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Models;

namespace ctrlspec.Repository
{
    public interface ITokenHandler
    {
         Task<string> CreateTokenAsync(Login loginTable);
          Task<string> GeneratePasswordTokenAsync(Login users);
    }
}