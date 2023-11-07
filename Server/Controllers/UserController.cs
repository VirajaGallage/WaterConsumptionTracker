using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterConsumptionTracker.Server.Data;

namespace WaterConsumptionTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersManagement>>> GetUsers()
        {
            var users = await _context.UsersManagements.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersManagement>> GetSingleUsers(int id)
        {
            var user = await _context.UsersManagements
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound("No Users Can be Found!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsersManagement>>> CreateUser(UsersManagement user)
        {
            _context.UsersManagements.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UsersManagement>>> UpdateUser(UsersManagement user, int id)
        {
            var dbuser = await _context.UsersManagements
            .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbuser == null)
                return NotFound("The user can not be found!");

            dbuser.FirstName = user.FirstName;
            dbuser.LastName = user.LastName;
            dbuser.Email = user.Email;

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UsersManagement>>> DeleteUser(int id)
        {
            var dbuser = await _context.UsersManagements
            .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbuser == null)
                return NotFound("The user can not be found!");

            _context.UsersManagements.Remove(dbuser);

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        private async Task<List<UsersManagement>> GetDbUsers()
        {
            return await _context.UsersManagements.ToListAsync();

        }
        [HttpGet("id")]
        public async Task<ActionResult<WaterRecords>> GetWaterforUser(int id)
        {
            var wateruser = await _context.WaterRecords
                .FirstOrDefaultAsync(w => w.UserId == id);
            if (wateruser == null)
            {
                return NotFound("No Water Records Can be Found!");
            }
            return Ok(wateruser);
        }
    }
}