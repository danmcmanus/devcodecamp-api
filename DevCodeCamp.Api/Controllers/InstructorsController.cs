using DevCodeCamp.Domain.Models;
using System.Threading.Tasks;
using System.Web.Http;
using DCC.Domain.Services;
using System;
using System.IO;
using DevCodeCamp.Api.Models;

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

        [HttpPost]
        [Route("image")]
        public IHttpActionResult UploadCustomerImage([FromBody] InstructorApiRequest model)
        {
            //Depending on if you want the byte array or a memory stream, you can use the below. 
            //THIS IS NO LONGER NEEDED AS OUR MODEL NOW HAS A BYTE ARRAY
            //var imageDataByteArray = Convert.FromBase64String(model.ImageData);
 
            //When creating a stream, you need to reset the position, without it you will see that you always write files with a 0 byte length. 
            var imageDataStream = new MemoryStream(model.Image);
            imageDataStream.Position = 0;

            //Go and do something with the actual data.
            //_customerImageService.Upload([...])

            //For the purpose of the demo, we return a file so we can ensure it was uploaded correctly. 
            //But otherwise you can just return a 204 etc. 
            var result = new System.Web.Mvc.FileContentResult(model.Image, "image/png");
            result.FileDownloadName = Guid.NewGuid().ToString();
            return Ok(result);
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
