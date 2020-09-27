using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreAPI.Models;

namespace AspNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private readonly PhoneContext _context;

        public ContactInfosController(PhoneContext context)
        {
            _context = context;
        }

        // GET: api/ContactInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetContactInfos()
        {
            return await _context.ContactInfos.Include(p => p.Phone).ToListAsync();
            //return await _context.ContactInfos.ToListAsync();
        }

        // GET: api/ContactInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null)
            {
                return NotFound();
            }

            return contactInfo;
        }

        // PUT: api/ContactInfos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInfo(int id, ContactInfo contactInfo)
        {
            if (id != contactInfo.ContactInfoId)
            {
                return BadRequest();
            }

            _context.Entry(contactInfo).State = EntityState.Modified;
            var contactInfos = _context.ContactInfos.Include(p => p.Phone);
            _context.Entry(contactInfos).CurrentValues.SetValues(contactInfo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactInfos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContactInfo>> PostContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactInfo", new { id = contactInfo.ContactInfoId }, contactInfo);
        }

        // DELETE: api/ContactInfos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactInfo>> DeleteContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return contactInfo;
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.ContactInfoId == id);
        }
    }
}
