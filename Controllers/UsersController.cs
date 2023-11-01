using CRUDTask.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRUDTask.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetUsers()
        {
            using (var context = new TaskDBContext())
            {
                if (context.Users == null || context.Users.Count() == 0)
                    return BadRequest();

                var users = await context.Users.ToListAsync();

                return Ok(users);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            using (var context = new TaskDBContext())
            {
                var user = await context.Users.Select(x => x).Where(x => x.Id == id).FirstOrDefaultAsync();

                if (user == null) 
                    return NotFound();

                return Ok(user);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddUser(User user)
        {
            using (var context = new TaskDBContext())
            {
                try
                {
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    return Created("api/users", user);
                }
                catch (DbEntityValidationException ex)
                {
                    var message = "";

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        message = " " + error.ValidationErrors.First().ErrorMessage;
                    }

                    return BadRequest(message);
                }
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteUserById(int id) 
        { 
            using (var context = new TaskDBContext())
            {
                var user = await context.Users
                    .Select(x => x)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();

                    return Ok(user);
                }

                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> UpdateUser(int id, User newUser)
        {

            using (var context = new TaskDBContext())
            {
                var user = await context.Users
                    .Select(x => x)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                try
                {
                    if (user == null)
                        return NotFound();

                    user.Name = newUser.Name;
                    user.PhoneNumber = newUser.PhoneNumber;
                    user.Email = newUser.Email;

                    var errors = context.GetValidationErrors();

                    await context.SaveChangesAsync();

                    return Ok(user);
                }
                catch (DbEntityValidationException ex)
                {
                    var message = "";

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        message = " " + error.ValidationErrors.First().ErrorMessage;
                    }

                    return BadRequest(message);
                }
            }
        }

        [HttpPut]
        [Route("{id:int}/name")]
        public async Task<IHttpActionResult> UpdateUserName(int id, string newName)
        {
            using (var context = new TaskDBContext())
            {
                var user = await context.Users
                    .Select(x => x)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                try
                {
                    if (user != null)
                    {
                        user.Name = newName;

                        await context.SaveChangesAsync();

                        return Ok(user);
                    }

                    return BadRequest();
                }
                catch (DbEntityValidationException ex)
                {
                    var message = "";

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        message = " " + error.ValidationErrors.First().ErrorMessage;
                    }

                    return BadRequest(message);
                }
            }
        }

        [HttpPut]
        [Route("{id:int}/phone-number")]
        public async Task<IHttpActionResult> UpdateUserPhoneNumber(int id, string newPhoneNumber)
        {
            using (var context = new TaskDBContext())
            {
                var user = await context.Users
                    .Select(x => x)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                try
                {
                    if (user != null)
                    {
                        user.PhoneNumber = newPhoneNumber;

                        await context.SaveChangesAsync();

                        return Ok(user);
                    }

                    return BadRequest();
                }
                catch (DbEntityValidationException ex)
                {
                    var message = "";

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        message = " " + error.ValidationErrors.First().ErrorMessage;
                    }

                    return BadRequest(message);
                }
            }
        }        

        [HttpPut]
        [Route("{id:int}/email")]
        public async Task<IHttpActionResult> UpdateUserEmail(int id, string newEmail)
        {
            using (var context = new TaskDBContext())
            {
                var user = await context.Users
                    .Select(x => x)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                try
                {
                    if (user != null)
                    {
                        user.Email = newEmail;

                        await context.SaveChangesAsync();

                        return Ok(user);
                    }

                    return BadRequest();
                }
                catch (DbEntityValidationException ex)
                {
                    var message = "";

                    foreach (var error in ex.EntityValidationErrors)
                    {
                        message = " " + error.ValidationErrors.First().ErrorMessage;
                    }

                    return BadRequest(message);
                }
            }
        }
    }
}