using AutoMapper;

using BellaArteira.Api.Models;
using BellaArteira.Core.Entities;
using BellaArteira.Core.Interfaces.Repositories;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BellaArteira.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="id"> Primary key</param>
        /// <response code="200">Returns a build</response>
        [HttpGet("{id}", Name = "GetUserAsync")]
        public async Task<UserModel> GetAsync(int id)
        {
            return _mapper.Map<UserModel>(await _userRepository.GetUserById(id));
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="newUser"> User information</param>
        /// <response code="200">Returns a build</response>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserModel newUser)
        {
            var userEntity = _mapper.Map<User>(newUser);

            var result = await _userRepository.AddUser(userEntity);
            
            if (result)
                return CreatedAtRoute("GetUserAsync", new { id = userEntity.Id }, userEntity);
            else
                return BadRequest(result);
    
        }
    }
}
