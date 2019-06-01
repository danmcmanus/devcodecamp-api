using DevCodeCamp.Domain.Models;
using System.Threading.Tasks;
using System.Web.Http;
using DCC.Domain.Services;

namespace DevCodeCamp.Api.Controllers
{
    [RoutePrefix("instructors")]
    public class InstructorsController : ApiController
    {
        private readonly IInstructorsService _instructorsService;

        public InstructorsController(IInstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetInstructors()
        {
            var response = await _instructorsService.GetAllInstructorsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{instructorId}")]
        public async Task<IHttpActionResult> GetInstructorById(int instructorId)
        {
            var response = await _instructorsService.GetInstructorByIdAsync(instructorId);
            return Ok(response);
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddInstructor([FromBody]InstructorRequest request)
        {
            var response = await _instructorsService.AddInstructorAsync(request);
            if (response.IsError)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response);
        }

        [HttpPatch]
        [Route("{instructorId}")]
        public async Task<IHttpActionResult> UpdateInstructorData([FromBody]UpdateInstructorRequest request)
        {
            var response = await _instructorsService.UpdateInstructorAsync(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("rate")]
        public async Task<IHttpActionResult> RateInstructor([FromBody] RateInstructorRequest request)
        {
            var response = await _instructorsService.RateInstructorAsync(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{instructorId}")]
        public async Task<IHttpActionResult> Delete(int instructorId)
        {
            var response = await _instructorsService.DeleteInstructorAsync(instructorId);
            return Ok(response);
        }
    }
}
