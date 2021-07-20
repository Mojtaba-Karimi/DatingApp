using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IUserRepository _repository { get; }
        public IMapper _mapper { get; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _repository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);
        }
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _repository.GetMemberAsync(username);

        }
    }
}