using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobboard.Web.Models.Entities
{
    public class BaseEnities
    {
        public string Title { get; set; }

        public long Id { get; set; }
        
        public string PictureUrl { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public BaseEnities()
        {
            CreateDate = DateTime.Now;
        }
    }
}