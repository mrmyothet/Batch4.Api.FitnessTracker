using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;

namespace Batch4.Api.FitnessTracker.Features.User
{
    public class DA_User
    {
        private readonly AppDbContext _context;
        
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
    }
}
