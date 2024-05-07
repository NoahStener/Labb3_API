using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
                
            }
            
        }

        [HttpGet("GetAllInterests")]
        public async Task<ActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _userRepository.GetAllInterests());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
            }
        }

        [HttpGet("GetInterests/{userId:int}")]
        public async Task<ActionResult> GetInterestByUserId(int userId)
        {
            try
            {
                var userExists = await _userRepository.UserExists(userId);
                if(!userExists)
                {
                    return NotFound($"User with ID: {userId} was not found");
                }

                var interests = await _userRepository.GetUserInterests(userId);
                if(interests == null)
                {
                    return NotFound("Interests not found for the user");
                }
                return Ok(interests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
            }
            
        }

        [HttpGet("GetLinks/{userId:int}")]
        public async Task<ActionResult> GetLinksByUserId(int userId)
        {
            try
            {
                var userExists = await _userRepository.UserExists(userId);
                if (!userExists)
                {
                    return NotFound($"User with ID: {userId} was not found");
                }

                var links = await _userRepository.GetUserLinks(userId);
                if(links == null)
                {
                    return NotFound("Links for user not found");
                }
                return Ok(links);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
            }
           
        }

        [HttpPost("AddInterest/{userId:int}")]
        public async Task<ActionResult> AddInterestToUserById(int userId, int interestId)
        {
            try
            {
                var userExists = await _userRepository.UserExists(userId);
                if (!userExists)
                {
                    return BadRequest("Invalid userID");
                }

                await _userRepository.AddInterestToUser(userId, interestId);
                return Ok($"Interest with ID: {interestId} added to user with ID: {userId}");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error adding interest to user ");
            }
        }

        [HttpPost("AddLinkToInterest{userId:int}")]
        public async Task<ActionResult> AddLinkToUserInterestById(int userId,int interestId, string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return BadRequest("Invalid input");
                }

                await _userRepository.AddLinkToUserInterest(userId, interestId, url);
                return Ok($"{url} added to interest ID: {interestId} for user with ID: {userId}");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error adding link to interest for user ");
            }
        }
    }
}
