using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Data;
using ctrlspec.Models;
using Microsoft.EntityFrameworkCore;

namespace ctrlspec.Repository
{
    public class AdminRepository :IAdmin
    {
      /*   private readonly CtrlSpecDbContext _login;
        
         public AdminRepository(CtrlSpecDbContext login)
        {
            _login = login;
        }
         public async Task<List<Login>> GetAll()
        {
            try
            {
                List<Login> login = await _login.login.ToListAsync();
                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //GetById
        public async Task<Login> GetByID(int Id)
        {
            try
            {
                Login login = await _login.login.FindAsync(Id);
                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }*/

          private readonly CtrlSpecDbContext _context;

        public AdminRepository(CtrlSpecDbContext context)
        {
            _context = context;
        }
       
        //delete
        public async Task DeleteApp(int C_ID)
        {
            Application Applicationdetails = _context.Applications.Find(C_ID);
            try
            {
                var delete = _context.Applications.Remove(Applicationdetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
        //getall
        public async Task<List<Application>> GetAllApp()
        {
            try
            {
                List<Application> appdetails = await _context.Applications.ToListAsync();
                return appdetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
    
       

        //GetById
        public async Task<Application> GetByIDApp(int C_Id)
        {
            try
            {
                Application appdetails = await _context.Applications.FindAsync(C_Id);
                return appdetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
   
       
    }
}