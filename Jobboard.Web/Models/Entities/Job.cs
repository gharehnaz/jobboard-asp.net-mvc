using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobboard.Web.Models.Entities
{
    public class Job
    {
        [Key]
        public long Id { get; set; }

        public string JobTitle { get; set; }

        public string JobType { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string JobRegion { get; set; }

        public string PictureUrl { get; set; }
    }
}