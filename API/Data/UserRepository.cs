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
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataContext _context { get; }
        public IMapper _mapper { get; }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).ProjectTo<MemberDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public Task<IEnumerable<MemberDto>> GetMembersAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}