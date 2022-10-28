using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingDB.Custom_Model;

namespace TrainingDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TrainingDBContext _context;

        public UsersController(TrainingDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> UserDataUpload([FromForm] CustomUser user)
        {
            if (user.Profile_Pic == null)
            {
                return new UnsupportedMediaTypeResult();
            }

            if (user.Profile_Pic.Length > 0)
            {
                IFormFile formFile = user.Profile_Pic;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                var filePath = Path.Combine(folderPath, formFile.FileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    fileStream.Flush();

                }

            }


            User user1 = new User();
            user1.UserId = user.UserId;
            user1.UserName = user.UserName;
            user1.MobileNo = user.MobileNo;
            user1.Email = user.Email;
            user1.Gender = user.Gender;
            user1.DateOfBirth = user.DateOfBirth;
            user1.Hobbies = user.Hobbies;
            user1.ProfilePic = user.Profile_Pic.FileName;
            user1.Pword = user.Pword;
            user1.RoleId = user.RoleId;

            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpDelete("UserId")]

            public async Task<ActionResult<List<User>>> Delete(int id)
            {
                var dbUser = await _context.Users.FindAsync(id);
                if (dbUser == null)
                    return BadRequest("User not found.");

                _context.Users.Remove(dbUser);
                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }
        
    }
}
  
    


