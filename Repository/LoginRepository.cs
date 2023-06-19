using ctrlspec.Data;
using ctrlspec.Models;
using ctrlspec.Repository.ILogin;
using Microsoft.EntityFrameworkCore;


namespace ctrlspec.Repos
{
    public class LoginRepository: ILogin
       {
          private readonly CtrlSpecDbContext _context;



        public LoginRepository(CtrlSpecDbContext context)

        {

            _context = context;

        }


        #region AddLoginDetailsAsync
        public async Task<Login> SignUp (Login loginTable)
        {
            try
            {
                await _context.login.AddAsync(loginTable);
                await _context.SaveChangesAsync();
                return loginTable;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region AuthenticateUserAsync
        public async Task<Login> Login (string emailId,string Password,string Role)
        {
          
                var user = await _context.login.FirstOrDefaultAsync(x => x.EmailId == emailId && x.Password == Password && x.Role == Role);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            // catch(Exception)
            // {
            //     throw;
         // }
     
        #endregion

          public async Task Delete(int ID)
        {
            Login deleteadmin = _context.login.Find(ID);
            try
            {
                var delete = _context.login.Remove(deleteadmin);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
          
      
        //  public async Task<List<Login>> GetAll()
        // {
        //     try
        //     {
        //         List<Login> login = await _context.login.ToListAsync();
        //         return login;
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }
   

     public async Task<List<Login>> GetAll()
        {
            try
            {
               List<Login> cardetails = await _context.login.ToListAsync();
                return cardetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
         

        #region GetLoginByIdAsync
        //GetById
        public async Task<Login> GetByID(int Id)
        {
            try
            {
                Login login = await _context.login.FindAsync(Id);
                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }

          #endregion
       }       
       
}

    