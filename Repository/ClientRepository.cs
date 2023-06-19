using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Data;
using ctrlspec.Models;
using Microsoft.EntityFrameworkCore;


namespace ctrlspec.Repository
{
    public class ClientRepository : IClient
    {
         private readonly CtrlSpecDbContext _context;

        public ClientRepository(CtrlSpecDbContext context)
        {
            _context = context;
        }
        public async Task<Application> Add(Application application)
        {
            try
            {
                var add = _context.Applications.Add(application);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return application;
        }
        //delete
        public async Task Delete(int C_ID)
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
        public async Task<List<Application>> GetAll()
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
        public async Task<Application> GetByID(int C_Id)
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
        //update
        public async Task<Application> Update(int C_Id, Application appdetails)
        {
            var cus = await _context.Applications.FindAsync(C_Id);
            if (cus != null)
            {
                cus.Application_Name = appdetails.Application_Name;
                cus.C_Name = appdetails.C_Name;
                 cus.Serverinfo = appdetails.Serverinfo;
              cus.Portinfo = appdetails.Portinfo;

                await _context.SaveChangesAsync();
            }
            return cus;

        }
    }
}