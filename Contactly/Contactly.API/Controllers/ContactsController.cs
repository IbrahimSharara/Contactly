using Contactly.API.DTO.InputDTO;
using Contactly.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contactly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(ApplicationDBContext _Context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok( await _Context.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactDTO obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            await _Context.Contacts.AddAsync(new Contact { 
                Name = obj.Name ,
                PhoneNumber = obj.PhoneNumber ,
                Email = obj.Email,
                Favourit = obj.Favourit
            });
            await _Context.SaveChangesAsync();
            return Created("" ,obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact =await _Context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return BadRequest();
            }
            _Context.Contacts.Remove(contact);
            await _Context.SaveChangesAsync();
            return Ok();
        }
    }
}
