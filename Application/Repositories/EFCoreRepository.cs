using Domains.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class EFCoreRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public EFCoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id); // Using context directly instead of DbSet
        }

        // Fetch all records
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync(); // Using Set<T> to access the collection
        }

        // Add a new entity
        public async Task AddAsync(T entity)
        {
            _context.Add(entity);  // Using context's Add method
            await _context.SaveChangesAsync(); // Save the changes after adding
        }

        // Update an existing entity
        public void Update(T entity)
        {
            _context.Update(entity); // Using context's Update method
            _context.SaveChanges(); // Persist the changes
        }

        // Delete an entity
        public void Delete(T entity)
        {
            _context.Remove(entity); // Using context's Remove method
            _context.SaveChanges(); // Persist the changes
        }

        // Save the changes for other methods as needed
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(); // Saving the changes to the database
        }

    }
}
