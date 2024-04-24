using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<MemberDTO> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUserAsync()
        {
            return await _context.Users
                .Include(x => x.Photos)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                .Include(x => x.Photos)
                .SingleOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<bool> SaveAllAsync()
        {
            //if smaller than 0, nothing is save into database
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            //Not saving anything here, just update entity checker entity has been updated
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}