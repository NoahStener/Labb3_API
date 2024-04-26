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
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
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

        [HttpGet("GetInterests/{userId:int}")]
        public async Task<IActionResult> GetInterestByUserId(int userId)
        {
            try
            {
                var interests = await _userRepository.GetUserInterests(userId);
                if(interests == null)
                {
                    return NotFound();
                }
                return Ok(interests);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
            }
            
        }

        [HttpGet("GetLinks/{userId:int}")]
        public async Task<IActionResult> GetLinksByUserId(int userId)
        {
            try
            {
                var links = await _userRepository.GetUserLinks(userId);
                if(links == null)
                {
                    return NotFound();
                }
                return Ok(links);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database");
            }
           
        }

        [HttpPost("AddInterest/{userId:int}")]
        public async Task<IActionResult> AddInterestToUserById(int userId, int interestId)
        {
            try
            {

                if (userId == 0 || interestId == 0)
                {
                    return BadRequest("Invalid userID or interestID");
                }

                await _userRepository.AddInterestToUser(userId, interestId);
                return Ok($"Interest with id : {interestId} added to user : {userId}");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error adding interest to user ");
            }
        }

        [HttpPost("AddLinkToInterest{userId:int}")]
        public async Task<IActionResult> AddLinkToUserInterestById(int userId,int interestId, string url)
        {
            try
            {
                if(userId == 0 || interestId == 0 || string.IsNullOrEmpty(url))
                {
                    return BadRequest("Invalid input");
                }

                await _userRepository.AddLinkToUserInterest(userId, interestId, url);
                return Ok($"{url} added to interest id : {interestId} for user with id : {userId}");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error adding link to interest for user ");
            }
        }
    }
}
