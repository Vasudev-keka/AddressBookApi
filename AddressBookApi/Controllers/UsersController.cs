using API.Data.Models;
using API.Services.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AddressBookAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IServices userServices;
        public ContactController(IServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet]
        public IEnumerable<User> GetAllContacts()
        {
            return userServices.GetUsers();
        }

        [HttpGet]
        [Route("{id:int}")]
        public User GetUser(int id)
        {
            return userServices.GetUserData(id);
        }

        [HttpGet]
        [Route("default")]
        public User GetDefault()
        {
            return userServices.DefaultContact();
        }

        [HttpGet]
        [Route("latest")]
        public User GetLatest()
        {
            return userServices.LatestContact();
        }

        [HttpPost]
        public User AddUser(User user)
        {
            userServices.AddUser(user);
            return user;
        }

        [HttpPut]
        [Route("{id:int}")]
        public User UpdateUser([FromRoute] int id, User user)
        {
            userServices.UpdateUserContact(user,id);
            return user;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public User DeleteUser(int id)
        {
            User contact = userServices.PopUserContact(id);
            return contact;
        }
    }
}
