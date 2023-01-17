using Microsoft.AspNetCore.Mvc;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IRepostory _repostory;

        public ActivityController(IRepostory repostory)
        {
            _repostory = repostory;
        }

        [HttpPost("Addactivity")]

        public async Task<IActionResult> AddActivity([FromBody] Activity act)
        {
            _repostory.AddActivity(act);
            return Ok("Activity added");
        }

        [HttpGet("ByEmail")]
        public async Task<IActionResult> GetByEmail( string email)
        {
           var act = await  _repostory.GetActivityEmail(email);
            if(act == null)
            {
                return BadRequest("Invalid Email");
            }
            return Ok(act);

        }

        [HttpDelete("bYid")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var activity = _repostory.DeleteActivityId(id);
            if(activity == null)
            {
                return BadRequest("User not found");
            }
            return Ok(activity);
        }

        [HttpGet("AllActivities")]
        public async Task<IActionResult> GetAllActivities()
        {
            var activies = _repostory.GetActivities();
            if(activies == null)
            {
                return BadRequest("Server error");
            }
            return Ok(activies);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repostory.GetActivityId(id);
            if (result == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateActivities([FromBody] Activity act)
        {
           
           await _repostory.UpdateActivity(act);
            return Ok(act);
        }

        [HttpGet("bykeyword")]
        public async Task<IActionResult> GetActivityByKeyword(string keyword)
        {
            var act = await _repostory.SearchByKeyword(keyword);
            if(act == null)
            {
                return BadRequest("Keyword not found");
            }
            return Ok(act);
        }
    }
}
