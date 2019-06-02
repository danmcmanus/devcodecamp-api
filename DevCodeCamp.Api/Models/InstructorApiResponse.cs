using DevCodeCamp.Domain.Models;
using System.Web.Mvc;

namespace DevCodeCamp.Api.Models
{
    public class InstructorApiResponse : InstructorResponse
    {
        public FileContentResult ImageFile { get; set; }
    }
}