using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.FitnessTracker.Features.User
{
    public class DA_User
    {
        private readonly AppDbContext _context;
        private UserData? _currentUser;
        
        public DA_User(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MessageResponseModel> RegisterAsync(Tbl_User tbl_user)
        {
            MessageResponseModel response = new MessageResponseModel();
            try
            {
                await _context.tblUser.AddAsync(tbl_user);
                int result = await _context.SaveChangesAsync();
                 response = result > 0 ? new MessageResponseModel(true, "Registration successful!")
                                     : new MessageResponseModel(false, "Registration Fail!");
            }
            catch(Exception ex)
            {
                response = new MessageResponseModel(false, ex);
            }
            return response;
        } 

        public async Task<MessageResponseModel> LoginAsync(Tbl_User tbl_User)
        {
            MessageResponseModel response = new MessageResponseModel();
            try
            {
                var item = await _context.tblUser
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.UserName == tbl_User.UserName &&
                                                      x.Password == tbl_User.Password);
                if(item is null)
                {
                    response= new MessageResponseModel(false, "User not found");
                    _currentUser!.IncreaserLoginAttemps();
                    goto result;
                }
                _currentUser = new UserData(item.UserName!, item.Password!);
                _currentUser.RestLoginAttemps();
                response = new MessageResponseModel(true, "Successfully Login");
            }   
            catch (Exception ex)
            {
                response = new MessageResponseModel(false, ex);
            }
            result:
            return response;
        }
    }
}
