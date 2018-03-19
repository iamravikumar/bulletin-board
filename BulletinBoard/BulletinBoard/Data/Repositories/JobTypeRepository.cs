﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BulletinBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Data.Repositories
{
    internal class JobTypeRepository : IJobTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public JobTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobType>> GetAll()
        {
            return await _context.JobTypes.ToListAsync();
        }

        public async Task<JobType> GetById(string id)
        {
            return await _context.JobTypes.FirstOrDefaultAsync(x => x.JobTypeId == id);
        }

        public async Task Add(JobType item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(JobType item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(JobType item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
