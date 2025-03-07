using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSApp.Domain.Entities;
using CQRSApp.Domain.Interfaces;
using CQRSApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRSApp.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            _context.Persons.Update(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePersonByIdAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
