using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSApp.Domain.Entities;

namespace CQRSApp.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task SaveChangesAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<bool> DeletePersonByIdAsync(Guid id);
        Task<bool> UpdatePersonAsync(Person person);
    }
}
