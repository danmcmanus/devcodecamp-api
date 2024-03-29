﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCodeCamp.Domain.Models
{
    public class UpdateInstructorResponse : BaseApiResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public decimal AverageRating { get; set; }
        public int AggregateRatings { get; set; }
        public int NumberOfRatings { get; set; }
        public bool IsDeleted { get; set; }
    }
}
