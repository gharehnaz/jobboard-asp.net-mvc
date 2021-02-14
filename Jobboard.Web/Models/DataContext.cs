using Jobboard.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jobboard.Web.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategoryEntity> NewsCategory { get; set; }

        public DbSet<Job> Jobs { get; set; }


        public DataContext() : base("baseConnection")
        {

        }
    }
}