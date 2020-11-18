using Articles.Domain.Interfaces;
using Articles.Entities;
using Articles.Infrastructure.Data.Context;
using Articles.Infrastructure.Data.Repository.Generic;
using System.Threading.Tasks;
using System.Linq;
using Articles.Util;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUser
    {
        public UserRepository(BaseContext context) : base(context)
        {
        }

        public async Task<User> Authenticate(string email, string password) => 
                await _dbSet.Where(x => x.Email == email && x.Password == HashMD5.getMD5(password)).FirstOrDefaultAsync();

        public async Task<User> GetByEmail(string email) => 
                await _dbSet.Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<User> GetByHash(string hash) =>
                await _dbSet.Where(x => x.Hash == hash).FirstOrDefaultAsync();
    }
}
